using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using pre3d;

namespace ailab2
{
    public partial class Form1 : Form
    {
        private struct ViewParams
        {
            public float phiV, phiH;
            public float zoom;
            public float ox, oy;
        }

        List<Graphic3D> syncList;
        List<Point3dNode>[] chkpntList;
        Point3dNode startPos, finishPos;

        List<Point3dNode> lOpen, lClosed;

        Graphic3D g3d;//, g3dCheckPoints;
        double a, b, c, h;
        int n;
        ViewParams vpr;
        bool SetStartState = false, SetFinishState = false;

        public double gorka(double x, double y)
        {
            double z;

            if (y >= 0)
                z = (1 - x / a - y / c) * h;
            else
                z = (1 - x / a - y / b) * h;

            return z < 0 ? 0 : z;
        }

        public Form1()
        {
            InitializeComponent();

            h = 6;
            a = 9;
            b = -8;
            c = 5;
            n = 5;

            textBoxA.Text = a.ToString("F1");
            textBoxB.Text = b.ToString("F1");
            textBoxC.Text = c.ToString("F1");
            textBoxH.Text = h.ToString("F1");
            textBoxN.Text = n.ToString();

            g3d = new Graphic3D(gorka, 0f, 10f, -10f, 10f, 5e-1f);

            vpr.phiH = 120f;
            vpr.phiV = 105f;
            vpr.zoom = 20;
            vpr.ox = pictureBox1.Width / 2f;
            vpr.oy = pictureBox1.Height / 2f;

            syncList = new List<Graphic3D>();
            syncList.Add(g3d);

            SetupCheckpionts();

            lOpen = new List<Point3dNode>();
            lClosed = new List<Point3dNode>();

            pictureBox1.Refresh();
        }

        private void SetupCheckpionts()
        {
            chkpntList = new List<Point3dNode>[4];
            chkpntList[0] = new List<Point3dNode>();
            chkpntList[1] = new List<Point3dNode>();
            chkpntList[2] = new List<Point3dNode>();
            chkpntList[3] = new List<Point3dNode>();

            //chkpntList.Clear();
            Point3dNode p;

            float dx = (float)a / n;
            for (int i = 0; i < n; i++)
            {
                p = new Point3dNode(i * dx, (float)(-c / a * (i * dx) + c), 0f);
                p.Region = 1;
                chkpntList[0].Add(p);

                p = new Point3dNode(i * dx, (float)(-b / a * (i * dx) + b), 0f);
                p.Region = 2;
                chkpntList[1].Add(p);

                p = new Point3dNode(i * dx, 0f, (float)(-h / a * (i * dx) + h));
                p.Region = 3;
                chkpntList[2].Add(p);
            }

            //chkpntList.Add(new Point3dNode(0f, (float)c, 0f));
            //chkpntList.Add(new Point3dNode(0f, (float)b, 0f));
            //chkpntList.Add(new Point3dNode(0f, 0f, (float)h));
            //chkpntList.Add(new Point3dNode((float)a, 0f, 0f));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (g3d != null)
            {
                SyncViewToGraphics();

                g3d.Draw(e.Graphics);

                float r = 2;
                PointF p2d = new PointF();

                foreach (List<Point3dNode> line in chkpntList)
                    foreach (Point3d p3d in line)
                    {
                        g3d.Project(ref p2d, p3d);
                        e.Graphics.FillEllipse(Brushes.Blue,
                            p2d.X - r / vpr.zoom, p2d.Y - r / vpr.zoom,
                            2 * r / vpr.zoom, 2 * r / vpr.zoom);
                    }

                r = 3;
                if (startPos != null)
                {
                    g3d.Project(ref p2d, startPos);
                    e.Graphics.FillEllipse(Brushes.Green,
                        p2d.X - r / vpr.zoom, p2d.Y - r / vpr.zoom,
                        2 * r / vpr.zoom, 2 * r / vpr.zoom);
                }

                r = 3;
                if (finishPos != null)
                {
                    g3d.Project(ref p2d, finishPos);
                    e.Graphics.FillEllipse(Brushes.Red,
                        p2d.X - r / vpr.zoom, p2d.Y - r / vpr.zoom,
                        2 * r / vpr.zoom, 2 * r / vpr.zoom);
                }

            }
        }

        private void SyncViewToGraphics()
        {
            foreach (Graphic3D g in syncList)
            {
                g.phiH = vpr.phiH;
                g.phiV = vpr.phiV;
                g.zoom = vpr.zoom;
                g.ox = vpr.ox;
                g.oy = vpr.oy;
            }
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            if (g3d == null) return;

            vpr.zoom *= 1.25f;
            pictureBox1.Refresh();
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            if (g3d == null) return;

            vpr.zoom /= 1.25f;
            pictureBox1.Refresh();
        }

