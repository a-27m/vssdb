using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataProc;

namespace lab1.Forms
{
    public partial class FormSysDiagram : Form
    {
        Diagram dg;

        public List<int> inds;
        public delegate void DrawExternHandler(Graphics g);
        public event DrawExternHandler DrawSrednie;

        public delegate void MouseExternHandler(int index);
        public event MouseExternHandler MouseExtern;

		public FormSysDiagram(Diagram.KindOfDiagram kindOfDiagram, params double[] Y)
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint
				| ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.ResizeRedraw, true);

			if ( Y == null )
				throw new ArgumentNullException("Y");
			if ( Y.Length < 1 )
				throw new ArgumentException("Length of data is zero", "Y");

			Paint += new PaintEventHandler(FormDiagram_Paint);
			Resize += new EventHandler(FormDiagram_Resize);
			dg = new Diagram(this.ClientSize,Y);
			dg.DiagramKind = kindOfDiagram;

            inds = new List<int>();
            dg.indsd = inds;
		}

		void FormDiagram_Resize(object sender, EventArgs e)
		{
			dg.sz = ClientSize;
            Refresh();
		}

		void FormDiagram_Paint(object sender, PaintEventArgs e)
		{
			if ( dg != null )
			{
				dg.Draw(e.Graphics);
                if (DrawSrednie != null)
                    DrawSrednie(e.Graphics);
				e.Dispose();
			}
		}

        private void FormDiagram_MouseClick(object sender, MouseEventArgs e)
        {
            // invert: polyPts[i].X = i * zoom_x + ptMargins.X;
            float i;
            i = e.X - dg.ptMargins.X;
            i /= dg.zoom_x;

            inds.Add((int)i);

            dg.indsd = inds;

            if (MouseExtern != null)
                MouseExtern((int)i);
        }

        private void FormDiagram_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();

        }

        private void FormDiagram_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}