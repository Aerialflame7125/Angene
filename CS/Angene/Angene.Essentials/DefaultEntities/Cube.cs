using Angene.Essentials.Components;
using Angene.Essentials.GraphicsContexts;
using Angene.Math.Vectors;

namespace Angene.Essentials.DefaultEntities;

public class Cube
{
    public static Entity Instantiate(object graphicsContext, Vec3 pos, Vec3 rot, Vec3 scale, string name, Types.Material[] mats = null)
    {
        Entity _local = new Entity(pos, rot, scale, name);
        Types.Mesh m = _local.AddComponent(new Types.Mesh());
        switch (graphicsContext.GetType().ToString())
        {
            case "Angene.Graphics.Vulkan.VkGraphicsContext":
                m.vertexBuffer = ((IVkGraphicsContext)graphicsContext).CreateVertexBuffer(m.bytes, strideBytes: 7 * sizeof(float));
                break;
            default:
                throw new NotImplementedException($"[DefaultEntities | Instantiate] Instantiating a cube in graphics context '{graphicsContext.GetType()}' is not supported yet.");
        }

        BuildCubeMesh(_local, mats);
        
        return _local;
    }

    public static (Vec3[] corners, Types.Face[] faces) BuildCubeMesh(Entity cube, Types.Material[] mats, float s = 1f)
    {
        float h = s / 2f;
        var c = new[]
        {
            new Vec3(-h,-h,-h), new Vec3( h,-h,-h), new Vec3( h, h,-h), new Vec3(-h, h,-h), // back  0-3
            new Vec3(-h,-h, h), new Vec3( h,-h, h), new Vec3( h, h, h), new Vec3(-h, h, h), // front 4-7
        };
        var f = new[]
        {
            new Types.Face(4,5,6,7, mats[0]), // front
            new Types.Face(1,0,3,2, mats[1]), // back
            new Types.Face(0,4,7,3, mats[2]), // left
            new Types.Face(5,1,2,6, mats[3]), // right
            new Types.Face(3,7,6,2, mats[4]), // top
            new Types.Face(0,1,5,4, mats[5]), // bottom
        };

        cube.GetComponent<Types.Mesh>().Corners = c;
        cube.GetComponent<Types.Mesh>().Faces = f;
        
        return (c, f);
    }
}