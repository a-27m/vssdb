using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;
using System.Net;

namespace pdadigitsrv
{
    public partial class Form1 : Form
    {
        TcpClient srvSock;
        TcpListener srvListen;
        IPEndPoint remoteEP;
            byte[] data;

        public Form1()
        {
            InitializeComponent();
            srvListen = new TcpListener(5555);
            srvListen.Start();
            data = new byte[sizeof(int)*2/sizeof(byte)];
            //srvSock = new TcpClient(5555);
            //remoteEP = new IPEndPoint(IPAddress.Any, 0);


            //while (true)
            //{
                /*srvSock.BeginReceive(new AsyncCallback(delegate(IAsyncResult iar)
                    {
                        Debug.Assert(iar.IsCompleted);


                        data = srvSock.EndReceive(iar, ref remoteEP);

                    }
                ), null);
                 */

            //}
        }

        void swap<T>(ref T a, ref T b)
        { T t = a; a = b; b = t; }

        int prevX, prevY;
        private void button1_Click(object sender, EventArgs e)
        {
            srvSock = srvListen.AcceptTcpClient();
            bool firstPacket = true;
            while (true)
            {
                this.Refresh();
                Application.DoEvents();
                srvSock.Client.Receive(data);

                textBox1.Text += string.Format(System.Environment.NewLine + "{1} Received: {0}",
                    Encoding.ASCII.GetString(data),
                    DateTime.Now.ToShortTimeString()
                    );
                int x, y;
                x = data[0] | (data[1] << 8) | (data[2] << 16) | (data[3] << 24);
                y = data[4] | (data[5] << 8) | (data[6] << 16) | (data[7] << 24);
                //x = BitConverter.ToInt32(data, 0);
                //y = BitConverter.ToInt32(data, 4);

                int w, W, h, H;
                w = 320;
                W = 1152;
                h = 240;
                H = 864;

                x = 3 * x;
                y = 3 * y;

                if (x < 0)
                {
                    prevX = -3*x;
                    prevY = -3*y;
                    firstPacket = false;
                    continue;
                }

                if (!firstPacket)
                {
                    int dx, dy;
                    dx = prevX - x;
                    dy = prevY - y;

                    float veloA = 1.0f;
                    Point xy = Cursor.Position;
                    xy.X -= (int)(dx*veloA);
                    xy.Y -= (int)(dy*veloA);
                    Cursor.Position = xy;
                }

                //swap(ref x, ref y);
                //Point xy = Cursor.Position;
                //xy.X = x;
                //xy.Y = y;
                //Cursor.Position = xy;

                prevX = x;
                prevY = y;
                firstPacket = false;
            }

            //data = srvSock.Receive(ref remoteEP);

            //textBox1.Text += string.Format(System.Environment.NewLine + "{3} Received {0} bytes from {1}:{2}",
            //    data.Length,
            //    remoteEP.Address,
            //    remoteEP.Port,
            //    DateTime.Now.ToShortTimeString()
            //    );
        }
    }
}
