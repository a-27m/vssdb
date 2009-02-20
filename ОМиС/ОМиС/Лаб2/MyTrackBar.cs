using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Лаб2
{
    public partial class MyTrackBar : TrackBar
    {
        public MyTrackBar()
            : base()
        {
            InitializeComponent();
        }

        Form1.ScaleParams ps;

        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            e.Graphics.DrawString(ps.S0.ToString(),
                new Font("Arial", FontHeight),
                Brushes.Black,
                10f, 10f);
        }
    }
}
