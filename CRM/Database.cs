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
        //Data Source=ipd8.database.windows.net;Initial Catalog=crm;Integrated Security=False;User ID=ipd8abbott;Password=Abbott2000;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        const string CONN_STRING = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\BitBuckets\CRMGroupProject\CRM\CRMDB.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection conn;
        public Database()
        {
            conn = new SqlConnection(CONN_STRING);
            conn.Open();
        }

        public List<Employees> GetAllEmployees()
        {
            //throw new NotImplementedException();            
            List<Employees> list = new List<Employees>();
            SqlCommand cmd = new SqlCommand("Select * From Employees", conn);
            using (SqlDataReader reader = cmd.ExecuteReader()) // to escape use too mach memmory, for clean garbage
            {
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
                        string userName = reader.GetString(reader.GetOrdinal("UserName"));
                        string password = reader.GetString(reader.GetOrdinal("Password"));
                        string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        string middleName = reader.GetString(reader.GetOrdinal("MiddleName"));
                        string lastName = reader.GetString(reader.GetOrdinal("LastName"));
                        string address = reader.GetString(reader.GetOrdinal("Address"));
                        string location = reader.GetString(reader.GetOrdinal("Location"));
                        string country = reader.GetString(reader.GetOrdinal("Country"));
                        string zipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
                        DateTime dob = reader.GetDateTime(reader.GetOrdinal("DOB"));
                        string phone = reader.GetString(reader.GetOrdinal("Phone"));
                        DateTime hireDate = reader.GetDateTime(reader.GetOrdinal("HireDate"));
                        int positionID = reader.GetInt32(reader.GetOrdinal("PositionID"));
                        int departmentID = reader.GetInt32(reader.GetOrdinal("DepartmentID"));
                        int importance = reader.GetInt32(reader.GetOrdinal("Importance"));
                        string description = reader.GetString(reader.GetOrdinal("Description"));
                        Employees em = new Employees { EmployeeId = id, FirstName = firstName, MiddleName = middleName
                            , LastName = lastName, Address = address, Location = location, Country = country, ZipCode = zipCode
                            , DOB = dob, Phone = phone, HireDate = hireDate, PositionID = positionID, DepartmentID = departmentID
                            , Importance = importance, Description = description};
                        list.Add(em);
                    }
                }
            }
            return list;
        }
    }
}
