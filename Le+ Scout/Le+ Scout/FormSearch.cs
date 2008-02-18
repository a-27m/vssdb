using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Le__Scout
{
    public partial class FormSearch : Form
    {
            DataTable tableToFill;
            MySqlDataAdapter adapter;
        MySqlConnection connection;

        const string qSelectLike = @"
select q.id, q.code, q.name, q.price_rozn
from q
where q.id like '%?pid%'
  and q.code like '%?pcode%'
  and q.name like '%?pname%'
  and q.price_rozn like '%?pprice_rozn%';
";

        public FormSearch(MySqlConnection activeConnection)
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = true;
            this.connection = activeConnection;

            tableToFill = new DataTable("tableToFill");
            tableToFill.PrimaryKey = new DataColumn[] { tableToFill.Columns["id"] };

            adapter = new MySqlDataAdapter(qSelectLike, connection);
            ResetParams();
        }

        private void ResetParams()
        {
            adapter.SelectCommand.Parameters.Clear();
            adapter.SelectCommand.Parameters.AddWithValue("?pid", "");
            adapter.SelectCommand.Parameters.AddWithValue("?pcode", "");
            adapter.SelectCommand.Parameters.AddWithValue("?pname", "");
            adapter.SelectCommand.Parameters.AddWithValue("?pprice_rozn", "");
        }

        void FormSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvData.SelectedRows.Count > 1)
                e.Cancel = true;
        }

        public DataGridView DataGridView1
        {
            get
            {
                return dgvData;
            }
        }

        public int SelectedId
        {
            get
            {
                return (int)dgvData["id", dgvData.SelectedRows[0].Index].Value;
            }
        }


        private void dgvFilter_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string paramName = "?p"+dgvFilter.Columns[e.ColumnIndex].Name;
            adapter.SelectCommand.Parameters[paramName].Value =
                dgvFilter[e.ColumnIndex,e.RowIndex].Value.ToString();
            adapter.Fill(tableToFill);

            int n = tableToFill.Rows.Count;
        }
    }
}