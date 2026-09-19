using Angene.Math.Vectors;
using static Angene.Essentials.Types;

namespace Angene.Essentials.Components;
public class Transform3D
{
    public Vec3 pos = new(0.0f, 0.0f, 0.0f);
    public Vec3 rot = new(0.0f, 0.0f, 0.0f);
    public Vec3 scale = new(1.0f, 1.0f, 1.0f);

    public Matrix4x4 ModelView;
    public Matrix4x4 Proj;

    public Matrix4x4 GetMatrix()
    {
        Matrix4x4 rotation = Matrix4x4.RotationZ(rot.Z) 
                        * Matrix4x4.RotationY(rot.Y) 
                        * Matrix4x4.RotationX(rot.X);
    return Matrix4x4.Translation(pos) * rotation * Matrix4x4.Scale(scale);
    }

    public Transform3D() {}

    public Transform3D(Transform3D buh)
    {
        pos = buh.pos;
        rot = buh.rot;
        scale = buh.scale;
    }

    public Transform3D(Vec3 _pos, Vec3 _rot, Vec3 _scale)
    {
        pos = _pos;
        rot = _rot;
        scale = _scale;
    }
}

public class Transform2D {
    public Vec2 pos = new(0.0f, 0.0f);
    public float rot = 0f;
    public Vec2 scale = new(1.0f, 1.0f);

    public Matrix4x4 GetMatrix()
    {
        Matrix4x4 scaleMat = Matrix4x4.Scale(scale.X, scale.Y, 1.0f);
        Matrix4x4 rotMat = Matrix4x4.RotationZ(rot);
        Matrix4x4 transMat = Matrix4x4.Translation(pos.X, pos.Y, 0.0f);

        return scaleMat * rotMat * transMat;
    }

    public Transform2D() {}

    public Transform2D(Transform2D buh)
    {
        pos = buh.pos;
        rot = buh.rot;
        scale = buh.scale;
    }

    public Transform2D(Vec2 _pos, float _rot, Vec2 _scale)
    {
        pos = _pos;
        rot = _rot;
        scale = _scale;
    }

    public static implicit operator Transform2D(Transform3D d) => new Transform2D((Vec2)d.pos, d.rot.Z, (Vec2)d.scale);
    public static implicit operator Transform3D(Transform2D d) => new Transform3D((Vec3)d.pos, new Vec3(0f, 0f, d.rot), (Vec3)d.scale);
}

public class Mesh
{
    public IntPtr vertexBuffer;
    public IntPtr indexBuffer;
    public uint indexCount;

    public Mesh(Mesh buh)
    {
        vertexBuffer = buh.vertexBuffer;
        indexBuffer = buh.indexBuffer;
        indexCount = buh.indexCount;
    }

    public Mesh(IntPtr _vertexBuffer, IntPtr _indexBuffer, uint _indexCount = 0)
    {
        vertexBuffer = _vertexBuffer;
        indexBuffer = _indexBuffer;
        indexCount = _indexCount;
    }
}

public class VulkanCamera
{
    public Vec3 forward;
    public Vec3 up;
    public float fov;
    public float aspectRatio;
    public float nearPlane;
    public float farPlane;
    public bool isPrimary;
    public VulkanCamera(){}

    public VulkanCamera(VulkanCamera buh)
    {
        forward = buh.forward;
        up = buh.up;
        fov = buh.fov;
        aspectRatio = buh.aspectRatio;
        nearPlane = buh.nearPlane;
        farPlane = buh.farPlane;
        isPrimary = buh.isPrimary;
    }

    public Matrix4x4 LookAt(Vec3 eye, Vec3 target, Vec3 up)
    {
        Vec3 f = (target - eye).Normalized;
        Vec3 s = Vec3.Cross(f, up).Normalized;
        Vec3 u = Vec3.Cross(s, f);
        return new Matrix4x4
        {
            M00 = s.X,  M01 = s.Y,  M02 = s.Z,  M03 = -Vec3.Dot(s, eye),
            M10 = u.X,  M11 = u.Y,  M12 = u.Z,  M13 = -Vec3.Dot(u, eye),
            M20 = -f.X, M21 = -f.Y, M22 = -f.Z, M23 = Vec3.Dot(f, eye),
            M30 = 0,    M31 = 0,    M32 = 0,    M33 = 1
        };
    }

    public void AddTriangle(Vec3 p0, Vec3 p1, Vec3 p2, FaceColor color, Matrix4x4 modelView, Matrix4x4 proj, List<(Vec3, Vec3, Vec3, float, FaceColor)> outTriangles)
    {
        Vec3 v0 = TransformPoint(modelView, p0);
        Vec3 v1 = TransformPoint(modelView, p1);
        Vec3 v2 = TransformPoint(modelView, p2);

        float depth = (v0.Z + v1.Z + v2.Z) / 3f;

        Vec3 ndc0 = ProjectToNdc(proj, v0);
        Vec3 ndc1 = ProjectToNdc(proj, v1);
        Vec3 ndc2 = ProjectToNdc(proj, v2);

        outTriangles.Add((ndc0, ndc1, ndc2, depth, color));
    }

