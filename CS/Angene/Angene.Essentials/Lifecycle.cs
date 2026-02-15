using Angene.Common;
using Angene.Globals;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Angene.Essentials
{
    public enum EngineMode
    {
        Edit,
        Play,
        Paused
    }

    public sealed class ScriptBinding
    {
        public object Instance;

        public Action? Awake;
        public Action? OnEnable;
        public Action? Start;
        public Action<double>? Update;
        public Action<double>? LateUpdate;
        public Action? OnDraw;
        public Action? OnDisable;
        public Action? OnDestroy;
        public Action<IntPtr>? OnMessage;
        public Action? Render;
        public Action? Cleanup;

        public ScriptBinding(object instance)
        {
            Instance = instance;
            BindLifecycleMethods();
        }

        private void BindLifecycleMethods()
        {
            bool hasAnyInterface = false;

            if (Instance is IScreenPlay screenPlay)
            {
                hasAnyInterface = true;

                // bind to script interfaces
                if (Start == null)
                    Start = screenPlay.Start;

                if (Update == null)
                    Update = screenPlay.Update;

                if (LateUpdate == null)
                    LateUpdate = screenPlay.LateUpdate;

                if (OnDraw == null)
                    OnDraw = screenPlay.OnDraw;

                if (OnMessage == null)
                    OnMessage = screenPlay.OnMessage;

                if (Render == null)
                    Render = screenPlay.Render;

                if (Cleanup == null)
                    Cleanup = screenPlay.Cleanup;
            }

            if (!hasAnyInterface)
            {
                Logger.Log(
                    $"Script '{Instance.GetType().Name}' implements no lifecycle interfaces. " +
                    "Consider implementing IAwake, IUpdate, IScreenPlay, etc.",
                    LoggingTarget.Engine,
                    LogLevel.Warning
                );
            }
        }

        internal sealed class EntityRuntimeState
        {
            public bool AwakeCalled;
            public bool Enabled = true;
            public bool StartCalled;
            public bool Destroyed;
        }

        public struct LifecycleInfo
        {
            public bool HasUpdate;
            public bool HasLateUpdate;
            public bool HasOnDraw;
            public bool HasStart;
        }

        public static class Lifecycle
        {
            // storage for entity script runtime
            private static readonly Dictionary<Entity, EntityRuntimeState> _entityStates = new();
            private static readonly Dictionary<Entity, List<ScriptBinding>> _entityScripts = new();

            // api

            /// <summary>
            /// Execute lifecycle (Update, LateUpdate).
            /// Does not handle OnDraw()
            /// </summary>
            public static void Tick(IScene scene, double dt, EngineMode mode)
            {
                if (scene == null)
                {
                    Logger.Log("Lifecycle.Tick called with null scene", LoggingTarget.Engine, LogLevel.Error);
                    return;
                }

                var entities = scene.GetEntities();
                if (entities == null)
                {
                    Logger.Log($"Scene '{scene.GetType().Name}' returned null entities list", LoggingTarget.Engine, LogLevel.Warning);
                    return;
                }

                // Ensure Start is called exactly once per entity (before first Update)
                foreach (var entity in entities)
                {
                    if (!_entityStates.TryGetValue(entity, out var state))
                        continue;

                    if (!state.Destroyed && state.Enabled && !state.StartCalled)
                    {
                        ExecuteStart(entity);
                        state.StartCalled = true;
                    }
                }

                // only run in play
                if (mode != EngineMode.Play)
                    return;

                // run updates first
                foreach (var entity in entities)
                {
                    if (!_entityStates.TryGetValue(entity, out var state))
                        continue;

                    if (state.Destroyed)
                    {
                        Logger.Log(
                            $"Attempted to Update destroyed entity '{entity.name}'",
                            LoggingTarget.Engine,
                            LogLevel.Warning
                        );
                        continue;
                    }

                    if (!state.Enabled || !state.StartCalled)
                        continue;

                    ExecuteUpdate(entity, dt);
                }

                // run lateupdate after update
                foreach (var entity in entities)
                {
                    if (!_entityStates.TryGetValue(entity, out var state))
                        continue;

                    if (state.Destroyed || !state.Enabled || !state.StartCalled)
                        continue;

                    ExecuteLateUpdate(entity, dt);
                }
            }

            /// <summary>
            /// Execute all OnDraw hooks.
            /// Safe in Edit, Play, and Paused modes.
            /// Must not mutate simulation state.
            /// </summary>
            public static void Draw(IScene scene, EngineMode mode)
            {
                if (scene == null)
                {
                    Logger.Log("Lifecycle.Draw called with null scene", LoggingTarget.Engine, LogLevel.Error);
                    return;
                }

                var entities = scene.GetEntities();
                if (entities == null)
                    return;

                foreach (var entity in entities)
                {
                    if (!_entityStates.TryGetValue(entity, out var state))
                        continue;

                    if (state.Destroyed || !state.Enabled)
                        continue;

                    ExecuteOnDraw(entity);
                }
            }

            /// <summary>
            /// Handle entity creation: invoke Awake() immediately, then OnEnable() if enabled.
            /// </summary>
            public static void HandleEntityCreated(Entity entity)
            {
                if (_entityStates.ContainsKey(entity))
                {
                    Logger.Log(
                        $"Entity '{entity.name}' already registered with lifecycle system",
                        LoggingTarget.Engine,
                        LogLevel.Warning
                    );
                    return;
                }

                var state = new EntityRuntimeState();
                _entityStates[entity] = state;

                // Initialize script bindings if not already present
                if (!_entityScripts.ContainsKey(entity))
                {
                    _entityScripts[entity] = new List<ScriptBinding>();
                }

                // Execute Awake immediately
                ExecuteAwake(entity);
                state.AwakeCalled = true;

                // Execute OnEnable if entity is enabled
                if (state.Enabled)
                {
                    ExecuteOnEnable(entity);
                }

                Logger.Log(
                    $"Entity '{entity.name}' registered with lifecycle system (Awake called)",
                    LoggingTarget.Engine,
                    LogLevel.Info
                );
            }

            /// <summary>
            /// Handle entity destruction: invoke OnDisable() if enabled, then OnDestroy().
            /// Mark state as destroyed and prevent future lifecycle execution.
            /// NOTE: This is public because Entity.Destroy() calls it, and Entity may be in a different assembly.
            /// </summary>
            public static void HandleEntityDestroyed(Entity entity)
            {
                if (!_entityStates.TryGetValue(entity, out var state))
                {
                    Logger.Log(
                        $"Attempted to destroy unregistered entity '{entity.name}'",
                        LoggingTarget.Engine,
                        LogLevel.Warning
                    );
                    return;
                }

                if (state.Destroyed)
                {
                    Logger.Log(
                        $"Entity '{entity.name}' already destroyed",
                        LoggingTarget.Engine,
                        LogLevel.Warning
                    );
                    return;
                }

                // Call OnDisable if enabled
                if (state.Enabled)
                {
                    ExecuteOnDisable(entity);
                }

                // Call OnDestroy
                ExecuteOnDestroy(entity);

                // Mark as destroyed
                state.Destroyed = true;

                Logger.Log(
                    $"Entity '{entity.name}' destroyed and removed from lifecycle",
                    LoggingTarget.Engine,
                    LogLevel.Info
                );
            }

            /// <summary>
            /// Toggle entity enabled state and call appropriate lifecycle methods.
            /// Never affects Awake or Start.
            /// </summary>
            public static void SetEntityEnabled(Entity entity, bool enabled)
            {
                if (!_entityStates.TryGetValue(entity, out var state))
                {
                    Logger.Log(
                        $"Attempted to set enabled state on unregistered entity '{entity.name}'",
                        LoggingTarget.Engine,
                        LogLevel.Warning
                    );
                    return;
                }

                if (state.Destroyed)
                {
                    Logger.Log(
                        $"Attempted to set enabled state on destroyed entity '{entity.name}'",
                        LoggingTarget.Engine,
                        LogLevel.Error
                    );
                    return;
                }

                // No change needed
                if (state.Enabled == enabled)
                    return;

                state.Enabled = enabled;

                if (enabled)
                {
                    ExecuteOnEnable(entity);
                    Logger.Log($"Entity '{entity.name}' enabled", LoggingTarget.Engine, LogLevel.Info);
                }
                else
                {
                    ExecuteOnDisable(entity);
                    Logger.Log($"Entity '{entity.name}' disabled", LoggingTarget.Engine, LogLevel.Info);
                }
            }

            /// <summary>
            /// Register a script with an entity's lifecycle system.
            /// This must be called when a script is attached to an entity.
            /// </summary>
            public static void RegisterScript(Entity entity, object scriptInstance)
            {
                if (scriptInstance == null)
                {
                    Logger.Log("Attempted to register null script instance", LoggingTarget.Engine, LogLevel.Error);
                    return;
                }

                if (!_entityScripts.ContainsKey(entity))
                {
                    _entityScripts[entity] = new List<ScriptBinding>();
                }

                var binding = new ScriptBinding(scriptInstance);
                _entityScripts[entity].Add(binding);

                Logger.Log(
                    $"Script '{scriptInstance.GetType().Name}' registered to entity '{entity.name}'",
                    LoggingTarget.Engine,
                    LogLevel.Info
                );
            }

            // ==================== INTERNAL EXECUTION METHODS ====================

            private static void ExecuteAwake(Entity entity)
            {
                if (!_entityScripts.TryGetValue(entity, out var scripts))
                    return;

                foreach (var binding in scripts)
                {
                    try
                    {
                        binding.Awake?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(
                            $"Exception in Awake() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine,
                            LogLevel.Error
                        );
                    }
                }
            }

            private static void ExecuteOnEnable(Entity entity)
            {
                if (!_entityScripts.TryGetValue(entity, out var scripts))
                    return;

                foreach (var binding in scripts)
                {
                    try
                    {
                        binding.OnEnable?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(
                            $"Exception in OnEnable() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine,
                            LogLevel.Error
                        );
                    }
                }
            }

            private static void ExecuteStart(Entity entity)
            {
                if (!_entityScripts.TryGetValue(entity, out var scripts))
                    return;

                foreach (var binding in scripts)
                {
                    try
                    {
                        binding.Start?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(
                            $"Exception in Start() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine,
                            LogLevel.Error
                        );
                    }
                }
            }

            private static void ExecuteUpdate(Entity entity, double dt)
            {
                if (!_entityScripts.TryGetValue(entity, out var scripts))
                    return;

                foreach (var binding in scripts)
                {
                    try
                    {
                        binding.Update?.Invoke(dt);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(
                            $"Exception in Update() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine,
                            LogLevel.Error
                        );
                    }
                }
            }

            private static void ExecuteLateUpdate(Entity entity, double dt)
            {
                if (!_entityScripts.TryGetValue(entity, out var scripts))
                    return;

                foreach (var binding in scripts)
                {
                    try
                    {
                        binding.LateUpdate?.Invoke(dt);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(
                            $"Exception in LateUpdate() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine,
                            LogLevel.Error
                        );
                    }
                }
            }

            private static void ExecuteOnDraw(Entity entity)
            {
                if (!_entityScripts.TryGetValue(entity, out var scripts))
                    return;

                foreach (var binding in scripts)
                {
                    try
                    {
                        binding.OnDraw?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(
                            $"Exception in OnDraw() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine,
                            LogLevel.Error
                        );
                    }
                }
            }

            private static void ExecuteOnDisable(Entity entity)
            {
                if (!_entityScripts.TryGetValue(entity, out var scripts))
                    return;

                foreach (var binding in scripts)
                {
                    try
                    {
                        binding.OnDisable?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(
                            $"Exception in OnDisable() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine,
                            LogLevel.Error
                        );
                    }
                }
            }

            private static void ExecuteOnDestroy(Entity entity)
            {
                if (!_entityScripts.TryGetValue(entity, out var scripts))
                    return;

                foreach (var binding in scripts)
                {
                    try
                    {
                        binding.OnDestroy?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(
                            $"Exception in OnDestroy() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine,
                            LogLevel.Error
                        );
                    }
                }

                // Clean up after destroy
                _entityScripts.Remove(entity);
                _entityStates.Remove(entity);
            }
        }
    }
}