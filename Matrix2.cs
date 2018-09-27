using System;
using System.Collections.Generic;
using System.Linq;

namespace LibTest
{
    public struct Matrix2
    {
        private readonly Vector2 _v1;
        private readonly Vector2 _v2;
        
        public double Determinant => _v1.X * _v2.Y - _v1.Y * _v2.X;


        #region constructors

        public Matrix2(Vector2 v1, Vector2 v2)
        {
            _v1 = v1;
            _v2 = v2;
        }
        
        public Matrix2(double[][] matrix)
        {
            if (matrix.Any(vector => vector.Length != 2))
                throw new InvalidOperationException();
            
            _v1 = new Vector2(matrix[0]);
            _v2 = new Vector2(matrix[1]);
        }

        public Matrix2(double[,] matrix)
        {
            throw new NotImplementedException();
        }
        
        public Matrix2(int[][] matrix)
        {
            if (matrix.Any(vector => vector.Length != 2))
                throw new InvalidOperationException();
            
            _v1 = new Vector2(matrix[0]);
            _v2 = new Vector2(matrix[1]);;
        }

        public Matrix2(int[,] matrix)
        {
            throw new NotImplementedException();
        }
        
        #endregion
        

        #region overrides

        public Vector2 this[int index]
        {
            get
            {
                switch (index)
                {
                        case 0: return _v1;
                        case 1: return _v2;
                        default: throw new IndexOutOfRangeException();
                }
            }
        }

        public double this[int index, int j]
        {
            get {
                switch (index)
                {
                        case 0: return _v1[j];
                        case 1: return _v2[j];
                        default: throw new IndexOutOfRangeException();
                }
            }
        }

        public static Matrix2 operator +(Matrix2 m1, Matrix2 m2)
        {
            return new Matrix2(m1[0] + m2[0], m1[1] + m2[1]);
        }

        public static Matrix2 operator -(Matrix2 m1, Matrix2 m2)
        {
            return new Matrix2(m1[0] - m2[0], m1[1] - m2[1]);
        }

        public static Matrix2 operator *(Matrix2 m1, double a)
        {
            return new Matrix2(m1[0] * a, m1[1] * a);
        }

        public static Matrix2 operator *(Matrix2 m1, int a)
        {
            return new Matrix2(m1[0] * a, m1[1] * a);
        }

        public static Matrix2 operator *(double a, Matrix2 m1)
        {
            return new Matrix2(m1[0] * a, m1[1] * a);
        }

        public static Matrix2 operator *(int a, Matrix2 m1)
        {
            return new Matrix2(m1[0] * a, m1[1] * a);
        }

        public static Matrix2 operator *(Matrix2 m1, Matrix2 m2)
        {
            var d1 = m1[0][0] * m2[0][0] + m1[0][1] * m2[1][0];
            var d2 = m1[0][0] * m2[0][1] + m1[0][1] * m2[1][1];
            var d3 = m1[1][0] * m2[0][0] + m1[1][1] * m2[1][0];
            var d4 = m1[1][0] * m2[0][1] + m1[1][1] * m2[1][1];

            return new Matrix2(new[] {new[] {d1, d2}, new[] {d3, d4}});
        }   
        
        public override string ToString()
        {
            return $"{_v1}\n{_v2}";
        }

        public override bool Equals(object obj)
        {
            var other = (Matrix2) obj;
            return _v1 == other._v1 && _v2 == other._v2;
        }

        public override int GetHashCode()
        {
            return _v1.GetHashCode() + _v2.GetHashCode();
        }

        #endregion     

        public Matrix2 Transposed()
        {
            return new Matrix2(new Vector2(_v1[0], _v2[0]), new Vector2(_v1[1], _v2[1]));
        }

        public void Transpose() => this = Transposed();

        public Matrix2 Opposite() => Transposed() * (1 / Determinant);
    }
}