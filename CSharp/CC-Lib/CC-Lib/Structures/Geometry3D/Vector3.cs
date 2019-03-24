﻿using System;
using CC_Lib.Structures.Geometry2D;

namespace CC_Lib.Structures.Geometry3D
{
    public struct Vector3 : IComparable<Vector3>, IEquatable<Vector3>
    {
        public Vector3(double x, double y, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #region Properties

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public double SquaredLength => X * X + Y * Y + Z * Z;

        public double Length => Math.Sqrt(SquaredLength);

        public Vector3 Normalized
        {
            get
            {
                var length = Length;
                return new Vector3(X / length, Y / length, Z / length);
            }
        }

        public Vector3 Inverse => new Vector3(-X, -Y, -Z);

        public Vector2 Vector2 => new Vector2(X, Y);

        #endregion

        #region overrides

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"({X} {Y} {Z})";
        }

        public int CompareTo(Vector3 other)
        {
            var xComparison = X.CompareTo(other.X);
            if (xComparison != 0) return xComparison;
            var yComparison = Y.CompareTo(other.Y);
            return yComparison != 0 ? yComparison : Z.CompareTo(other.Z);
        }

        public bool Equals(Vector3 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            return obj.GetType() == GetType() && Equals((Vector3)obj);
        }

        #endregion

        #region methods

        public Vector3 CrossProduct(Vector3 other)
        {
            return new Vector3(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y - other.X);
        }

        #endregion

        #region operators

        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !left.Equals(right);
        }

        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Vector3 operator *(Vector3 left, double k)
        {
            return new Vector3(left.X * k, left.Y * k, left.Z * k);
        }

        public static double operator *(Vector3 left, Vector3 right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
        }

        public static Vector3 operator /(Vector3 left, double k)
        {
            return new Vector3(left.X / k, left.Y / k, left.Z / k);
        }

        public static Vector3 operator +(Vector3 left, Vector2 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z);
        }

        public static Vector3 operator -(Vector3 left, Vector2 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z);
        }

        #endregion
    }
}