        int mouse_x0, mouse_y0;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            {
                mouse_x0 = e.X;
                mouse_y0 = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (g3d == null) return;

            if (e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - mouse_x0;
                int deltaY = e.Y - mouse_y0;

                // rotate
                vpr.phiH += (-deltaX) / (float)(pictureBox1.Width) * 360 * 2; // *45
                vpr.phiV += (deltaY) / (float)(pictureBox1.Height) * 360 * 2;

                mouse_x0 = e.X;
                mouse_y0 = e.Y;

                Refresh();
            }
            if (e.Button == MouseButtons.Right)
            {
                int deltaX = e.X - mouse_x0;
                int deltaY = e.Y - mouse_y0;

                // pan
                vpr.ox += deltaX;
                vpr.oy += deltaY;

                mouse_x0 = e.X;
                mouse_y0 = e.Y;

                Refresh();
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (ReadABCHN() == false) return;

            g3d.ReTabulate(gorka, 0f, 10f, -10f, 10f, 5e-1f, 5e-1f);
            SetupCheckpionts();

            Refresh();
        }

        private bool ReadABCHN()
        {
            errorProvider.Clear();
            try
            {
                a = double.Parse(textBoxA.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textBoxA, "Wrong double number");
                return false;
            }

            try
            {
                b = double.Parse(textBoxB.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textBoxB, "Wrong double number");
                return false;
            }

            try
            {
                c = double.Parse(textBoxC.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textBoxC, "Wrong double number");
                return false;
            }

            try
            {
                h = double.Parse(textBoxH.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textBoxH, "Wrong double number");
                return false;
            }

            int nOld = n;
            try
            {
                n = int.Parse(textBoxN.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textBoxN, "Wrong integer number");
                return false;
            }

            if (n <= 0)
            {
                errorProvider.SetError(textBoxN, "Has to be positive");
                n = nOld;
                return false;
            }

            return true;
        }

        private void checkBoxStart_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStart.Checked)
            {
                Cursor = Cursors.Cross;
                SetStartState = true;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void checkBoxFinish_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFinish.Checked)
            {
                Cursor = Cursors.Cross;
                SetFinishState = true;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!SetStartState && !SetFinishState) return;

            Point3dNode p;

            float eX = (e.X - vpr.ox) / vpr.zoom;
            float eY = (e.Y - vpr.oy) / vpr.zoom;

            double sinPhiH = Graphic3D.sin(vpr.phiH);
            double cosPhiH = Graphic3D.cos(vpr.phiH);
            double sinPhiV = Graphic3D.sin(vpr.phiV);
            double cosPhiV = Graphic3D.cos(vpr.phiV);

            //
            // ex   sinPhiH          -cosPhiH
            // ey   cosPhiH·cosPhiV  sinPhiH·cosPhiV
            //

            double Det = sinPhiH * sinPhiH * cosPhiV + cosPhiH * cosPhiV * cosPhiH;
            double Dx = eX * sinPhiH * cosPhiV + eY * cosPhiH;
            double Dy = sinPhiH * eY - cosPhiH * cosPhiV * eX;

            p = new Point3dNode((float)(Dx / Det), (float)(Dy / Det), 0f);

            Cursor = Cursors.Default;

            if (SetStartState)
            {
                p.Region = 0;
                startPos = p;
                checkBoxStart.Checked = false;
                SetStartState = false;
            }

            if (SetFinishState)
            {
                p.Region = 4;
                finishPos = p;
                checkBoxFinish.Checked = false;
                SetFinishState = false;

                if (chkpntList != null)
                {
                    chkpntList[3].Add(finishPos);
                }
            }

            Refresh();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            lOpen.Clear();
            lClosed.Clear();

            Point3dNode currNode = null;
            bool solved = false, failed = false;

            //1. Поместить все узлы из множества So в список OPEN.
            lOpen.Add(startPos);

            while (!solved && !failed)
            {
                if (lOpen.Count == 0)
                {
                    failed = true;// no solutions
                    break;
                }
                if (lOpen[0] == finishPos)
                {
                    solved = true; // solution is found
                    break;
                }

                if (lOpen[0].Region <= 3) // можно раскрыть
                {  
                    //4. Раскрыть вершину n и все порождённые вершины поместить в список OPEN настроив указатели к вершине n
                    for (int i = 0; i < chkpntList[lOpen[0].Region + 1 - 1].Count; i++)
                    {
                        chkpntList[lOpen[0].Region + 1 - 1][i].Previous = currNode;
                        lOpen.Add(chkpntList[lOpen[0].Region][i]);
                        //5. Если порожденная вершина целевая, т.е. принадлежит Sq то выдать решение с помощью указателей, иначе перейти к шагу №2.
                        if (chkpntList[lOpen[0].Region][i] == finishPos)
                        {
                            solved = true; // solution is found
                            goto brk;
                        }
                    }
                }

                lClosed.Add(lOpen[0]);
                lOpen.RemoveAt(0);
            }
        brk:
            if (solved) MessageBox.Show("solved");
            if (failed) MessageBox.Show("failed");

        }
    }
    public class Point3dNode : Point3d
    {
        public Point3dNode Previous;
        public int Region;

        public Point3dNode(float x, float y, float z)
            : base(x, y, z)
        {
            Previous = null;
            Region = -1;
        }
    }
}
