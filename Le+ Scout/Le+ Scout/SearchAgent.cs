using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Le__Scout
{
    public class SearchAgent
    {
        MySqlConnection m_connection;
        DataTable tableToFill;
        MySqlDataAdapter adapter;

        public SearchAgent(MySqlConnection Connection)
        {
            m_connection = Connection;
            tableToFill = new DataTable("tableToFill");
            adapter = new MySqlDataAdapter("", m_connection);
        }

        DataTable Result
        {
            get
            {
                return tableToFill;
            }
        }

        public int ByCode(int code)
        {
            adapter.SelectCommand.CommandText = "select * from q where code = "+code.ToString();
            adapter.Fill(tableToFill);
            return tableToFill.Rows.Count;
        }
    }
}
