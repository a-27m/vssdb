using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;

namespace filespitter
{
    public partial class Form1 : Form
    {
        string fileName = "";
        string targetFolder = "";
        int readBufferSize = 1024 * 1024; // 1 megabyte

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                fileName = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
                targetFolder = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fileInput;
            try
            {
                fileInput = new FileStream(fileName,
                    FileMode.Open,
                    System.Security.AccessControl.FileSystemRights.ReadData,
                    FileShare.Read,
                    readBufferSize,
                    FileOptions.SequentialScan);
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Unable to open file {1},{0}error occured:{2}",
                    System.Environment.NewLine,
                    fileName,
                    exception.Message)
                    );
            }

            byte[] readBuffer = new byte[readBufferSize];
            while (fileInput.CanRead)
            {
                fileInput.BeginRead();
            }
        }
    }
}
