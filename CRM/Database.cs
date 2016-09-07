using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRM
{
    class Database
    {
        //
        const string CONN_STRING = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\BitBuckets\CRMGroupProject\CRM\CRMDB.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection conn;
        public Database()
        {
            conn = new SqlConnection(CONN_STRING);
            conn.Open();
        }
    }
}
