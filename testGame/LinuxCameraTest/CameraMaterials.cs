using System;
using System.Collections.Generic;
using System.IO;
using Angene.Common;
using Angene.Main;

namespace Game
{
    /// <summary>
    /// Simple RGBA colour value read out of the material package.
    /// </summary>
    public struct FaceColor
    {
        public float R, G, B, A;
        public FaceColor(float r, float g, float b, float a) { R = r; G = g; B = b; A = a; }
    }

    /// <summary>
    /// Loads the cube's six face "materials" out of Assets/CameraMaterials.angpkg via
    /// Angene.Main.Package. Each entry is a tiny 16-byte blob (4 x float32 RGBA) — the
    /// current Vulkan backend has no sampler/descriptor-set support yet, so a real
    /// image-based material can't be bound to the pipeline. Reading colours out of a
    /// real .angpkg still exercises the actual package pipeline (same Package.Open /
    /// OpenStream path used for any other asset) rather than hard-coding colours in code.
    /// </summary>
    public static class CameraMaterials
    {
        public static Dictionary<string, FaceColor> Load(string packagePath)
        {
            var result = new Dictionary<string, FaceColor>();

            if (!File.Exists(packagePath))
            {
                Logger.LogError($"[CameraMaterials] Package not found at '{packagePath}'. Falling back to default colors.", LoggingTarget.MainGame);
                return DefaultColors();
            }

            try
            {
                using var package = Package.Open(packagePath, key: null);

                foreach (var entry in package.Entries)
                {
                    if (!entry.Path.StartsWith("materials/", StringComparison.OrdinalIgnoreCase))
                        continue;

                    using var stream = package.OpenStream(entry);
                    using var reader = new BinaryReader(stream);

                    float r = reader.ReadSingle();
                    float g = reader.ReadSingle();
                    float b = reader.ReadSingle();
                    float a = reader.ReadSingle();

                    // "materials/posx.color" -> "posx"
                    string key = Path.GetFileNameWithoutExtension(entry.Path);
                    result[key] = new FaceColor(r, g, b, a);
                }

                Logger.LogInfo($"[CameraMaterials] Loaded {result.Count} face materials from '{packagePath}'.", LoggingTarget.MainGame);
            }
            catch (Exception ex)
            {
                Logger.LogError($"[CameraMaterials] Failed to read package: {ex.Message}. Falling back to default colors.", LoggingTarget.MainGame);
                return DefaultColors();
            }

            // Make sure every face has a color even if the package was missing an entry.
            foreach (var kvp in DefaultColors())
                if (!result.ContainsKey(kvp.Key))
                    result[kvp.Key] = kvp.Value;

            return result;
        }

        private static Dictionary<string, FaceColor> DefaultColors() => new()
        {
            ["posx"] = new FaceColor(0.85f, 0.25f, 0.25f, 1.0f),
            ["negx"] = new FaceColor(0.25f, 0.70f, 0.25f, 1.0f),
            ["posy"] = new FaceColor(0.25f, 0.45f, 0.85f, 1.0f),
            ["negy"] = new FaceColor(0.85f, 0.80f, 0.20f, 1.0f),
            ["posz"] = new FaceColor(0.80f, 0.30f, 0.85f, 1.0f),
            ["negz"] = new FaceColor(0.20f, 0.80f, 0.80f, 1.0f),
        };
    }
}
