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

        int r_id = -1;
        int q_id = -1;

        public Form1()
        {
            InitializeComponent();
            dgv1.AutoGenerateColumns = true;
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

//        private void button1_Click(object sender, EventArgs e)
//        {
//            Sell(textBox1.Text);

//            //MySqlCommand cmd = new MySqlCommand();
//            //MySqlParameter p1 = cmd.CreateParameter();
//// ...
//// create myDataSet and myDataAdapter
//// ...
//            /*
//            select q.id from q where code=?pcode;
//            update q set count = (select count-1 from 
            
//            */

//            PrintLog("ImportRow done");
//        }

        private void Sell(string strCode)
        {
            int code = -1;
            try
            {
                code = int.Parse(strCode);
            }
            catch (FormatException)
            {
                PrintLog("[Error] bad code: Int.Parse threw FormatException");
                return;
            }

            DataTable tableToFill;
            tableToFill = new DataTable("tableToFill");

            MySqlDataAdapter adapter;
            adapter = new MySqlDataAdapter(@"select * from q where code=?pcode", connection);
            adapter.SelectCommand.Parameters.AddWithValue("?pcode", code);
            adapter.Fill(tableToFill);
            // TODO: if no schema
            if (dataSet1.Tables["chetab"].Columns.Count == 0)
                adapter.FillSchema(dataSet1.Tables["chetab"], SchemaType.Source);
            tableToFill.PrimaryKey = new DataColumn[] { tableToFill.Columns["id"] };

            int n = tableToFill.Rows.Count;
            q_id = -1;

            #region Determine exact ware q_id
            if (n == 0)
            {
                PrintLog("[Oops] The ware not found by code: count(*) == 0");
                return;
            }

            if (n > 1)
            {
                FormSearch fs = new FormSearch();
                fs.DataGridView1.DataSource = tableToFill;
                if (fs.ShowDialog() != DialogResult.OK)
                {
                    PrintLog("[Abort] Search canceled (fs.ShowDialog != OK)");
                    return;
                }
                q_id = fs.SelectedId;
                fs.Dispose();
            }
            else
            {
                q_id = (int)tableToFill.Rows[0].ItemArray[0];
            }
            #endregion

            DataRow wareRow = tableToFill.Rows.Find(q_id);
            dataSet1.Tables["chetab"].Rows.Add(wareRow.ItemArray);
            //dgv1.AutoResizeColumns();

            // Focus on kol-vo
            dgv1.Focus();
            dgv1.CurrentCell = dgv1[
                  "count",
                  dgv1.Rows.GetFirstRow(DataGridViewElementStates.Visible)
                  ];
            dgv1.CurrentCell.Value = 1;
            dgv1.BeginEdit(true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectToolStripMenuItem_Click(sender, e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // this <enter> key meant to be pressed by scaner after code
            if (e.KeyChar == (char)Keys.Enter)
            {
                Sell(textBox1.Text);
            }
        }

        private void buttonNewReceipt_Click(object sender, EventArgs e)
        {
            if (r_id != -1)
            {
                PrintLog("[Warning] r_id <> -1");
                // ask to interrupt or complete current receipt
            }

            MySqlCommand cmdStartSell = new MySqlCommand("start_sell", connection);
            cmdStartSell.CommandType = CommandType.StoredProcedure;
            cmdStartSell.Parameters.Add("?rv", MySqlDbType.Int32).Direction =
                ParameterDirection.ReturnValue;
            cmdStartSell.ExecuteNonQuery();
            r_id = (int)cmdStartSell.Parameters["?rv"].Value;
            PrintLog("Start sell returned:" + r_id);

            dgv1.DataMember = "chetab";
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ?? intended situation: cell 'count' is in focus, cashier corrects value, 
            // then <enter> pressed by scaner, signaling that the new code starts
            if (e.KeyChar == (char)Keys.Enter)
            {
                int count = (int)dgv1[
                    "count",
                    dgv1.Rows.GetFirstRow(DataGridViewElementStates.Visible)
                    ].Value;
                CallStored_Sell(count);
                textBox1.SelectAll();
                textBox1.Focus();
                PrintLog("DataGridView1 passed has focus to the textbox1 on <enter>");
            }
        }

        private void CallStored_Sell(int count)
        {
            MySqlCommand cmdSell = new MySqlCommand("sell", connection);
            cmdSell.CommandType = CommandType.StoredProcedure;
            cmdSell.Parameters.AddWithValue("?q_id", q_id);
            cmdSell.Parameters.AddWithValue("?r_id", r_id);
            cmdSell.Parameters.AddWithValue("?howmuch", count);
            cmdSell.ExecuteNonQuery();
            PrintLog(string.Format("[Call] leplus.sell(q_id = {0}, r_id = {1}, howmuch = {2});",
                q_id, r_id, count));
        }

        const string qSelectReceiptByRid = @"
select w.*
from w,r
where w.r_id=r.id
  and r.id=?rid
  and r.state='proc';
";

        private void buttonComplete_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter;
            adapter = new MySqlDataAdapter(qSelectReceiptByRid, connection);
            adapter.SelectCommand.Parameters.AddWithValue("?rid", r_id);

            dataSet1.Tables["resche"].Clear();
            adapter.Fill(dataSet1.Tables["resche"]);
            int sumReceipt = CallStored_TotalByReceipt();

            label1.Text = sumReceipt.ToString();

            dgv1.DataMember = "resche";            
        }
    }
}