using System;
using System.Runtime.CompilerServices;

namespace LibTest
{
    public struct Vector2
    {
        public static readonly Vector2 I = new Vector2(1, 0);
        public static readonly Vector2 J = new Vector2(0, 1);
        public static readonly Vector2 Zero = new Vector2(0, 0);

        public readonly double X;
        public readonly double Y;
       
        public double Length => Math.Sqrt(X * X + Y * Y); 


        #region constructors

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector2(double[] vector)
        {
            if (vector.Length !=2) throw new InvalidOperationException();
            X = vector[0];
            Y = vector[1];
        }

        public Vector2(int[] vector)
        {
            if (vector.Length !=2) throw new InvalidOperationException();
            X = vector[0];
            Y = vector[1];
        }

        public Vector2(Vector2 v1)
        {
            X = v1.X;
            Y = v1.Y;
        }
        
        #endregion
        

        #region overrrides

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                        case 0: return X;
                        case 1: return Y;
                        default: throw new IndexOutOfRangeException();
                }
            }
        }
        
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X * v2.X, v1.Y * v2.Y);
        }

        public static Vector2 operator *(Vector2 v1, int a)
        {
            return new Vector2(v1.X * a, v1.Y * a);
        }

        public static Vector2 operator *(int a, Vector2 v1)
        {
            return new Vector2(v1.X * a, v1.Y * a);
        }

        public static Vector2 operator *(Vector2 v1, double a)
        {
            return new Vector2(v1.X * a, v1.Y * a);
        }

        public static Vector2 operator *(double a, Vector2 v1)
        {
            return new Vector2(v1.X * a, v1.Y * a);
        }

        public static Vector2 operator /(Vector2 v1, int a)
        {
            return new Vector2(v1.X / a, v1.Y / a);
        }

        public static Vector2 operator /(Vector2 v1, double a)
        {
            return new Vector2(v1.X / a, v1.Y / a);
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !(v1 == v2);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = (Vector2) obj;
            return this.X == other.X && this.Y == other.Y;
        }
            

        #endregion

        public Vector2 Normalized() => new Vector2(this / Length);

        public Vector2 Normalize() => this = Normalized();
    }
}