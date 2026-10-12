using System;
using System.Collections.Generic;
using System.IO;
using Angene.Common;
using Angene.Main;
using static Angene.Essentials.Types;

namespace Game
{
    public static class CameraMaterials
    {
        public static List<Material> DefaultColors() => new()
        {
            new Material(Material.Type.SolidColor, new FaceColor(0.85f, 0.25f, 0.25f, 1.0f), "DefaultColor"),
            new Material(Material.Type.SolidColor, new FaceColor(0.25f, 0.70f, 0.25f, 1.0f), "DefaultColor"),
            new Material(Material.Type.SolidColor, new FaceColor(0.25f, 0.45f, 0.85f, 1.0f), "DefaultColor"),
            new Material(Material.Type.SolidColor, new FaceColor(0.85f, 0.80f, 0.20f, 1.0f), "DefaultColor"),
            new Material(Material.Type.SolidColor, new FaceColor(0.80f, 0.30f, 0.85f, 1.0f), "DefaultColor"),
            new Material(Material.Type.SolidColor, new FaceColor(0.20f, 0.80f, 0.80f, 1.0f), "DefaultColor"),
        };
    }
}
