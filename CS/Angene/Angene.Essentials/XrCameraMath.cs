using Angene.Essentials;
using Angene.Essentials.Components;
using Angene.Math.Vectors;

public static class XrCameraMath
{
    public static Vec3 FromXr(Vec3 p) => new(p.X, p.Y, -p.Z);
    public static Quaternion FromXr(Quaternion q) => new(-q.X, -q.Y, q.Z, q.W);
    
    public static (Matrix4x4 view, Matrix4x4 proj) ForEye(Matrix4x4 rigWorld, VulkanCamera cam, Types.XrEyeView eye)
    {
        Vec3 f = cam.forward.Normalized;
        Vec3 s = Vec3.Cross(f, cam.up).Normalized;
        Vec3 u = Vec3.Cross(s, f);
        float[] R = RigRotation(rigWorld);
        Vec3 rigPos = Matrix4x4.WorldPosition(rigWorld);

        float[] E = QuatToMat3(-eye.qx, -eye.qy, eye.qz, eye.qw);
        float px = eye.px, py = eye.py, pz = -eye.pz;
        float ex = rigPos.X + R[0]*px + R[1]*py + R[2]*pz;
        float ey = rigPos.Y + R[3]*px + R[4]*py + R[5]*pz;
        float ez = rigPos.Z + R[6]*px + R[7]*py + R[8]*pz;
        float[] W = Mul3(R, E);
        
        var view = new Matrix4x4
        {
            M00 = W[0], M01 = W[3], M02 = W[6], M03 = -(W[0]*ex + W[3]*ey + W[6]*ez),
            M10 = W[1], M11 = W[4], M12 = W[7], M13 = -(W[1]*ex + W[4]*ey + W[7]*ez),
            M20 = -W[2], M21 = -W[5], M22 = -W[8], M23 = (W[2]*ex + W[5]*ey + W[8]*ez),
            M30 = 0,    M31 = 0,    M32 = 0,    M33 = 1
        };

        return (view, Projection(eye.left, eye.right, eye.up, eye.down, cam.nearPlane, cam.farPlane));
    }
    
    public static Vec3 PosToWorld(Matrix4x4 rigWorld, Vec3 p)
    {
        float[] R = RigRotation(rigWorld);
        Vec3 o = Matrix4x4.WorldPosition(rigWorld);
        return new Vec3(
            o.X + R[0]*p.X + R[1]*p.Y + R[2]*p.Z,
            o.Y + R[3]*p.X + R[4]*p.Y + R[5]*p.Z,
            o.Z + R[6]*p.X + R[7]*p.Y + R[8]*p.Z);
    }

// Rotation part of the rig matrix, with scale stripped, row-major like R above.
    static float[] RigRotation(Matrix4x4 m)
    {
        float l0 = MathF.Sqrt(m.M00*m.M00 + m.M10*m.M10 + m.M20*m.M20);
        float l1 = MathF.Sqrt(m.M01*m.M01 + m.M11*m.M11 + m.M21*m.M21);
        float l2 = MathF.Sqrt(m.M02*m.M02 + m.M12*m.M12 + m.M22*m.M22);
        return new[]
        {
            m.M00/l0, m.M01/l1, m.M02/l2,
            m.M10/l0, m.M11/l1, m.M12/l2,
            m.M20/l0, m.M21/l1, m.M22/l2
        };
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
    
    public static Vec3 PosToWorld(Vec3 rigPos, VulkanCamera cam, Vec3 p)
    {
        Vec3 f = cam.forward.Normalized;
        Vec3 s = Vec3.Cross(f, cam.up).Normalized;
        Vec3 u = Vec3.Cross(s, f);
        return new Vec3(
            rigPos.X + s.X * p.X + u.X * p.Y - f.X * p.Z,
            rigPos.Y + s.Y * p.X + u.Y * p.Y - f.Y * p.Z,
            rigPos.Z + s.Z * p.X + u.Z * p.Y - f.Z * p.Z);
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