    public void AppendVertex(List<float> verts, Vec3 pos, FaceColor color)
    {
        verts.Add(pos.X); verts.Add(pos.Y); verts.Add(pos.Z);
        verts.Add(color.R); verts.Add(color.G); verts.Add(color.B); verts.Add(color.A);
    }

    // Affine transform (view/model matrices always have row3 = (0,0,0,1), so w stays 1).
    public Vec3 TransformPoint(Matrix4x4 m, Vec3 p) => new(
        m.M00 * p.X + m.M01 * p.Y + m.M02 * p.Z + m.M03,
        m.M10 * p.X + m.M11 * p.Y + m.M12 * p.Z + m.M13,
        m.M20 * p.X + m.M21 * p.Y + m.M22 * p.Z + m.M23
    );

    // Full projective transform + perspective divide (proj matrix has a non-trivial row3).
    public Vec3 ProjectToNdc(Matrix4x4 m, Vec3 p)
    {
        float x = m.M00 * p.X + m.M01 * p.Y + m.M02 * p.Z + m.M03;
        float y = m.M10 * p.X + m.M11 * p.Y + m.M12 * p.Z + m.M13;
        float z = m.M20 * p.X + m.M21 * p.Y + m.M22 * p.Z + m.M23;
        float w = m.M30 * p.X + m.M31 * p.Y + m.M32 * p.Z + m.M33;
        
        if (MathF.Abs(w) > 1e-6f)
            return new Vec3(x / w, y / w, z / w);

        return new Vec3(x, y, z);
    }

    public Matrix4x4 LookTo(Vec3 eye, Vec3 forward, Vec3 up) => LookAt(eye, eye + forward, up);

    public Matrix4x4 Perspective(float fovRadians, float aspectRatio, float nearPlane, float farPlane) => PerspectiveVulkan(fovRadians, aspectRatio, nearPlane, farPlane);

    public static Matrix4x4 PerspectiveVulkan(float fovRadians, float aspectRatio, float nearPlane, float farPlane)
    {
        float tanHalfFov = MathF.Tan(fovRadians / 2f);

        return new Matrix4x4
        {
            M00 = 1f / (aspectRatio * tanHalfFov),
            M01 = 0, 
            M02 = 0, 
            M03 = 0,

            M10 = 0,
            M11 = -(1f / tanHalfFov), 
            M12 = 0, 
            M13 = 0,

            M20 = 0, 
            M21 = 0,
            M22 = -(farPlane + nearPlane) / (farPlane - nearPlane),
            M23 = -(2f * farPlane * nearPlane) / (farPlane - nearPlane),

            M30 = 0, 
            M31 = 0,
            M32 = -1f,
            M33 = 0
        };
    }
}

public class D3D11Camera
{
    public Vec3 forward;
    public Vec3 up;
    public float fov;
    public float aspectRatio;
    public float nearPlane;
    public float farPlane;
    public bool isPrimary;

    public D3D11Camera(Vec3 _forward, Vec3 _up, float _fov, float _aspectRatio, float _nearPlane, float _farPlane, bool _isPrimary)
    {
        forward = _forward;
        up = _up;
        fov = _fov;
        aspectRatio = _aspectRatio;
        nearPlane = _nearPlane;
        farPlane = _farPlane;
        isPrimary = _isPrimary;
    }

    public Matrix4x4 LookAt(Vec3 eye, Vec3 target, Vec3 up)
    {
        Vec3 f = (target - eye).Normalized;
            
            Vec3 s = Vec3.Cross(up, f).Normalized;
            
            Vec3 u = Vec3.Cross(f, s);
            return new Matrix4x4
            {
                M00 = s.X,  M01 = s.Y,  M02 = s.Z,  M03 = -Vec3.Dot(s, eye),
                M10 = u.X,  M11 = u.Y,  M12 = u.Z,  M13 = -Vec3.Dot(u, eye),
                M20 = f.X,  M21 = f.Y,  M22 = f.Z,  M23 = -Vec3.Dot(f, eye),
                M30 = 0,    M31 = 0,    M32 = 0,    M33 = 1
            };
    }

    public Matrix4x4 LookTo(Vec3 eye, Vec3 target, Vec3 up) => LookAt(eye, eye + forward, up);

    public Matrix4x4 Perspective(float fovRadians, float aspectRatio, float nearPlane, float farPlane) => PerspectiveD3D11(fovRadians, aspectRatio, nearPlane, farPlane);

    public static Matrix4x4 PerspectiveD3D11(float fovRadians, float aspectRatio, float nearPlane, float farPlane)
    {
        float tanHalfFov = MathF.Tan(fovRadians / 2f);

        return new Matrix4x4
        {
            M00 = 1f / (aspectRatio * tanHalfFov),
            M01 = 0, 
            M02 = 0, 
            M03 = 0,

            M10 = 0,
            M11 = 1f / tanHalfFov,
            M12 = 0, 
            M13 = 0,

            M20 = 0, 
            M21 = 0,
            M22 = farPlane / (farPlane - nearPlane),
            M23 = -(nearPlane * farPlane) / (farPlane - nearPlane),

            M30 = 0, 
            M31 = 0,
            M32 = 1f, 
            M33 = 0
        };
    }
}
