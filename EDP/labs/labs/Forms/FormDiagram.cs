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
    public partial class FormDiagram : Form
    {
        Diagram dg;

		public FormDiagram(Diagram.KindOfDiagram kindOfDiagram, params double[] Y)
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
				e.Dispose();
			}
		}

    }
}