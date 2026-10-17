using System.Buffers.Text;
using Angene.Math.Vectors;

namespace Angene.Assets;

public class Reader
{
    public class Obj
    {
        public class ObjMesh
        {
            public List<Vec3> Vertices { get; } = new();
            public List<Vec2> Textures { get; } = new();
            public List<Vec3> Normals  { get; } = new();
            public List<ObjFace> Faces { get; } = new();
        }

        public class ObjFace
        {
            public List<(int VertexIdx, int TextureIdx, int NormalIdx)> Indices { get; } = new(4);
        }

        public static class ObjReader
        {
            public static ObjMesh Load(byte[] bytes)
            {
                var mesh = new ObjMesh();
                ReadOnlySpan<byte> data = bytes;

                if (data.Length >= 3 && data[0] == 0xEF && data[1] == 0xBB && data[2] == 0xBF)
                    data = data.Slice(3); // UTF-8 BOM

                while (!data.IsEmpty)
                {
                    int nl = data.IndexOf((byte)'\n');
                    ReadOnlySpan<byte> line;
                    if (nl < 0) { line = data; data = default; }
                    else        { line = data.Slice(0, nl); data = data.Slice(nl + 1); }

                    ParseLine(line, mesh);
                }

                return mesh;
            }

            private static void ParseLine(ReadOnlySpan<byte> line, ObjMesh mesh)
            {
                var rest = line;
                var key = NextToken(ref rest);
                if (key.IsEmpty || key[0] == (byte)'#') return;

                if (key.Length == 1 && key[0] == (byte)'v')
                {
                    float x = NextFloat(ref rest), y = NextFloat(ref rest), z = NextFloat(ref rest);
                    mesh.Vertices.Add(new Vec3(x, y, z));
                }
                else if (key.Length == 2 && key[0] == (byte)'v' && key[1] == (byte)'t')
                {
                    float u = NextFloat(ref rest), v = NextFloat(ref rest);
                    mesh.Textures.Add(new Vec2(u, v));
                }
                else if (key.Length == 2 && key[0] == (byte)'v' && key[1] == (byte)'n')
                {
                    float x = NextFloat(ref rest), y = NextFloat(ref rest), z = NextFloat(ref rest);
                    mesh.Normals.Add(new Vec3(x, y, z));
                }
                else if (key.Length == 1 && key[0] == (byte)'f')
                {
                    var face = new ObjFace();
                    while (true)
                    {
                        var tok = NextToken(ref rest);
                        if (tok.IsEmpty) break;
                        face.Indices.Add(ParseCorner(tok));
                    }
                    mesh.Faces.Add(face);
                }
            }

            // "v", "v/t", "v//n", "v/t/n"
            private static (int, int, int) ParseCorner(ReadOnlySpan<byte> tok)
            {
                int s1 = tok.IndexOf((byte)'/');
                if (s1 < 0) return (ParseInt(tok), 0, 0);

                int v = ParseInt(tok.Slice(0, s1));
                var rest = tok.Slice(s1 + 1);
                int s2 = rest.IndexOf((byte)'/');

                if (s2 < 0)
                    return (v, rest.IsEmpty ? 0 : ParseInt(rest), 0);

                var ts = rest.Slice(0, s2);
                var ns = rest.Slice(s2 + 1);
                return (v, ts.IsEmpty ? 0 : ParseInt(ts), ns.IsEmpty ? 0 : ParseInt(ns));
            }

            private static bool IsWs(byte b) => b == (byte)' ' || b == (byte)'\t' || b == (byte)'\r';

            private static ReadOnlySpan<byte> NextToken(ref ReadOnlySpan<byte> s)
            {
                int start = 0;
                while (start < s.Length && IsWs(s[start])) start++;
                int end = start;
                while (end < s.Length && !IsWs(s[end])) end++;

                var tok = s.Slice(start, end - start);
                s = s.Slice(end);
                return tok;
            }

            private static float NextFloat(ref ReadOnlySpan<byte> s)
            {
                var tok = NextToken(ref s);
                if (!Utf8Parser.TryParse(tok, out float f, out int used) || used != tok.Length)
                    throw new FormatException("Invalid float in OBJ file.");
                return f;
            }

            private static int ParseInt(ReadOnlySpan<byte> tok)
            {
                if (!Utf8Parser.TryParse(tok, out int i, out int used) || used != tok.Length)
                    throw new FormatException("Invalid index in OBJ file.");
                return i;
            }

            public static bool CheckIfObj(byte[] bytes)
            {
                ReadOnlySpan<byte> data = bytes.AsSpan(0, System.Math.Min(bytes.Length, 8192)); // read first 8kb

                bool hasVertex = false;
                while (!data.IsEmpty)
                {
                    int nl = data.IndexOf((byte)'\n');
                    var line = nl < 0 ? data : data.Slice(0, nl);
                    data = nl < 0 ? default : data.Slice(nl + 1);

                    var rest = line;
                    var key = NextToken(ref rest);
                    if (key.IsEmpty || key[0] == (byte)'#') continue;
                    
                    foreach (var b in key)
                        if (b < 0x09 || (b > 0x0D && b < 0x20)) return false;

                    if (key.Length == 1 && key[0] == (byte)'v') hasVertex = true;
                }

                return hasVertex;
            }
        }
    }
}