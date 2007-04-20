using System;
using System.Drawing;
using System.Windows.Forms;
using DekartGraphic;

namespace ОСА_Л1
{
    public partial class Form1 : Form
    {
        DekartForm df;

        public Form1()
        {
            InitializeComponent();
            df = new DekartForm(100, 100, 300, 150);
            df.CoodrinateSystemDrawn+=new PaintEventHandler(df_CoodrinateSystemDrawn);
        }

void  df_CoodrinateSystemDrawn(object sender, PaintEventArgs e)
{
    //df.MathGraphicList[0].DrawCoordinateSystem;
    //e.Graphics
}

        private void button1_Click(object sender, EventArgs e)
        {
            //df.Ad
        }
    }
}