using Angene.Essentials;
using Angene.Essentials.Components;
using Angene.Math.Vectors;

public static class XrCameraMath
{
    public static (Matrix4x4 view, Matrix4x4 proj) ForEye(Vec3 rigPos, VulkanCamera cam, Types.XrEyeView eye)
    {
        // Rig orientation from your camera: columns = right, up, back
        Vec3 f = cam.forward.Normalized;
        Vec3 s = Vec3.Cross(f, cam.up).Normalized;
        Vec3 u = Vec3.Cross(s, f);
        float[] R = { s.X, u.X, -f.X,
                      s.Y, u.Y, -f.Y,
                      s.Z, u.Z, -f.Z };

        float[] E = QuatToMat3(eye.qx, eye.qy, eye.qz, eye.qw);
        float[] W = Mul3(R, E); // eye orientation in world space

        // eye position in world space = rigPos + R * eyePos
        float ex = rigPos.X + R[0]*eye.px + R[1]*eye.py + R[2]*eye.pz;
        float ey = rigPos.Y + R[3]*eye.px + R[4]*eye.py + R[5]*eye.pz;
        float ez = rigPos.Z + R[6]*eye.px + R[7]*eye.py + R[8]*eye.pz;

        // view = inverse rigid transform = [Wᵀ | -Wᵀ·pos]
        var view = new Matrix4x4
        {
            M00 = W[0], M01 = W[3], M02 = W[6], M03 = -(W[0]*ex + W[3]*ey + W[6]*ez),
            M10 = W[1], M11 = W[4], M12 = W[7], M13 = -(W[1]*ex + W[4]*ey + W[7]*ez),
            M20 = W[2], M21 = W[5], M22 = W[8], M23 = -(W[2]*ex + W[5]*ey + W[8]*ez),
            M30 = 0,    M31 = 0,    M32 = 0,    M33 = 1
        };

        return (view, Projection(eye.left, eye.right, eye.up, eye.down, cam.nearPlane, cam.farPlane));
    }

    // Asymmetric Vulkan projection (Y-down clip space, depth 0..1)
    public static Matrix4x4 Projection(float l, float r, float u, float d, float n, float f)
    {
        float tl = MathF.Tan(l), tr = MathF.Tan(r), tu = MathF.Tan(u), td = MathF.Tan(d);
        float w = tr - tl;
        float h = td - tu;   // negative on purpose: Vulkan Y flip

        return new Matrix4x4
        {
            M00 = 2f / w, M01 = 0, M02 = (tr + tl) / w, M03 = 0,
            M10 = 0, M11 = 2f / h, M12 = (tu + td) / h, M13 = 0,
            M20 = 0, M21 = 0, M22 = -f / (f - n), M23 = -(f * n) / (f - n),
            M30 = 0, M31 = 0, M32 = -1f, M33 = 0
        };
    }

    static float[] QuatToMat3(float x, float y, float z, float w) => new[]
    {
        1 - 2*(y*y + z*z), 2*(x*y - z*w),     2*(x*z + y*w),
        2*(x*y + z*w),     1 - 2*(x*x + z*z), 2*(y*z - x*w),
        2*(x*z - y*w),     2*(y*z + x*w),     1 - 2*(x*x + y*y)
    };

    static float[] Mul3(float[] a, float[] b)
    {
        var r = new float[9];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                r[i*3 + j] = a[i*3]*b[j] + a[i*3+1]*b[3+j] + a[i*3+2]*b[6+j];
        return r;
    }
}