using Angene.Common;
using Angene.Common.Settings;
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

    public sealed class Lifecycle
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

        public Lifecycle(object instance)
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
                Logger.LogWarning(
                    $"Script '{Instance.GetType().Name}' implements no lifecycle interfaces. " +
                    "Consider implementing IAwake, IUpdate, IScreenPlay, etc.",
                    LoggingTarget.Engine
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

        public static class ScriptBinding
        {
            // storage for entity script runtime
            private static readonly Dictionary<Entity, EntityRuntimeState> _entityStates = new();
            private static readonly Dictionary<Entity, List<Lifecycle>> _entityScripts = new();
            public static List<Action> destroyEngineList = new();

            private static bool shutdownEngineCalled = false;

            // api

            /// <summary>
            /// Execute lifecycle (Update, LateUpdate).
            /// Does not handle OnDraw()
            /// </summary>
            public static void Tick(IScene scene, double dt, EngineMode mode)
            {
                if (scene == null)
                {
                    Logger.LogError("Lifecycle.Tick called with null scene", LoggingTarget.Engine);
                    return;
                }

                var entities = scene.GetEntities();
                if (entities == null)
                {
                    Logger.LogWarning($"Scene '{scene.GetType().Name}' returned null entities list", LoggingTarget.Engine);
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
                        Logger.LogWarning(
                            $"Attempted to Update destroyed entity '{entity.name}'",
                            LoggingTarget.Engine
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
                    Logger.LogError("Lifecycle.Draw called with null scene", LoggingTarget.Engine);
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
                    Logger.LogWarning(
                        $"Entity '{entity.name}' already registered with lifecycle",
                        LoggingTarget.Engine
                    );
                    return;
                }

                var state = new EntityRuntimeState();
                _entityStates[entity] = state;

                // Initialize script bindings if not already present
                if (!_entityScripts.ContainsKey(entity))
                {
                    _entityScripts[entity] = new List<Lifecycle>();
                }

                // Execute Awake immediately
                ExecuteAwake(entity);
                state.AwakeCalled = true;

                // Execute OnEnable if entity is enabled
                if (state.Enabled)
                {
                    ExecuteOnEnable(entity);
                }
            }

            /// <summary>
            /// Handle entity destruction: invoke OnDisable() if enabled, then OnDestroy().
            /// Mark state as destroyed and prevent future lifecycle execution.
            /// NOTE: This is public because Entity.Destroy() calls it, and Entity may be in a different assembly.
            /// </summary>
            public static void DestroyEntity(Entity entity)
            {
                if (!_entityStates.TryGetValue(entity, out var state))
                {
                    Logger.LogWarning(
                        $"Attempted to destroy unregistered entity '{entity.name}'",
                        LoggingTarget.Engine
                    );
                    return;
                }

                if (state.Destroyed)
                {
                    Logger.LogWarning(
                        $"Attempted to remove '{entity.name}' which is already destroyed.",
                        LoggingTarget.Engine
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

                Logger.LogDebug(
                    $"Entity '{entity.name}' destroyed and removed from lifecycle",
                    LoggingTarget.Engine
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
                    Logger.LogWarning(
                        $"Attempted to set enabled state on unregistered entity '{entity.name}'",
                        LoggingTarget.Engine
                    );
                    return;
                }

                if (state.Destroyed)
                {
                    Logger.LogError(
                        $"Attempted to set enabled state on destroyed entity '{entity.name}'",
                        LoggingTarget.Engine
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
                    Logger.LogDebug($"Entity '{entity.name}' enabled", LoggingTarget.Engine);
                }
                else
                {
                    ExecuteOnDisable(entity);
                    Logger.LogDebug($"Entity '{entity.name}' disabled", LoggingTarget.Engine);
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
                    Logger.LogError("Attempted to register null script instance", LoggingTarget.Engine);
                    return;
                }

                if (!_entityScripts.ContainsKey(entity))
                {
                    _entityScripts[entity] = new List<Lifecycle>();
                }

                var binding = new Lifecycle(scriptInstance);
                _entityScripts[entity].Add(binding);

                Logger.LogDebug(
                    $"Script '{scriptInstance.GetType().Name}' registered to entity '{entity.name}'",
                    LoggingTarget.Engine
                );
            }

            /// <summary>
            /// Safe method to shutdown the engine
            /// Calls OnDestroy for all objects and shuts down safely.
            /// </summary>
            public static void ShutdownEngine()
            {
                if (shutdownEngineCalled)
                    return;

                shutdownEngineCalled = true;
                foreach (var binding in _entityScripts.Keys)
                {
                    if (binding.IsEnabled())
                    {
                        ExecuteOnDestroy(binding);
                    }
                }
                foreach (var callback in destroyEngineList)
                {
                    try
                    {
                        callback?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError($"Exception in destroy callback: {ex.Message}", LoggingTarget.Engine);
                    }
                }
                Logger.LogInfo("[ShutdownEngine] Oki bye bye!", LoggingTarget.Engine);
                destroyEngineList.Clear();
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
                        Logger.LogError(
                            $"Exception in Awake() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine
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
                        Logger.LogError(
                            $"Exception in OnEnable() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine
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
                        Logger.LogError(
                            $"Exception in Start() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine
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
                        Logger.LogError(
                            $"Exception in Update() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine
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
                        Logger.LogError(
                            $"Exception in LateUpdate() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine
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
                        Logger.LogError(
                            $"Exception in OnDraw() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine
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
                        Logger.LogError(
                            $"Exception in OnDisable() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine
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
                        Logger.LogError(
                            $"Exception in OnDestroy() for script '{binding.Instance.GetType().Name}' on entity '{entity.name}': {ex.Message}",
                            LoggingTarget.Engine
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