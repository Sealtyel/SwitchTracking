using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchTracking
{
    class DatabaseConnection
    {
        private string sql_string;
        private string strCon;
        System.Data.SqlClient.SqlDataAdapter da_1;


        public string Sql
        {
            set { sql_string = value; }
        }
        public string connection_string
        {
            set { strCon = value; }
        }

        public System.Data.DataSet GetConnection
        {

            get { return MyDataSet(); }

        }

        private System.Data.DataSet MyDataSet()
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(strCon);
            con.Open();
            da_1 = new System.Data.SqlClient.SqlDataAdapter(sql_string, con);
            System.Data.DataSet dat_set = new System.Data.DataSet();
            da_1.Fill(dat_set, "Table_Data_1");

            con.Close();

            return dat_set;

        }


       

    }
}
