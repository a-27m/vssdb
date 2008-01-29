using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Le__Scout.Properties;

namespace Le__Scout
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = null;
        string connectionStringFormat =
@"Database={0};Data Source={1};Port={2};User Id={3};Password={4}";


        public Form1()
        {
            InitializeComponent();
        }

        private void propDBConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormPropDbConnection().ShowDialog();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings appSettings = new Settings();
            connection = new MySqlConnection( string.Format(connectionStringFormat, 
                "leplus",
                appSettings.DbHostName,
                appSettings.DbHostPort,
                appSettings.DbLogin,
                appSettings.DbPass)
                );

            PrintLog("Connection: " + connection.State.ToString());
            PrintLog("Trying to open...");
            //try
            connection.Open();
            PrintLog("Connection: " + connection.State.ToString());

        }

        private void PrintLog(string text)
        {
            textBoxDebug.Text += string.Format("[{0}] {1}{2}",
                DateTime.Now.ToString("HH:MM:ss.fff"), text, Environment.NewLine
                );
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        //    try

            if (connection != null)
                connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectByCode(textBox1.Text, dataSet1.Tables["chetab"]);

            //MySqlCommand cmd = new MySqlCommand();
            //MySqlParameter p1 = cmd.CreateParameter();
// ...
// create myDataSet and myDataAdapter
// ...
            /*
            select q.id from q where code=?pcode;
            update q set count = (select count-1 from 
            
            */

            PrintLog("ImportRow done");
        }

        private void SelectByCode(string strCode, DataTable tableToFill)
        {
            MySqlCommand command;
            MySqlDataAdapter adapter;

            command = new MySqlCommand(@"select * from q where code=?pcode", connection);
            adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.SelectCommand.Parameters.AddWithValue("?pcode",int.Parse(strCode));
            adapter.SelectCommand.Parameters.Add("?filter", "id > 2");
           /*
          
            adapter.SelectCommand.Parameters.Add("@CategoryName", MySqlDbType.VarChar, 80).Value = "toasters";
            adapter.se.SelectCommand.Parameters.Add("@SerialNum", MySqlDbType.Long).Value = 239;
            adapter.Fill(myDataSet);
            * */

            //DataTable table = new DataTable();
            //adapter.Fill(table);
            adapter.Fill(tableToFill);
            //adapter.FillSchema(dataSet1.Tables["chetab"], SchemaType.Source);
            //dataSet1.Tables["chetab"].LoadDataRow(table.Rows[0].ItemArray, true);

            dataGridView1.AutoResizeColumns();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectToolStripMenuItem_Click(sender, e);
        }
    }
}