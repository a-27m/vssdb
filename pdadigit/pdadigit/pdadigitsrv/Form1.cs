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
                int x,y;
                x = BitConverter.ToInt32(data, 0);
                y = BitConverter.ToInt32(data, 4);

                if (!firstPacket)
                {
                    int dx, dy;
                    dx = prevX - x;
                    dy = prevY - y;

                    Point xy = Cursor.Position;
                    xy.X += dx;
                    xy.Y += dy;
                    Cursor.Position = xy;
                }

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
