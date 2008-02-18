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

        #region Text of the filter's select query 
        const string qSelectLike = @"
select q.id, q.code, q.name, q.price_rozn
  from q
 where q.id like ?pid
   and q.code like ?pcode
   and q.name like ?pname
   and q.price_rozn like ?pprice_rozn;
";
        /*
         where q.id like '%?pid%'
           and q.code like '%?pcode%'
           and q.name like '%?pname%'
           and q.price_rozn like '%?pprice_rozn%';

         */
        #endregion

        public FormSearch(MySqlConnection activeConnection)
        {
            InitializeComponent();
            connection = activeConnection;
            
            tableToFill = new DataTable("tableToFill");
            //tableToFill.PrimaryKey = new DataColumn[] { tableToFill.Columns["id"] };

            //dgvData.AutoGenerateColumns = true;
            dgvData.DataSource = tableToFill;
            
            dgvFilter.Rows.Add();
            dgvFilter.CellValueChanged += new DataGridViewCellEventHandler(dgvFilter_CellValueChanged);

            adapter = new MySqlDataAdapter(qSelectLike, connection);
            ResetQueryParams();
        }

        private void ResetQueryParams()
        {
            adapter.SelectCommand.Parameters.Clear();
            adapter.SelectCommand.Parameters.AddWithValue("?pid", "%");
            adapter.SelectCommand.Parameters.AddWithValue("?pcode", "%");
            adapter.SelectCommand.Parameters.AddWithValue("?pname", "%");
            adapter.SelectCommand.Parameters.AddWithValue("?pprice_rozn", "%");
        }

        void FormSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvData.SelectedRows.Count > 1)
                e.Cancel = true;
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
            string paramName;
            string cellVal;

            paramName= "?p" + dgvFilter.Columns[e.ColumnIndex].DataPropertyName;
            cellVal = dgvFilter[e.ColumnIndex, e.RowIndex].Value.ToString().Trim();
            cellVal = cellVal.Replace('*','%');
            
            if (cellVal == null) 
                cellVal = "%";
            else if (cellVal == "") 
                cellVal = "%";

            try
            {
                adapter.SelectCommand.Parameters[paramName].Value = cellVal;
                adapter.Fill(tableToFill);
            }
            catch
            {
            }

        }
    }
}