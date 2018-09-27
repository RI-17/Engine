using System;

namespace LibTest
{
    public struct Vector3
    {
        public static readonly Vector3 i = new Vector3(1, 0, 0);
        public static readonly Vector3 j = new Vector3(0, 1, 0);
        public static readonly Vector3 k = new Vector3(0, 0, 1);
        private double[] _vector;

        public double X;
        public double Y;
        public double Z;
       
        public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);
        
        
        #region constructors
        
        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            _vector = new[] {X, Y, Z};
        }
        
        public Vector3(double[] vector)
        {
            if (vector.Length !=3) throw new InvalidOperationException();
            X = vector[0];
            Y = vector[1];
            Z = vector[3];
            _vector = new[] {X, Y, Z};
        }

        public Vector3(int[] vector)
        {
            if (vector.Length !=3) throw new InvalidOperationException();
            X = vector[0];
            Y = vector[1];
            Z = vector[3];
            _vector = new[] {X, Y, Z};
        }

        public Vector3(Vector3 v1)
        {
            X = v1.X;
            Y = v1.Y;
            Z = v1.Z;
            _vector = new[] {X, Y, Z};
        }
        
        #endregion
        
        
        #region overrides

        public double this[int index] => _vector[index];
        
        public static Vector3 operator +(Vector3 v1, Vector3 v2) 
            => new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
            => new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        
        
        public static Vector3 operator *(Vector3 v1, Vector3 v2)
            => new Vector3(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);

        public static Vector3 operator *(Vector3 v1, int a)
            => new Vector3(v1.X * a, v1.Y * a, v1.Z * a);
        
        public static Vector3 operator *(int a, Vector3 v1)
            => new Vector3(v1.X * a, v1.Y * a, v1.Z * a);
        
        public static Vector3 operator *(double a, Vector3 v1)
            => new Vector3(v1.X * a, v1.Y * a, v1.Z * a);
        
        public static Vector3 operator *(Vector3 v1, double a)
            => new Vector3(v1.X * a, v1.Y * a, v1.Z * a);
        
                
        public static Vector3 operator /(Vector3 v1, int a)
            => new Vector3(v1.X / a, v1.Y / a, v1.Z / a);
        
        public static Vector3 operator /(Vector3 v1, double a)
            => new Vector3(v1.X / a, v1.Y / a, v1.Z / a);


        public static bool operator ==(Vector3 v1, Vector3 v2)
            => v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;

        public static bool operator !=(Vector3 v1, Vector3 v2) 
            => !(v1 == v2);


        public override string ToString() =>
            "(" + X + ", " + Y + ", " + Z + ")";
        
        #endregion

        public Vector3 Normalized()
            => new Vector3(this / Length);

        public Vector3 Normalize()
            => this = Normalized();

    }
}