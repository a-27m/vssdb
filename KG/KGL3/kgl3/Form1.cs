using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre3d
{
    public partial class Form1 : Form
    {        
        const int n = 4;

        int a, b;
        double H, h;

        Matrix U, V;
        Matrix M, Mt;
        Matrix[,] B;
        Graphic3D g3d, g3dB = null;

        double[][] r;
        Point3d[][] pts;

        public Form1()
        {
            InitializeComponent();

            a = 8;            
            b = 8;
            H = 1.0;
            h = 1.0 / n;

            U = new Matrix(1, 4);
            V = new Matrix(4, 1);
            M = new Matrix(4, 4);
            M.Elements = new double[4, 4] {
                { 1,  0,  0,  0},
                {-3,  3,  0,  0},
                { 3, -6,  3,  0},
                {-1,  3, -3,  1}};

            Mt = Matrix.Transpose(M);

            B = new Matrix[a,b];

            r = null;

            double u, v;

            for (int ii = 0; ii < a; ii++)
                for (int jj = 0; jj < b; jj++)
                {
                    B[ii, jj] = new Matrix(n, n);

                    for (int i = 0; i < n; i++)
                    {
                        u = ii * H + i * h;
 //                       U.Elements = new double[,] { { 1, u, u * u, u * u * u } };

                        for (int j = 0; j < n; j++)
                        {
                            v = jj * H + j * h;
                           // V.Elements = new double[,] { { 1 }, { v }, { v * v }, { v * v * v } };

                            B[ii, jj].Elements[i, j] = fxy(u, v);
                        }
                    }
                }

            CalcR();
        }

        void CalcR()
        {
            //r = new double[a * n][];
            //for (int i = 0; i < a * n; i++)
            //    r[i] = new double[b * n];
            pts = new Point3d[a * n][];
            for (int i = 0; i < a * n; i++)
                pts[i] = new Point3d[b * n];

            double u, v;

            U.Elements = new double[1, 4];// { { 1, u, u * u, u * u * u } };
            V.Elements = new double[4, 1];// { { 1 }, { v }, { v * v }, { v * v * v } };

            for (int ii = 0; ii < a; ii++)
                for (int jj = 0; jj < b; jj++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        u = ii * H + i * h;
                        U[0, 1] = u;
                        U[0, 2] = u * u;
                        U[0, 3] = u * u * u;

                        for (int j = 0; j < n; j++)
                        {
                            v = jj * H + j * h;
                            V[1, 0] = v;
                            V[2, 0] = v * v;
                            V[3, 0] = v * v * v;

                            pts[ii * n + i][jj * n + j] = new Point3d(
                                (float)u,
                                (float)v,
                                (float)(U * M * B[ii, jj] * Mt * V)[0, 0]
                                );
                        }
                    }
                }
        }

        double fxy(double x, double y)
        {
            // return 0;
            // return x * y / 2f;
            return Math.Sin(x) * Math.Cos(y);
            // return -Math.Sqrt(x * x + y * y) + 4;
            //return x * x * Math.Cos(4*y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //g3d = new Graphic3D(fxy, 0f, 8f, 0f, 8f, (float)h);
            g3d = new Graphic3D(fxy, 0f, 0f, 0f, 0f, 1f);
            g3d.pts = pts;
            g3d.phiV = -45f;
            g3d.phiH = -45f;
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (g3d != null)
            {
                g3d.Draw(e.Graphics);
                Text = string.Format("h: {0:f2} deg., v: {1:f2}", g3d.phiH, g3d.phiV);
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
            if (g3d == null)
                return;
            if (e.Button == MouseButtons.Right)
            {
                g3d.zoom *= 0.8f;
            }

            Refresh();
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

            if (ctrlKeyPressed)
            {
                g3d.phiV += e.Delta / 12;
            }
            else
            {
                g3d.phiH += e.Delta / 12;
            }

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
                    g3d.zoom /= 0.8f;
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