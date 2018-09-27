using System;
using System.Linq;


//TODO: Replace array _matrix with separate fields


namespace LibTest
{
    public struct Matrix3
    {
        private Vector3[] _matrix;

        public double Determinant
        {
            get
            {
                var v1 = _matrix[0];
                var v2 = _matrix[1];
                var v3 = _matrix[2];

                var a1 = v2.Y * v3.Z - v2.Z * v3.Y;
                var a2 = v2.X * v3.Z - v2.Z * v3.X;
                var a3 = v2.X * v3.Y - v2.Y * v3.X;

                return v1.X * a1 - v1.Y * a2 + v1.Z * a3;
            }
        }


        #region constructors

        public Matrix3(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            _matrix = new[] {v1, v2, v3};
        }

        public Matrix3(double[][] matrix)
        {
            if (matrix.Any(vector => vector.Length != 3))
                throw new InvalidOperationException();

            _matrix = new[] {new Vector3(matrix[0]), new Vector3(matrix[1]), new Vector3(matrix[2])};
        }

        public Matrix3(double[,] matrix)
        {
            throw new NotImplementedException();
        }

        public Matrix3(int[][] matrix)
        {
            if (matrix.Any(vector => vector.Length != 3))
                throw new InvalidOperationException();

            _matrix = new[] {new Vector3(matrix[0]), new Vector3(matrix[1]), new Vector3(matrix[2])};
        }

        public Matrix3(int[,] matrix)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region overrides

        public Vector3 this[int i] => _matrix[i];
        
        public double this[int i, int j] => _matrix[i][j];
        
        public static Matrix3 operator +(Matrix3 m1, Matrix3 m2)
        {
            return new Matrix3(m1[0] + m2[0], m1[1] + m2[1], m1[2] + m2[2]);
        }

        public static Matrix3 operator -(Matrix3 m1, Matrix3 m2)
        {
            return new Matrix3(m1[0] - m2[0], m1[1] - m2[1], m1[2] - m2[2]);
        }

        public static Matrix3 operator *(Matrix3 m1, double a)
        {
            return new Matrix3(m1[0] * a, m1[1] * a, m1[2] * a);
        }

        public static Matrix3 operator *(Matrix3 m1, int a)
        {
            return new Matrix3(m1[0] * a, m1[1] * a, m1[2] * a);
        }

        public static Matrix3 operator *(double a, Matrix3 m1)
        {
            return new Matrix3(m1[0] * a, m1[1] * a, m1[2] * a);
        }

        public static Matrix3 operator *(int a, Matrix3 m1)
        {
            return new Matrix3(m1[0] * a, m1[1] * a, m1[2] * a);
        }

        public static Matrix3 operator *(Matrix3 m1, Matrix3 m2)
        {
            throw new NotImplementedException();
        }
        
        public override string ToString()
        {
            return $"{_matrix[0]}\n{_matrix[1]}\n{_matrix[2]}";
        }

        #endregion
        
        public Matrix3 Transposed()
        {
            return new Matrix3(new Vector3(_matrix[0][0], _matrix[1][0], _matrix[2][0]),
                               new Vector3(_matrix[0][1], _matrix[1][1], _matrix[2][1]),
                               new Vector3(_matrix[0][2], _matrix[1][2], _matrix[2][2]));
        }


        public void Transpose() => this = Transposed();


        public Matrix3 Opposite() => Transposed() * (1 / Determinant);
    }
}