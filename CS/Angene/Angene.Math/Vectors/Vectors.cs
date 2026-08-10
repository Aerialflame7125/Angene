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
            a.Z * b.Y - a.Y * b.Z,
            a.X * b.Z - a.Z * b.X,
            a.Y * b.X - a.X * b.Y
        );
        public static Vec3 Lerp(Vec3 a, Vec3 b, float t) => a + (b - a) * t;

        public static Vec3 operator +(Vec3 a, Vec3 b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vec3 operator -(Vec3 a, Vec3 b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vec3 operator *(Vec3 v, float s) => new(v.X * s, v.Y * s, v.Z * s);
        public static Vec3 operator /(Vec3 v, float s) => new(v.X / s, v.Y / s, v.Z / s);
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
    }
}
