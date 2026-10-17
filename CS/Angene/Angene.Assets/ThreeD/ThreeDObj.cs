using Angene.Assets.Packages;
using Angene.Common;
using Angene.Essentials;
using Angene.Essentials.GraphicsContexts;
using Angene.Math.Vectors;
using static Angene.Essentials.Components.Components;

namespace Angene.Assets.ThreeD;

public class ComponentExtensions
{
    public class ThreeDObj : Component
    {
        public readonly Package Pkg;
        private Package.ManifestEntry pkgManifest;
        private Stream dataStream;
        public readonly string Name;
        public readonly byte[] Data;
        
        public ThreeDObj(Package pkg, Package.ManifestEntry manifest, string name)
        {
            Pkg = pkg;
            Name = name;
            pkgManifest = manifest;

            using var stream = pkg.OpenStream(manifest);
            stream.Seek(0, SeekOrigin.Begin);
            using var ms = new MemoryStream();
            stream.CopyTo(ms);
            Data = ms.ToArray();
        }

        private static int ResolveIndex(int objIdx, int count)
        {
            if (objIdx > 0) return objIdx - 1;
            if (objIdx < 0) return count + objIdx;
            return -1;
        }

        public Types.Mesh CalculateMesh(SlangShaderResources.IShader shader, Entity target, Types.Material material = null)
        {
            if (!Reader.Obj.ObjReader.CheckIfObj(Data))
                throw new AngeneException("Failed to construct 3D Object: data is not a valid OBJ.");

            material ??= new Types.Material(
                Types.Material.Type.SolidColor, new Types.FaceColor(1f, 1f, 1f, 1f), "default");

            var obj = Reader.Obj.ObjReader.Load(Data);

            int faceGuess = obj.Faces.Count * 2;
            List<Vec3> corners = new List<Vec3>(faceGuess);
            List<Vec3> normals = new List<Vec3>(faceGuess);
            List<Vec2> uvs     = new List<Vec2>(faceGuess);
            List<Types.Face> faces   = new List<Types.Face>(obj.Faces.Count);
            Dictionary<(int, int, int), int> lookup  = new Dictionary<(int, int, int), int>(faceGuess);
            
            int GetCorner((int VertexIdx, int TextureIdx, int NormalIdx) i)
            {
                int v = ResolveIndex(i.VertexIdx,  obj.Vertices.Count);
                int t = ResolveIndex(i.TextureIdx, obj.Textures.Count);
                int n = ResolveIndex(i.NormalIdx,  obj.Normals.Count);

                if (v < 0 || v >= obj.Vertices.Count)
                    throw new AngeneException($"Face references missing vertex {i.VertexIdx}.");
                if (t >= obj.Textures.Count || n >= obj.Normals.Count)
                    throw new AngeneException("Face references missing UV or normal.");

                var key = (v, t, n);
                if (lookup.TryGetValue(key, out int existing)) return existing;

                int idx = corners.Count;
                corners.Add(obj.Vertices[v]);
                uvs.Add(t >= 0 ? obj.Textures[t] : default);
                normals.Add(n >= 0 ? obj.Normals[n] : default);
                lookup[key] = idx;
                return idx;
            }

            foreach (var objFace in obj.Faces)
            {
                var idx = objFace.Indices;
                if (idx.Count < 3) continue;

                var c = new int[idx.Count];
                for (int i = 0; i < idx.Count; i++) c[i] = GetCorner(idx[i]);
                
                if (c.Length == 3)
                {
                    faces.Add(new Types.Face(c[0], c[1], c[2], c[2], material));
                    continue;
                }
                
                int k = 1;
                while (k + 1 < c.Length)
                {
                    if (k + 2 < c.Length)
                    {
                        faces.Add(new Types.Face(c[0], c[k], c[k + 1], c[k + 2], material));
                        k += 2;
                    }
                    else
                    {
                        faces.Add(new Types.Face(c[0], c[k], c[k + 1], c[k + 1], material));
                        k += 1;
                    }
                }
            }

            return new Types.Mesh(corners.ToArray(), uvs.ToArray(), faces.ToArray(), normals.ToArray(), shader, target);
        }
    }
}
