using System;
using System.Collections.Generic;
using System.Linq;

namespace LibTest
{
    public struct Matrix2
    {
        private Vector2[] _matrix;
        
        public double Determinant 
            => _matrix[0].X * _matrix[1].Y - _matrix[0].Y * _matrix[1].X;

        
        #region constructors

        public Matrix2(Vector2 v1, Vector2 v2)
        {
            _matrix = new[] {v1, v2};
        }
        
        public Matrix2(double[][] matrix)
        {
            if (matrix.Any(vector => vector.Length != 2))
                throw new InvalidOperationException();

            _matrix = new[] {new Vector2(matrix[0]), new Vector2(matrix[1])};
        }

        public Matrix2(double[,] matrix)
        {
            throw new NotImplementedException();
        }
        
        public Matrix2(int[][] matrix)
        {
            if (matrix.Any(vector => vector.Length != 2))
                throw new InvalidOperationException();

            _matrix = new[] {new Vector2(matrix[0]), new Vector2(matrix[1])};
        }

        public Matrix2(int[,] matrix)
        {
            throw new NotImplementedException();
        }
        
        #endregion
        

        #region overrides

        public Vector2 this[int i] => _matrix[i];
        
        public double this[int i, int j] => _matrix[i][j];

        public static Matrix2 operator +(Matrix2 m1, Matrix2 m2)
            => new Matrix2(m1[0] + m2[0], m1[1] + m2[1]);
        
        public static Matrix2 operator -(Matrix2 m1, Matrix2 m2)
            => new Matrix2(m1[0] - m2[0], m1[1] - m2[1]);
        

        public static Matrix2 operator *(Matrix2 m1, double a)
            => new Matrix2(m1[0] * a, m1[1] * a);
        
        public static Matrix2 operator *(Matrix2 m1, int a)
            => new Matrix2(m1[0] * a, m1[1] * a);
        
        public static Matrix2 operator *(double a, Matrix2 m1)
            => new Matrix2(m1[0] * a, m1[1] * a);
        
        public static Matrix2 operator *(int a, Matrix2 m1)
            => new Matrix2(m1[0] * a, m1[1] * a);


        public static Matrix2 operator *(Matrix2 m1, Matrix2 m2)
        {
            var d1 = m1[0][0] * m2[0][0] + m1[0][1] * m2[1][0];
            var d2 = m1[0][0] * m2[0][1] + m1[0][1] * m2[1][1];
            var d3 = m1[1][0] * m2[0][0] + m1[1][1] * m2[1][0];
            var d4 = m1[1][0] * m2[0][1] + m1[1][1] * m2[1][1];

            return new Matrix2(new[] {new[] {d1, d2}, new[] {d3, d4}});
        }
        

        
        public override string ToString()
            => _matrix[0] + "\n" + _matrix[1];
        
        #endregion
        

        public Matrix2 Transposed()
            => new Matrix2(new Vector2(_matrix[0][0], _matrix[1][0]), new Vector2(_matrix[0][1], _matrix[1][1]));
        

        public void Transpose()
            => this = Transposed();


        public Matrix2 Opposite()
            => Transposed() * (1 / Determinant);

        public List<double> GetEigenValues()
        {
            throw new NotImplementedException();
        }
    }
}