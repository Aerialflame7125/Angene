using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Angene.Math.Vectors
{
    // Started new developments on 2026,05,24 for Angraphics
    public struct Point { int x, y;
        private int x1;
        private int y2;

        public Point(int x1, int y2) : this()
        {
            this.x1 = x1;
            this.y2 = y2;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2(float x = 0, float y = 0)
    {
        public float X = x, Y = y;

        public static Vec2 Zero => new(0, 0);
        public static Vec2 One => new(1, 1);
        public static Vec2 Up => new(0, -1); // screen space
        public static Vec2 Down => new(0, 1);
        public static Vec2 Left => new(-1, 0);
        public static Vec2 Right => new(1, 0);

        public float Length => MathF.Sqrt(X * X + Y * Y);
        public float LengthSquared => X * X + Y * Y;
        public Vec2 Normalized => this / Length;

        public static float Dot(Vec2 a, Vec2 b) => a.X * b.X + a.Y * b.Y;
        public static float Distance(Vec2 a, Vec2 b) => (a - b).Length;
        public static Vec2 Lerp(Vec2 a, Vec2 b, float t) => a + (b - a) * t;
        public static Vec2 Reflect(Vec2 v, Vec2 normal) => v - 2 * Dot(v, normal) * normal;

        public static Vec2 operator +(Vec2 a, Vec2 b) => new(a.X + b.X, a.Y + b.Y);
        public static Vec2 operator -(Vec2 a, Vec2 b) => new(a.X - b.X, a.Y - b.Y);
        public static Vec2 operator *(Vec2 v, float s) => new(v.X * s, v.Y * s);
        public static Vec2 operator *(float s, Vec2 v) => v * s;
        public static Vec2 operator /(Vec2 v, float s) => new(v.X / s, v.Y / s);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3(float x = 0, float y = 0, float z = 0)
    {
        public float X = x, Y = y, Z = z;

        public float Length => MathF.Sqrt(X * X + Y * Y + Z * Z);
        public Vec3 Normalized => this / Length;

        public static float Dot(Vec3 a, Vec3 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        public static Vec3 Cross(Vec3 a, Vec3 b) => new(
            a.Y * b.Z - a.Z * b.Y,
            a.Z * b.X - a.X * b.Z,
            a.X * b.Y - a.Y * b.X);
        public static Vec3 Lerp(Vec3 a, Vec3 b, float t) => a + (b - a) * t;

        public static Vec3 operator +(Vec3 a, Vec3 b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vec3 operator -(Vec3 a, Vec3 b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vec3 operator *(Vec3 v, float s) => new(v.X * s, v.Y * s, v.Z * s);
        public static Vec3 operator /(Vec3 v, float s) => new(v.X / s, v.Y / s, v.Z / s);

        public static implicit operator Vec2(Vec3 d) => new Vec2(d.X, d.Y);
        public static implicit operator Vec3(Vec2 d) => new Vec3(d.X, d.Y, 0f);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4(float x = 0, float y = 0, float z = 0, float w = 0)
    {
        public float X = x, Y = y, Z = z, W = w;

        public Vec4(Vec2 v, float z = 0, float w = 0) : this(v.X, v.Y, z, w) { }
        public Vec4(Vec3 v, float w = 0) : this(v.X, v.Y, v.Z, w) { }

        public static Vec4 Zero => new(0, 0, 0, 0);
        public static Vec4 One => new(1, 1, 1, 1);
        public static Vec4 UnitX => new(1, 0, 0, 0);
        public static Vec4 UnitY => new(0, 1, 0, 0);
        public static Vec4 UnitZ => new(0, 0, 1, 0);
        public static Vec4 UnitW => new(0, 0, 0, 1);

        public float Length => MathF.Sqrt(LengthSquared);
        public float LengthSquared => X * X + Y * Y + Z * Z + W * W;
        public Vec4 Normalized => this / Length;

        public static float Dot(Vec4 a, Vec4 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;
        public static float Distance(Vec4 a, Vec4 b) => (a - b).Length;
        public static Vec4 Lerp(Vec4 a, Vec4 b, float t) => a + (b - a) * t;
        public static Vec4 Min(Vec4 a, Vec4 b) => new(MathF.Min(a.X, b.X), MathF.Min(a.Y, b.Y), MathF.Min(a.Z, b.Z), MathF.Min(a.W, b.W));
        public static Vec4 Max(Vec4 a, Vec4 b) => new(MathF.Max(a.X, b.X), MathF.Max(a.Y, b.Y), MathF.Max(a.Z, b.Z), MathF.Max(a.W, b.W));

        public static Vec4 operator +(Vec4 a, Vec4 b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        public static Vec4 operator -(Vec4 a, Vec4 b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        public static Vec4 operator -(Vec4 v) => new(-v.X, -v.Y, -v.Z, -v.W);
        public static Vec4 operator *(Vec4 v, float s) => new(v.X * s, v.Y * s, v.Z * s, v.W * s);
        public static Vec4 operator *(float s, Vec4 v) => v * s;
        public static Vec4 operator *(Vec4 a, Vec4 b) => new(a.X * b.X, a.Y * b.Y, a.Z * b.Z, a.W * b.W); // component-wise, like Vector4
        public static Vec4 operator /(Vec4 v, float s) => new(v.X / s, v.Y / s, v.Z / s, v.W / s);

        public static explicit operator Vec3(Vec4 v) => new(v.X, v.Y, v.Z);
        public static explicit operator Vec2(Vec4 v) => new(v.X, v.Y);

        public static implicit operator System.Numerics.Vector4(Vec4 v) => new(v.X, v.Y, v.Z, v.W);
        public static implicit operator Vec4(System.Numerics.Vector4 v) => new(v.X, v.Y, v.Z, v.W);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct Quaternion(float x = 0, float y = 0, float z = 0, float w = 1)
    {
        public float X = x, Y = y, Z = z, W = w;

        public static Quaternion Identity => new(0, 0, 0, 1);

        public float LengthSquared => X * X + Y * Y + Z * Z + W * W;
        public float Length => MathF.Sqrt(LengthSquared);
        public Quaternion Normalized
        {
            get { float l = Length; return l > 1e-8f ? new(X / l, Y / l, Z / l, W / l) : Identity; }
        }

        public Quaternion Conjugate => new(-X, -Y, -Z, W);
        public Quaternion Inverse => new Quaternion(-X, -Y, -Z, W) * (1f / LengthSquared);

        public static Quaternion operator *(Quaternion q, float s) => new(q.X * s, q.Y * s, q.Z * s, q.W * s);

        // Hamilton product: (a * b) applies b first, then a (same as matrix multiplication order)
        public static Quaternion operator *(Quaternion a, Quaternion b) => new(
            a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y,
            a.W * b.Y - a.X * b.Z + a.Y * b.W + a.Z * b.X,
            a.W * b.Z + a.X * b.Y - a.Y * b.X + a.Z * b.W,
            a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z
        );

        public static Quaternion FromAxisAngle(Vec3 axis, float radians)
        {
            Vec3 n = axis.Normalized;
            float half = radians * 0.5f, s = MathF.Sin(half);
            return new(n.X * s, n.Y * s, n.Z * s, MathF.Cos(half));
        }

        /// Euler radians -> Quaternionernion, matching Transform3D.GetMatrix(): Rz * Ry * Rx
        public static Quaternion FromEuler(Vec3 euler)
        {
            float hx = euler.X * 0.5f, hy = euler.Y * 0.5f, hz = euler.Z * 0.5f;
            Quaternion qx = new(MathF.Sin(hx), 0, 0, MathF.Cos(hx));
            Quaternion qy = new(0, MathF.Sin(hy), 0, MathF.Cos(hy));
            Quaternion qz = new(0, 0, MathF.Sin(hz), MathF.Cos(hz));
            return qz * qy * qx;
        }

        /// Quaternionernion -> Euler radians (inverse of FromEuler). Has gimbal lock at Y = ±90°.
        public Vec3 ToEuler()
        {
            Quaternion q = Normalized;
            float m20 = 2 * (q.X * q.Z - q.Y * q.W);
            float m21 = 2 * (q.Y * q.Z + q.X * q.W);
            float m22 = 1 - 2 * (q.X * q.X + q.Y * q.Y);
            float m10 = 2 * (q.X * q.Y + q.Z * q.W);
            float m00 = 1 - 2 * (q.Y * q.Y + q.Z * q.Z);

            float y = MathF.Asin(System.Math.Clamp(-m20, -1f, 1f));
            if (MathF.Abs(m20) > 0.9999f) // gimbal lock: fold all roll into Z
            {
                float m01 = 2 * (q.X * q.Y - q.Z * q.W);
                float m11 = 1 - 2 * (q.X * q.X + q.Z * q.Z);
                return new(0f, y, MathF.Atan2(-m01, m11));
            }
            return new(MathF.Atan2(m21, m22), y, MathF.Atan2(m10, m00));
        }

        public Vec3 Rotate(Vec3 v)
        {
            Vec3 u = new(X, Y, Z);
            Vec3 t = new(
                2 * (u.Y * v.Z - u.Z * v.Y),
                2 * (u.Z * v.X - u.X * v.Z),
                2 * (u.X * v.Y - u.Y * v.X));
            Vec3 c = new(
                u.Y * t.Z - u.Z * t.Y,
                u.Z * t.X - u.X * t.Z,
                u.X * t.Y - u.Y * t.X);
            return new(v.X + W * t.X + c.X, v.Y + W * t.Y + c.Y, v.Z + W * t.Z + c.Z);
        }

        public static float Dot(Quaternion a, Quaternion b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;

        public static Quaternion Slerp(Quaternion a, Quaternion b, float t)
        {
            float d = Dot(a, b);
            if (d < 0) { b = new(-b.X, -b.Y, -b.Z, -b.W); d = -d; } // short way around
            if (d > 0.9995f) // nearly parallel: nlerp is fine
                return new Quaternion(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t,
                    a.Z + (b.Z - a.Z) * t, a.W + (b.W - a.W) * t).Normalized;

            float theta = MathF.Acos(d), sinT = MathF.Sin(theta);
            float wa = MathF.Sin((1 - t) * theta) / sinT, wb = MathF.Sin(t * theta) / sinT;
            return new(a.X * wa + b.X * wb, a.Y * wa + b.Y * wb, a.Z * wa + b.Z * wb, a.W * wa + b.W * wb);
        }

        public Matrix4x4 ToMatrix()
        {
            Quaternion q = Normalized;
            float xx = q.X * q.X, yy = q.Y * q.Y, zz = q.Z * q.Z;
            float xy = q.X * q.Y, xz = q.X * q.Z, yz = q.Y * q.Z;
            float wx = q.W * q.X, wy = q.W * q.Y, wz = q.W * q.Z;

            return new Matrix4x4
            {
                M00 = 1 - 2 * (yy + zz), M01 = 2 * (xy - wz),     M02 = 2 * (xz + wy),     M03 = 0,
                M10 = 2 * (xy + wz),     M11 = 1 - 2 * (xx + zz), M12 = 2 * (yz - wx),     M13 = 0,
                M20 = 2 * (xz - wy),     M21 = 2 * (yz + wx),     M22 = 1 - 2 * (xx + yy), M23 = 0,
                M30 = 0, M31 = 0, M32 = 0, M33 = 1
            };
        }

        // Raw 4-float interop (e.g. GPU upload). Layout is x, y, z, w.
        public static explicit operator Vec4(Quaternion q) => new(q.X, q.Y, q.Z, q.W);
        public static explicit operator Quaternion(Vec4 v) => new(v.X, v.Y, v.Z, v.W);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect(float x = 0, float y = 0, float width = 0, float height = 0)
    {
        public float X = x, Y = y, Width = width, Height = height;

        public float Left => X;
        public float Right => X + Width;
        public float Top => Y;
        public float Bottom => Y + Height;
        public Vec2 Center => new(X + Width / 2, Y + Height / 2);

        public bool Contains(Vec2 point) =>
            point.X >= Left && point.X <= Right &&
            point.Y >= Top && point.Y <= Bottom;

        public bool Intersects(Rect other) =>
            Left < other.Right && Right > other.Left &&
            Top < other.Bottom && Bottom > other.Top;

        public Rect Expand(float amount) =>
            new(X - amount, Y - amount, Width + amount * 2, Height + amount * 2);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix3x3
    {
        public float M00, M01, M02;
        public float M10, M11, M12;
        public float M20, M21, M22;

        public static Matrix3x3 Identity => new() { M00 = 1, M11 = 1, M22 = 1 };

        public static Matrix3x3 Translation(float tx, float ty) => new()
        {
            M00 = 1,
            M01 = 0,
            M02 = tx,
            M10 = 0,
            M11 = 1,
            M12 = ty,
            M20 = 0,
            M21 = 0,
            M22 = 1
        };

        public static Matrix3x3 Rotation(float radians)
        {
            float cos = MathF.Cos(radians);
            float sin = MathF.Sin(radians);
            return new()
            {
                M00 = cos,
                M01 = -sin,
                M02 = 0,
                M10 = sin,
                M11 = cos,
                M12 = 0,
                M20 = 0,
                M21 = 0,
                M22 = 1
            };
        }

        public static Matrix3x3 Scale(float sx, float sy) => new()
        {
            M00 = sx,
            M01 = 0,
            M02 = 0,
            M10 = 0,
            M11 = sy,
            M12 = 0,
            M20 = 0,
            M21 = 0,
            M22 = 1
        };

        public static Matrix3x3 operator *(Matrix3x3 a, Matrix3x3 b) => new()
        {
            M00 = a.M00 * b.M00 + a.M01 * b.M10 + a.M02 * b.M20,
            M01 = a.M00 * b.M01 + a.M01 * b.M11 + a.M02 * b.M21,
            M02 = a.M00 * b.M02 + a.M01 * b.M12 + a.M02 * b.M22,

            M10 = a.M10 * b.M00 + a.M11 * b.M10 + a.M12 * b.M20,
            M11 = a.M10 * b.M01 + a.M11 * b.M11 + a.M12 * b.M21,
            M12 = a.M10 * b.M02 + a.M11 * b.M12 + a.M12 * b.M22,

            M20 = a.M20 * b.M00 + a.M21 * b.M10 + a.M22 * b.M20,
            M21 = a.M20 * b.M01 + a.M21 * b.M11 + a.M22 * b.M21,
            M22 = a.M20 * b.M02 + a.M21 * b.M12 + a.M22 * b.M22,
        };

        // Treats Vec2 as a homogeneous point (x, y, 1) so translation is applied
        public static Vec2 operator *(Matrix3x3 m, Vec2 v) => new( // transform point
            m.M00 * v.X + m.M01 * v.Y + m.M02,
            m.M10 * v.X + m.M11 * v.Y + m.M12
        );
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix4x4
    {
        public float M00, M01, M02, M03;
        public float M10, M11, M12, M13;
        public float M20, M21, M22, M23;
        public float M30, M31, M32, M33;

        public static Matrix4x4 Identity => new() { M00 = 1, M11 = 1, M22 = 1, M33 = 1 };

        public static Matrix4x4 Translation(float tx, float ty, float tz) => new()
        {
            M00 = 1, M01 = 0, M02 = 0, M03 = tx,
            M10 = 0, M11 = 1, M12 = 0, M13 = ty,
            M20 = 0, M21 = 0, M22 = 1, M23 = tz,
            M30 = 0, M31 = 0, M32 = 0, M33 = 1
        };

        public static Matrix4x4 Translation(Vec3 v) => Translation(v.X, v.Y, v.Z);

        public static Matrix4x4 Scale(float sx, float sy, float sz) => new()
        {
            M00 = sx, M01 = 0,  M02 = 0,  M03 = 0,
            M10 = 0,  M11 = sy, M12 = 0,  M13 = 0,
            M20 = 0,  M21 = 0,  M22 = sz, M23 = 0,
            M30 = 0,  M31 = 0,  M32 = 0,  M33 = 1
        };

        public static Matrix4x4 Scale(Vec3 v) => Scale(v.X, v.Y, v.Z);

        public static Matrix4x4 RotationX(float radians)
        {
            float c = MathF.Cos(radians);
            float s = MathF.Sin(radians);
            return new()
            {
                M00 = 1, M01 = 0,  M02 = 0,  M03 = 0,
                M10 = 0, M11 = c,  M12 = -s, M13 = 0,
                M20 = 0, M21 = s,  M22 = c,  M23 = 0,
                M30 = 0, M31 = 0,  M32 = 0,  M33 = 1
            };
        }

        public static Matrix4x4 RotationY(float radians)
        {
            float c = MathF.Cos(radians);
            float s = MathF.Sin(radians);
            return new()
            {
                M00 = c,  M01 = 0, M02 = s, M03 = 0,
                M10 = 0,  M11 = 1, M12 = 0, M13 = 0,
                M20 = -s, M21 = 0, M22 = c, M23 = 0,
                M30 = 0,  M31 = 0, M32 = 0, M33 = 1
            };
        }

        public static Matrix4x4 RotationZ(float radians)
        {
            float c = MathF.Cos(radians);
            float s = MathF.Sin(radians);
            return new()
            {
                M00 = c, M01 = -s, M02 = 0, M03 = 0,
                M10 = s, M11 = c,  M12 = 0, M13 = 0,
                M20 = 0, M21 = 0,  M22 = 1, M23 = 0,
                M30 = 0, M31 = 0,  M32 = 0, M33 = 1
            };
        }

        public static Matrix4x4 operator *(Matrix4x4 a, Matrix4x4 b)
        {
            return new Matrix4x4
            {
                M00 = a.M00 * b.M00 + a.M01 * b.M10 + a.M02 * b.M20 + a.M03 * b.M30,
                M01 = a.M00 * b.M01 + a.M01 * b.M11 + a.M02 * b.M21 + a.M03 * b.M31,
                M02 = a.M00 * b.M02 + a.M01 * b.M12 + a.M02 * b.M22 + a.M03 * b.M32,
                M03 = a.M00 * b.M03 + a.M01 * b.M13 + a.M02 * b.M23 + a.M03 * b.M33,

                M10 = a.M10 * b.M00 + a.M11 * b.M10 + a.M12 * b.M20 + a.M13 * b.M30,
                M11 = a.M10 * b.M01 + a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
                M12 = a.M10 * b.M02 + a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,
                M13 = a.M10 * b.M03 + a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33,

                M20 = a.M20 * b.M00 + a.M21 * b.M10 + a.M22 * b.M20 + a.M23 * b.M30,
                M21 = a.M20 * b.M01 + a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
                M22 = a.M20 * b.M02 + a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,
                M23 = a.M20 * b.M03 + a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33,

                M30 = a.M30 * b.M00 + a.M31 * b.M10 + a.M32 * b.M20 + a.M33 * b.M30,
                M31 = a.M30 * b.M01 + a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31,
                M32 = a.M30 * b.M02 + a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32,
                M33 = a.M30 * b.M03 + a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33,
            };
        }
        public static Vec3 WorldPosition(Matrix4x4 w) => new(w.M03, w.M13, w.M23);
        
        public static Vec3 TransformDirection(Matrix4x4 w, Vec3 d) => new Vec3(
            w.M00 * d.X + w.M01 * d.Y + w.M02 * d.Z,
            w.M10 * d.X + w.M11 * d.Y + w.M12 * d.Z,
            w.M20 * d.X + w.M21 * d.Y + w.M22 * d.Z).Normalized;
        
        public static Quaternion ToQuaternion(Matrix4x4 m)
        {
            float trace = m.M00 + m.M11 + m.M22;
            float x, y, z, w;

            if (trace > 0.0f)
            {
                float s = 0.5f / MathF.Sqrt(trace + 1.0f);
                w = 0.25f / s;
                x = (m.M21 - m.M12) * s;
                y = (m.M02 - m.M20) * s;
                z = (m.M10 - m.M01) * s;
            }
            else
            {
                if (m.M00 > m.M11 && m.M00 > m.M22)
                {
                    float s = 2.0f * MathF.Sqrt(1.0f + m.M00 - m.M11 - m.M22);
                    w = (m.M21 - m.M12) / s;
                    x = 0.25f * s;
                    y = (m.M01 + m.M10) / s;
                    z = (m.M02 + m.M20) / s;
                }
                else if (m.M11 > m.M22)
                {
                    float s = 2.0f * MathF.Sqrt(1.0f + m.M11 - m.M00 - m.M22);
                    w = (m.M02 - m.M20) / s;
                    x = (m.M01 + m.M10) / s;
                    y = 0.25f * s;
                    z = (m.M12 + m.M21) / s;
                }
                else
                {
                    float s = 2.0f * MathF.Sqrt(1.0f + m.M22 - m.M00 - m.M11);
                    w = (m.M10 - m.M01) / s;
                    x = (m.M02 + m.M20) / s;
                    y = (m.M12 + m.M21) / s;
                    z = 0.25f * s;
                }
            }
            
            float length = MathF.Sqrt(x * x + y * y + z * z + w * w);
            return new Quaternion(x / length, y / length, z / length, w / length);
        }
    }
}
