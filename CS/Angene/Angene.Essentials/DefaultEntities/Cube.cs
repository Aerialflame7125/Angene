using Angene.Essentials.Components;
using Angene.Essentials.GraphicsContexts;
using Angene.Math.Vectors;

namespace Angene.Essentials.DefaultEntities;

public class Cube
{
    public static Entity Instantiate(object graphicsContext, Vec3 pos, Vec3 rot, Vec3 scale, string name)
    {
        Entity _local = new Entity(pos, rot, scale, name);
        Mesh m = _local.AddComponent(new Mesh());
        switch (graphicsContext.GetType().ToString())
        {
            case "Angene.Graphics.Vulkan.VkGraphicsContext":
                m.vertexBuffer = ((IVkGraphicsContext)graphicsContext).CreateVertexBuffer(m.bytes, strideBytes: 7 * sizeof(float));
                break;
            default:
                throw new NotImplementedException($"[DefaultEntities | Instantiate] Instantiating a cube in graphics context '{graphicsContext.GetType()}' is not supported yet.");
        }
        
        return _local;
    }
}