using System;
using System.Collections.Generic;
using System.Text;

namespace pre3d
{
    public class Matrix
    {
        double[,] m;

        public double[,] Elements
        {
            get { return m; }
            set { m = value; }
        }

        public double this[int i, int j]
        {
            get { return m[i, j]; }
            set { m[i, j] = value; }
        }

        public Matrix(int n, int m)
        {
            this.m = new double[n, m];
        }
        
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
                        C[i, j] += Convert.ToDouble(A[i, k]) * Convert.ToDouble(B[k, j]);

            return C;
        }
    }
}
