using System;
using System.Collections.Generic;
using System.Text;

namespace pre3d
{
    public class Matrix
    {
        double[,] m;

        public Matrix(int n, int m)
        {
            this.m = new double[n, m];
        }

        public double[,] Elements
        {
            get { return m; }
            set
            {
                if (value.GetLength(0) != m.GetLength(0) || value.GetLength(1) != m.GetLength(1))
                    throw new ArgumentException();
                m = value;
            }
        }

        public double this[int i, int j]
        {
            get { return m[i, j]; }
            set { m[i, j] = value; }
        }

        public void Transpose() { this.m = Matrix.Transpose(this).m; }
        public static Matrix Transpose(Matrix A)
        {
            int n = A.m.GetLength(0);
            int m = A.m.GetLength(1);

            Matrix C = new Matrix(m, n);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    C[j, i] = A[i, j];

            return C;
        }

        public static Matrix operator *(double λ, Matrix A)
        {
            int n = A.m.GetLength(0);
            int m = A.m.GetLength(1);

            Matrix C = new Matrix(n, m);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    C[i, j] = λ * A[i, j];

            return C;
        }
        public static Matrix operator *(Matrix A, double λ) { return λ * A; }
        public static Matrix operator *(Matrix A, Matrix B)
        {
            int n = A.m.GetLength(0);
            int p1 = A.m.GetLength(1);
            int p2 = B.m.GetLength(0);
            int m = B.m.GetLength(1);

            if (p1 != p2)
                throw new ArgumentException(
                    string.Format("Incorrect matrices sizes: {0}x{1} and {2}x{3}", n, p1, p2, m)
                    );

            Matrix C = new Matrix(n, m);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    for (int k = 0; k < p1; k++)
                        C[i, j] = C[i, j] + A[i, k] * B[k, j];

            return C;
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            int n1 = A.m.GetLength(0);
            int m1 = A.m.GetLength(1);
            int n2 = B.m.GetLength(0);
            int m2 = B.m.GetLength(1);

            if (n1 != n2 || m1 != m2)
            {
                throw new ArgumentException(string.Format("Inequal matrices sizes: {0}x{1} and {2}x{3}", n1, m1, n1, m2));
            }

            Matrix C = new Matrix(n1, m1);

            for (int i = 0; i < n1; i++)
                for (int j = 0; j < m1; j++)
                    C[i, j] = A[i, j] + B[i, j];

            return C;
        }

        public override string ToString()
        {
            string str ="";
                        int n = this.m.GetLength(0);
            int m = this.m.GetLength(1);

            for (int ii = 0; ii < n; ii++)
            {
                for (int jj = 0; jj < m - 1; jj++)
                    str += this.m[ii, jj].ToString("F2") + "  ";
                str += this.m[ii, m - 1].ToString("F2") + "  \r\n";//Environment.NewLine;
            }

            return str;
        }
    }
}
