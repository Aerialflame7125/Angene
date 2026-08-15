using Angene.Math.Vectors;

namespace Angene.Essentials.Components;
public class Transform3D
{
    public Vec3 pos = new(0.0f, 0.0f, 0.0f);
    public Vec3 rot = new(0.0f, 0.0f, 0.0f);
    public Vec3 scale = new(1.0f, 1.0f, 1.0f);

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
