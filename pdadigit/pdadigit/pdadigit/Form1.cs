using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;

namespace pdadigit
{
    public partial class Form1 : Form
    {
        TcpClient tcp1;
        byte[] data;
        int LEN = sizeof(int) * 2 / sizeof(byte);

        void XyToData(int X, int Y)
        {
            Debug.Assert(sizeof(int) == 4);

            /*byte[] arrx = BitConverter.GetBytes(X);
            byte[] arry = BitConverter.GetBytes(X);

            for(int i = 0; i < n; i++)
                data;*/
            data[0] = (byte)(X & 0xFF);
            data[1] = (byte)((X & 0xFF00) >> 8);
            data[2] = (byte)((X & 0xFF0000) >> 16);
            data[3] = (byte)((X & 0xFF00000) >> 24);

            data[4] = (byte)(Y & 0xFF);
            data[5] = (byte)((Y & 0xFF00) >> 8);
            data[6] = (byte)((Y & 0xFF0000) >> 16);
            data[7] = (byte)((Y & 0xFF00000) >> 24);
        }

        public Form1()
        {
            InitializeComponent();
            data = new byte[LEN];
            tcp1 = new TcpClient();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //XyToData(e.X, e.Y);
            //try
            //{
            //    tcp1.Connect("klmn", 5555);
            //    this.Text = "connected";
            //}
            //catch
            //{
            //    this.Text = "err connect";
            //}

            //try
            //{
            //    tcp1.Client.Send(data);
            //    this.Text = "sent";
            //}
            //catch
            //{
            //    this.Text = "cant send";
            //}
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            XyToData(e.X, e.Y);
            try
            {
                tcp1.Connect("klmn", 5555);
                this.Text = "connected";
            }
            catch
            {
                this.Text = "err connect";
            }

            try
            {
                tcp1.Client.Send(data);
                this.Text = "sent";
            }
            catch
            {
                this.Text = "cant send";
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }
    }
}