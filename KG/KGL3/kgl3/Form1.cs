using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace pre3d
{
    public partial class Form1 : Form
    {     
        // number of lines inside a rectangle
        const int n = 3;

        // number of topological rectangles
        int a, b;

        // steps
        double H, h, stepU, stepV;

        Matrix U, V;
        Matrix M, Mt, T;
        Matrix B;
        Graphic3D g3d = null, g3dR = null;

        double[][] r;

        int nu; int nv; // curves plot detalization, points per section inside topological rectangle subsquare
        Point3d[][] pts, ptsR;

        public Form1()
        {
            InitializeComponent();

            a = 3;
            b = 3;
            nu = 3;
            nv = 3;
            H = 1.0;
            h = 1.0 / n;
            stepU = h / (double)nu;
            stepV = h / (double)nv;

            U = new Matrix(1, 4);
            V = new Matrix(4, 1);
            M = new Matrix(4, 4);
            M.Elements = new double[4, 4] {
                { 1,  0,  0,  0},
                {-3,  3,  0,  0},
                { 3, -6,  3,  0},
                {-1,  3, -3,  1}};

            Mt = Matrix.Transpose(M);

            B = new Matrix(4, 4);

            // First square is of n*n points any following
            // are (n-1)*(n-1) becouse of using two previous square's sides
            // so that we have r.Len == n+(a-1)*(n-1) == n+a*n-n-a+1 == a*(n-1)+1
            r = new double[a * n + 1][];
            for (int i = 0; i < r.Length; i++)
                r[i] = new double[b * n + 1];

            double u, v;

            for (int i = 0; i < r.Length; i++)
            {
                u = i * h;

                for (int j = 0; j < r[i].Length; j++)
                {
                    v = j * h;
                    //r[i][j] = (i + j) & 1;
                   // r[i][j] = i & 1;
                    r[i][j] = fxy(u, v);
                }
            }

            /*
                string line = "";
                for (int j = 0; j < r[i].Length; j++)
                {
                    line+=r[i][j].ToString("F4") + ";";
                }
                Debug.Print(line);
            }
            */

            SmoothOrder1();

            BuildBeziers();
        }

        private void SmoothOrder1()
        {
            for (int i = n; i < a * n + 1 - 1; i += n)
                for (int j = 0; j < b * n + 1; j++)
                {
                    double r3j_r2j = r[i][j] - r[i - 1][j];

                    r[i + 1][j] = r[i][j] + r3j_r2j;

                }

            for (int j = n; j < b * n + 1 - 1; j += n)
                for (int i = 0; i < a * n + 1; i++)
                {
                    double ri3_ri2 = r[i][j] - r[i][j - 1];

                    r[i][j + 1] = r[i][j] + ri3_ri2;
                }
        }

        void BuildBeziers()
        {
            pts = new Point3d[(a * n) * nu][];
            for (int i = 0; i < pts.Length; i++)
                pts[i] = new Point3d[(b * n) * nv];

            double u, v;

            U.Elements = new double[1, 4];// { { 1, u, u * u, u * u * u } };
            V.Elements = new double[4, 1];// { { 1 }, { v }, { v * v }, { v * v * v } };

            U[0, 0] = 1;
            V[0, 0] = 1;

            for (int ii = 0; ii < a; ii++)
                for (int jj = 0; jj < b; jj++)
                {
                    MakeB(ii, jj, ref B);
                    T = M * B * Mt;

                    for (int i = 0; i < n * nu; i++)
                    {
                        u = i * stepU;
                        U[0, 1] = u;
                        U[0, 2] = u * u;
                        U[0, 3] = U[0, 2] * u;

                        for (int j = 0; j < n * nv; j++)
                        {
                            v = j * stepV;
                            V[1, 0] = v;
                            V[2, 0] = v * v;
                            V[3, 0] = V[2, 0] * v;

                            pts[ii * n * nu + i][jj * n * nv + j] = new Point3d(
                                (float)(u + ii * H),
                                (float)(v + jj * H),
                                (float)(U * T * V)[0, 0]
                                );
                        }
                    }
                }

            r_to_pts();
        }
        void r_to_pts()
        {
            ptsR = new Point3d[r.Length/3+1][];
            for (int i = 0; i < ptsR.Length; i++)
                ptsR[i] = new Point3d[r[i].Length/3+1];

            for (int i = 0; i < ptsR.Length; i++)
            {
                for (int j = 0; j < ptsR[i].Length; j++)
                {
                    ptsR[i][j] = new Point3d(
                        (float)(i*h*3),
                        (float)(j*h*3),
                        (float)(r[i*3][j*3])
                        );
                }
            }
        }
        шел дин выпу
        private void MakeB(int ii, int jj, ref Matrix B)
        {
            for (int i = 0; i <= n; i++)
                for (int j = 0; j <= n; j++)
                    B[i, j] = r[ii*n+i][jj*n+j];
        }

        double fxy(double x, double y)
        {
            // return 0;
            // return x * y / 2f;
            return Math.Sin(x) * Math.Cos(y);
            // return -Math.Sqrt(x * x + y * y) + 4;
            // return x * x * Math.Cos(4*y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //g3d = new Graphic3D(fxy, 0f, 8f, 0f, 8f, (float)h);
            g3d = new Graphic3D(fxy, 0f, 8f, 0f, 8f, (float)stepV);
            g3d.pts = pts;
            g3d.phiV = -45f;
            g3d.phiH = -45f;

            g3dR = new Graphic3D(fxy, 0f, 8f, 0f, 8f, (float)stepV);
            g3dR.pts = ptsR;
            g3dR.phiV = -45f;
            g3dR.phiH = -45f;
            
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (g3d != null)
            {
                g3d.Draw(e.Graphics);
                Text = string.Format("h: {0:f2} deg., v: {1:f2}", g3d.phiH, g3d.phiV);

                if (g3dR != null)
                {
                    g3dR.ox = g3d.ox;
                    g3dR.oy = g3d.oy;

                    g3dR.phiH = g3d.phiH;
                    g3dR.phiV = g3d.phiV;

                    g3dR.zoom = g3d.zoom;

                    g3dR.mx = g3d.mx;
                    g3dR.my = g3d.my;
                    g3dR.mz = g3d.mz;

                    g3dR.Draw(e.Graphics, Wireframe: true, EraseBackground: false);
                    //Text = string.Format("h: {0:f2} deg., v: {1:f2}", g3d.phiH, g3d.phiV);
                }
            }
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            if (g3d != null)
            {
                g3d.ox = pictureBox1.Size.Width / 2f;
                g3d.oy = pictureBox1.Size.Height / 2f;

                Refresh();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            if (g3d == null)
                return;
            if (e.Button == MouseButtons.Right)
            {
                g3d.zoom *= 0.8f;
            }

            Refresh();
             */
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (g3d == null)
                return;

            //if (ctrlKeyPressed)
            //{
            //    g3d.alphaZ += e.Delta / 12;
            //}
            //else
            //{
            //    g3d.alphaX += e.Delta / 12;
            //    g3d.alphaY += e.Delta / 12;
            //}

            //if (ctrlKeyPressed)
            //{
            //    g3d.phiV += e.Delta / 12;
            //}
            //else
            //{
            //    g3d.phiH += e.Delta / 12;
            //}

            // zoom
            if (e.Delta == 0) return;

            g3d.zoom /= (float)Math.Pow(0.8f, Math.Sign(e.Delta));

            Refresh();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        bool ctrlKeyPressed = false;

        private void pictureBox1_KeyDown(object sender, KeyEventArgs e)
        {
            ctrlKeyPressed = e.Control;
        }
        private void pictureBox1_KeyUp(object sender, KeyEventArgs e)
        {
            ctrlKeyPressed = e.Control;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (g3d == null)
                return;
            g3d.mz += ctrlKeyPressed ? -0.1f : 0.1f;
            Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        int mouse_x0, mouse_y0;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouse_x0 = e.X;
                mouse_y0 = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (g3d == null)
                return;
            if (e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - mouse_x0;
                int deltaY = e.Y - mouse_y0;
                if ((deltaX == 0) && (deltaY == 0))
                {
                    // zoom
//                    g3d.zoom /= 0.8f;
                }
                else
                {
                    // rotate
                    g3d.phiH += (mouse_x0 - e.X) / (float)(pictureBox1.Width) * 45;
                    g3d.phiV += (e.Y - mouse_y0) / (float)(pictureBox1.Height) *45;
                    mouse_x0 = e.X;
                    mouse_y0 = e.Y;
                }
                Refresh();
            }
        }
    }
}