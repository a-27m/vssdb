using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Le__Scout.Properties;
using System.Globalization;

namespace Le__Scout
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = null;
        string connectionStringFormat =
@"Database={0};Data Source={1};Port={2};User Id={3};Password={4}";

        int r_id = -1;
        //        string r_no = -1;
        int q_id = -1;
        float total = -1f;
        NumberFormatInfo numInfo;
        Form formLog;

        string ReceiptNumber
        {
            get
            {
                MySqlDataReader reader = null;
                try
                {
                    reader = new MySqlCommand(string.Format(@"
select r.receipt_no
from r where r.id = {0}
 and r.state = 'proc';", r_id), connection).ExecuteReader();
                    reader.Read();
                    return reader.GetInt32(0).ToString();
                }
                catch
                {
                    return "-- 0 --";
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            numInfo = new NumberFormatInfo();
            numInfo.NumberDecimalSeparator = " грн ";
            numInfo.NumberDecimalDigits = 2;

            try
            {
                for (int i = 0; i < Settings.Default.ColumnsWidths.Count; i++)
                    dgv1.Columns[i].Width = (int)Settings.Default.ColumnsWidths[i];
            }
            catch
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Settings.Default.ShowLog)
                formLog = CreateShowFormLog();

            connectToolStripMenuItem_Click(sender, e);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
            Settings.Default.ShowLog = showLogToolStripMenuItem.Checked;

            //
            int[] widths = new int[dgv1.ColumnCount];
            for (int i = 0; i < widths.Length; i++)
                widths[i] = dgv1.Columns[i].Width;
            Settings.Default.ColumnsWidths = new System.Collections.ArrayList(widths);

            Settings.Default.Save();

            //    try
            if (connection != null)
                connection.Close();
        }

        private Form CreateShowFormLog()
        {
            Form formLog = new Form();
            formLog.SuspendLayout();

            TextBox box = new TextBox();
            box.Dock = DockStyle.Fill;
            box.Multiline = true;
            box.ReadOnly = true;
            box.BackColor = SystemColors.Window;
            box.Name = "box";
            box.ScrollBars = ScrollBars.Both;

            formLog.Controls.Add(box);
            formLog.StartPosition = FormStartPosition.Manual;
            formLog.Location = new Point(0, 0);
            formLog.Size = new Size(500, 300);
            formLog.Text = "Отладочные подробности работы";
            formLog.ResumeLayout();
            formLog.Show();
            formLog.FormClosed += new FormClosedEventHandler(delegate(object sender, FormClosedEventArgs e)
            {
                showLogToolStripMenuItem.Checked = false;
                return;
            });
            formLog.SendToBack();

            return formLog;
        }

        private void PrintLog(string text)
        {
            if (formLog == null)
                return;
            if (formLog.IsDisposed)
                return;

            (formLog.Controls["box"] as TextBox).Text +=
                string.Format("[{0}] {1}{2}",
                DateTime.Now.ToString("HH:MM:ss.fff"), text, Environment.NewLine
                );
        }

        private void propDBConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormPropDbConnection().ShowDialog();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings appSettings = new Settings();
            connection = new MySqlConnection(string.Format(connectionStringFormat,
                "leplus",
                appSettings.DbHostName,
                appSettings.DbHostPort,
                appSettings.DbLogin,
                appSettings.DbPass)
                );

            PrintLog("Trying to open connection...");
            //try
            connection.Open();
            PrintLog("Connection: " + connection.State.ToString());
        }

        private void textBoxCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // this <enter> key meant to be pressed by scaner after code
            if ((e.KeyChar == (char)Keys.Enter) && (textBoxCode.Text.Length > 0))
                Sell(textBoxCode.Text);
        }

        private void newReceipt_Click(object sender, EventArgs e)
        {
            if (r_id != -1)
            {
                PrintLog("[Warning] r_id <> -1");
                // ask to interrupt or complete current receipt
            }

            CallStored_StartSell();
        }

        private void countEndChanging_KeyPress(object sender, KeyPressEventArgs e)
        {/*
            // ?? intended situation: 'count' is in focus, cashier corrects value, 
            // then <enter> pressed by scaner, signaling that the new code starts
            if (e.KeyChar == (char)Keys.Enter)
            {
                //try
                int count = int.Parse(textBoxHowmuch.Text);

                CallStored_Sell(count);

                textBoxCode.Focus();
                textBoxCode.SelectAll();
                PrintLog("focus is passed to the textbox1 on <enter> (" + sender.ToString() + ")");
            }
        */}

        private void complete_Click(object sender, EventArgs e)
        {
            ShowCurrentReceiptPositions();
        }

        private void textBoxCash_TextChanged(object sender, EventArgs e)
        {
            int p;
            p = textBoxCash.SelectionStart;
            try
            {
                textBoxCash.Text = textBoxCash.Text.Replace('.', NumberFormatInfo.CurrentInfo.NumberDecimalSeparator[0]);
                textBoxCash.Text = textBoxCash.Text.Replace(',', NumberFormatInfo.CurrentInfo.NumberDecimalSeparator[0]);
                label8.Text = (float.Parse(textBoxCash.Text) - total).ToString("0.00 коп", numInfo);

            }
            catch (FormatException)
            {
            }
            finally
            {
                textBoxCash.SelectionStart = p;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            menuStrip1.Visible = true;
            linkLabel1.Visible = false;
        }

        private void menuStrip1_MenuDeactivate(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            linkLabel1.Visible = true;
        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showLogToolStripMenuItem.Checked = !showLogToolStripMenuItem.Checked)
            {// need log

                if (formLog == null)
                {
                    formLog = CreateShowFormLog();
                }
                else
                {
                    if (formLog.IsDisposed)
                        formLog = CreateShowFormLog();
                }
            }
            else
            {
                if (formLog == null)
                    return;
                if (formLog.IsDisposed)
                    return;
                formLog.Close();
            }
        }

        private void dgv1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != countDataGridViewTextBoxColumn.Index)
                return;

            // try

            // sell or correct?
            if (q_id == -1)
            {
                CallStored_CorrectW(
                       (int)resche.Rows[e.RowIndex]["q_id"],
                       int.Parse(dgv1[e.ColumnIndex, e.RowIndex].Value.ToString())
                       );
            }
            else
            {
                CallStored_Sell(int.Parse(dgv1[e.ColumnIndex, e.RowIndex].Value.ToString()));
                textBoxCode.Focus();
                textBoxCode.SelectAll();
            }

            q_id = -1;
        }

        private void ShowCurrentReceiptPositions()
        {
            MySqlDataAdapter adapter;
            adapter = new MySqlDataAdapter(qSelectReceiptByRid, connection);
            adapter.SelectCommand.Parameters.AddWithValue("?rid", r_id);

            dataSet1.Tables["resche"].Clear();
            adapter.Fill(dataSet1.Tables["resche"]);
            total = SelectTotalByRid();

            label1.Text = total.ToString("0 грн 00 коп");

            dgv1.DataMember = "resche";
        }

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
            adapter = new MySqlDataAdapter(qSelectWareByCode, connection);
            adapter.SelectCommand.Parameters.AddWithValue("?pcode", code);
            adapter.Fill(tableToFill);

            // TODO: fillschema() only if no schema
            if (dataSet1.Tables["chetab"].Columns.Count == 0)
                adapter.FillSchema(dataSet1.Tables["chetab"], SchemaType.Source);
            tableToFill.PrimaryKey = new DataColumn[] { tableToFill.Columns["id"] };

            int n = tableToFill.Rows.Count;
            q_id = -1;

            #region Determine exact ware q_id
            if (n == 0)
            {
                PrintLog("[Oops] The ware is not found by the code: count(*) == 0");
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
            dataSet1.Tables["chetab"].ImportRow(wareRow);
            dgv1.DataMember = "chetab";

            // Focus on kol-vo
            dgv1.CurrentCell = dgv1["countDataGridViewTextBoxColumn", dgv1.Rows.Count - 1];
            dgv1.BeginEdit(true);
        }

        private void CallStored_StartSell()
        {
            MySqlCommand cmdStartSell = new MySqlCommand("start_sell", connection);
            cmdStartSell.CommandType = CommandType.StoredProcedure;
            cmdStartSell.Parameters.Add("?rv", MySqlDbType.Int32).Direction =
                ParameterDirection.ReturnValue;
            cmdStartSell.ExecuteNonQuery();
            r_id = (int)cmdStartSell.Parameters["?rv"].Value;
            PrintLog("Start_sell returned:" + r_id);

            dgv1.DataMember = "chetab";
            textBoxReceiptNumber.Text = ReceiptNumber;
        }

        private void CallStored_Sell(int count)
        {
            if (r_id == -1)
            {
                CallStored_StartSell();
            }

            MySqlCommand cmdSell = new MySqlCommand("sell", connection);
            cmdSell.CommandType = CommandType.StoredProcedure;
            cmdSell.Parameters.AddWithValue("?q_id", q_id);
            cmdSell.Parameters.AddWithValue("?r_id", r_id);
            cmdSell.Parameters.AddWithValue("?howmuch", count);
            cmdSell.ExecuteNonQuery();
            PrintLog(string.Format("[Call] leplus.sell(q_id = {0}, r_id = {1}, howmuch = {2});",
                q_id, r_id, count));

            q_id = -1;
            ShowCurrentReceiptPositions();
        }

        private void CallStored_CorrectW(int q_id, int howmuch)
        {
            if (r_id == -1)
            {
                throw new Exception("r_id == -1!");
            }

            //try
            MySqlCommand cmd = new MySqlCommand("correctw", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("?qid", q_id);
            cmd.Parameters.AddWithValue("?rid", r_id);
            cmd.Parameters.AddWithValue("?howmuch", howmuch);
            cmd.ExecuteNonQuery();
            PrintLog(string.Format("[Call] leplus.correctw(qid = {0}, rid = {1}, howmuch = {2});",
                q_id, r_id, howmuch));

            q_id = -1;
        }

        private float SelectTotalByRid()
        {
            MySqlCommand cmdSell = new MySqlCommand(qSelectTotalByRid, connection);
            cmdSell.Parameters.AddWithValue("?rid", r_id);
            PrintLog(string.Format("[Query] sum(count*price_rozn) from w, r_id = {0}, returned: {1}",
                r_id, total));

            //try
            return (float)(double)cmdSell.ExecuteScalar();
        }

        #region SELECT queries
        const string qSelectWareByCode = @"
select q.id, q.code, q.name, q.price_rozn, 1 as count
from q
where code=?pcode
";
        const string qSelectReceiptByRid = @"
select w.*
  from w,r
 where w.r_id = r.id
   and r.id = ?rid
   and r.state = 'proc';
";
        const string qSelectTotalByRid = @"
select sum(count*price_rozn)
  from w,r
 where w.r_id = r.id
   and r.id = ?rid
   and r.state = 'proc';
";

        #endregion

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            textBoxReceiptNumber.Text = this.ReceiptNumber;
        }
    }
}
