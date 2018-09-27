using System;

namespace LibTest
{
    public struct Vector3
    {
        public static readonly Vector3 i = new Vector3(1, 0, 0);
        public static readonly Vector3 j = new Vector3(0, 1, 0);
        public static readonly Vector3 k = new Vector3(0, 0, 1);

        public readonly double X;
        public readonly double Y;
        public readonly double Z;
       
        public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);


        #region constructors
        
        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        public Vector3(double[] vector)
        {
            if (vector.Length !=3) throw new InvalidOperationException();
            X = vector[0];
            Y = vector[1];
            Z = vector[3];
        }

        public Vector3(int[] vector)
        {
            if (vector.Length !=3) throw new InvalidOperationException();
            X = vector[0];
            Y = vector[1];
            Z = vector[3];
        }

        public Vector3(Vector3 v1)
        {
            X = v1.X;
            Y = v1.Y;
            Z = v1.Z;
        }
        
        #endregion
        
        
        #region overrides

        public double this[int index]
        {
            get {
                switch (index)
                {
                        case 0: return X;
                        case 1: return Y;
                        case 2: return Z;
                        default: throw new IndexOutOfRangeException();
                }
            }
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector3 operator *(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
        }

        public static Vector3 operator *(Vector3 v1, int a)
        {
            return new Vector3(v1.X * a, v1.Y * a, v1.Z * a);
        }
        
        public static Vector3 operator *(int a, Vector3 v1)
        {
            return new Vector3(v1.X * a, v1.Y * a, v1.Z * a);
        }

        public static Vector3 operator *(double a, Vector3 v1)
        {
            return new Vector3(v1.X * a, v1.Y * a, v1.Z * a);
        }

        public static Vector3 operator *(Vector3 v1, double a)
        {
            return new Vector3(v1.X * a, v1.Y * a, v1.Z * a);
        }

        public static Vector3 operator /(Vector3 v1, int a)
        {
            return new Vector3(v1.X / a, v1.Y / a, v1.Z / a);
        }

        public static Vector3 operator /(Vector3 v1, double a)
        {
            return new Vector3(v1.X / a, v1.Y / a, v1.Z / a);
        }

        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
        }

        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return !(v1 == v2);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
        
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = (Vector3) obj;
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        #endregion

        public Vector3 Normalized() => new Vector3(this / Length);

        public Vector3 Normalize() => this = Normalized();
    }
}