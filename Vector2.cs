using System;
using System.Runtime.CompilerServices;

namespace LibTest
{
    public struct Vector2
    {
        public static readonly Vector2 i = new Vector2(1, 0);
        public static readonly Vector2 j = new Vector2(0, 1);
        private double[] _vector;

        public double X;
        public double Y;
       
        public double Length => Math.Sqrt(X * X + Y * Y);
        

        #region constructors

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
            _vector = new[] {X, Y};
        }

        public Vector2(double[] vector)
        {
            if (vector.Length !=2) throw new InvalidOperationException();
            X = vector[0];
            Y = vector[1];
            _vector = new[] {X, Y};
        }

        public Vector2(int[] vector)
        {
            if (vector.Length !=2) throw new InvalidOperationException();
            X = vector[0];
            Y = vector[1];
            _vector = new[] {X, Y};
        }

        public Vector2(Vector2 v1)
        {
            X = v1.X;
            Y = v1.Y;
            _vector = new[] {X, Y};
        }
        
        #endregion
        

        #region overrrides

        public double this[int index] => _vector[index];
        
        public static Vector2 operator +(Vector2 v1, Vector2 v2) 
            => new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
            => new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        
        
        public static Vector2 operator *(Vector2 v1, Vector2 v2)
            => new Vector2(v1.X * v2.X, v1.Y * v2.Y);

        public static Vector2 operator *(Vector2 v1, int a)
            => new Vector2(v1.X * a, v1.Y * a);
        
        public static Vector2 operator *(int a, Vector2 v1)
            => new Vector2(v1.X * a, v1.Y * a);
        
        public static Vector2 operator *(Vector2 v1, double a)
            => new Vector2(v1.X * a, v1.Y * a);
        
        public static Vector2 operator *(double a, Vector2 v1)
            => new Vector2(v1.X * a, v1.Y * a);
        
                
        public static Vector2 operator /(Vector2 v1, int a)
            => new Vector2(v1.X / a, v1.Y / a);
                
        public static Vector2 operator /(Vector2 v1, double a)
            => new Vector2(v1.X / a, v1.Y / a);


        public static bool operator ==(Vector2 v1, Vector2 v2)
            => v1.X == v2.X && v1.Y == v2.Y;

        public static bool operator !=(Vector2 v1, Vector2 v2) 
            => !(v1 == v2);


        public override string ToString() =>
            "(" + X + ", " + Y + ")";
        
        #endregion

        public Vector2 Normalized()
            => new Vector2(this / Length);

        public Vector2 Normalize()
            => this = Normalized();
    }
}