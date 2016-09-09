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
        const string CONN_STRING = @"Data Source=ipd8.database.windows.net;Initial Catalog=crm;Integrated Security=False;User ID=ipd8abbott;Password=Abbott2000;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection conn;
        public Database()
        {
            conn = new SqlConnection(CONN_STRING);
            conn.Open();
        }



        //**************************************************************************
        //      EMPLOYEES
        //****************************************************************************
        public List<Employees> GetAllEmployees()
        {
            List<Employees> list = new List<Employees>();
            SqlCommand cmd = new SqlCommand("Select * From Employees", conn);
            using (SqlDataReader reader = cmd.ExecuteReader()) // to escape use too mach memmory, for clean garbage
            {
                if (reader.HasRows)
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
                        Employees em = new Employees
                        {
                            EmployeeId = id,
                            UserName = userName,
                            Password = password,
                            FirstName = firstName,
                            MiddleName = middleName,
                            LastName = lastName,
                            Address = address,
                            Location = location,
                            Country = country,
                            ZipCode = zipCode,
                            DOB = dob,
                            Phone = phone,
                            HireDate = hireDate,
                            PositionID = positionID,
                            DepartmentID = departmentID,
                            Importance = importance,
                            Description = description
                        };
                        list.Add(em);
                    }
                }
            }
            return list;
        }
        public void AddEmployees(Employees em)
        {
            using (SqlCommand cmd = new SqlCommand("Insert Into Employees (UserName, Password, FirstName, MiddleName, LastName, Address, Location, Country, ZipCode, DOB, Phone, HireDate, PositionID, DepartmentID, Importance, Description) VALUES (@userName, @password, @firstName, @middleName, @lastName, @address, @location, @country, @zipCode, @dob, @phone, @hireDate, @positionID, @departmentID, @importance, @description)"))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@userName", em.UserName);
                cmd.Parameters.AddWithValue("@password", em.Password);
                cmd.Parameters.AddWithValue("@firstName", em.FirstName);
                cmd.Parameters.AddWithValue("@middleName", em.MiddleName);
                cmd.Parameters.AddWithValue("@lastName", em.LastName);
                cmd.Parameters.AddWithValue("@address", em.Address);
                cmd.Parameters.AddWithValue("@location", em.Location);
                cmd.Parameters.AddWithValue("@country", em.Country);
                cmd.Parameters.AddWithValue("@zipCode", em.ZipCode);
                cmd.Parameters.AddWithValue("@dob", em.DOB);
                cmd.Parameters.AddWithValue("@phone", em.Phone);
                cmd.Parameters.AddWithValue("@hireDate", em.HireDate);
                cmd.Parameters.AddWithValue("@positionID", em.PositionID);
                cmd.Parameters.AddWithValue("@departmentID", em.DepartmentID);
                cmd.Parameters.AddWithValue("@importance", em.Importance);
                cmd.Parameters.AddWithValue("@description", em.Description);
                cmd.ExecuteNonQuery();
            }
        }
        //**************************************************************************
        //      TASKS
        //****************************************************************************
        public List<Tasks> GetAllTasks()
        {
            List<Tasks> list = new List<Tasks>();
            SqlCommand cmd = new SqlCommand("Select * From Tasks", conn);
            using (SqlDataReader reader = cmd.ExecuteReader()) // to escape use too mach memmory, for clean garbage
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("TaskId"));
                        int employeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
                        string nameTask = reader.GetString(reader.GetOrdinal("NameTask"));
                        string description = reader.GetString(reader.GetOrdinal("Description"));
                        DateTime startDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                        DateTime endDate = reader.GetDateTime(reader.GetOrdinal("EndDate"));
                        string informationNotes = reader.GetString(reader.GetOrdinal("InformationNotes"));
                        string status = reader.GetString(reader.GetOrdinal("Status"));
                        string taskType = reader.GetString(reader.GetOrdinal("TaskType"));
                        string priority = reader.GetString(reader.GetOrdinal("Priority"));
                        string reminder = reader.GetString(reader.GetOrdinal("Reminder"));
                        int clientId = reader.GetInt32(reader.GetOrdinal("ClientId"));

                        Tasks t = new Tasks
                        {
                            TaskId = id,
                            EmployeeId = employeeId,
                            NameTask = nameTask,
                            Description = description,
                            StartDate = startDate,
                            EndDate = endDate,
                            InformationNotes = informationNotes,
                            Status = status,
                            TaskType = taskType,
                            Priority = priority,
                            Reminder = reminder,
                            ClientId = clientId
                        };
                        list.Add(t);
                    }
                }
            }
            return list;
        }

        public List<Tasks> GetTasksByEmployeeId(int Id)
        {
            //throw new NotImplementedException();
            List<Tasks> list = new List<Tasks>();
            SqlCommand cmd = new SqlCommand("Select * From Tasks WHERE EmployeeId=@emId", conn);
            cmd.Parameters.AddWithValue("@emId", Id);
            using (SqlDataReader reader = cmd.ExecuteReader()) // to escape use too mach memmory, for clean garbage
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("TaskId"));
                        int employeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
                        string nameTask = reader.GetString(reader.GetOrdinal("NameTask"));
                        string description = reader.GetString(reader.GetOrdinal("Description"));
                        DateTime startDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                        DateTime endDate = reader.GetDateTime(reader.GetOrdinal("EndDate"));
                        string informationNotes = reader.GetString(reader.GetOrdinal("InformationNotes"));
                        string status = reader.GetString(reader.GetOrdinal("Status"));
                        string taskType = reader.GetString(reader.GetOrdinal("TaskType"));
                        string priority = reader.GetString(reader.GetOrdinal("Priority"));
                        string reminder = reader.GetString(reader.GetOrdinal("Reminder"));
                        int clientId = reader.GetInt32(reader.GetOrdinal("ClientId"));

                        Tasks t = new Tasks
                        {
                            TaskId = id,
                            EmployeeId = employeeId,
                            NameTask = nameTask,
                            Description = description,
                            StartDate = startDate,
                            EndDate = endDate,
                            InformationNotes = informationNotes,
                            Status = status,
                            TaskType = taskType,
                            Priority = priority,
                            Reminder = reminder,
                            ClientId = clientId
                        };
                        list.Add(t);
                    }
                }
            }
            return list;
        }
        public void AddTasks(Tasks t)
        {
            using (SqlCommand cmd = new SqlCommand("Insert Into Tasks (EmployeeId, NameTask, Description, StartDate, EndDate, InformationNotes, Status, TaskType, Priority, Reminder, ClientId) VALUES (@employeeId, @nameTask, @description, @startDate, @endDate, @informationNotes, @status, @taskType, @priority, @reminder, @clientId)"))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@employeeId", t.EmployeeId);
                cmd.Parameters.AddWithValue("@nameTask", t.NameTask);
                cmd.Parameters.AddWithValue("@description", t.Description);
                cmd.Parameters.AddWithValue("@startDate", t.StartDate);
                cmd.Parameters.AddWithValue("@endDate", t.EndDate);
                cmd.Parameters.AddWithValue("@informationNotes", t.InformationNotes);
                cmd.Parameters.AddWithValue("@status", t.Status);
                cmd.Parameters.AddWithValue("@taskType", t.TaskType);
                cmd.Parameters.AddWithValue("@priority", t.Priority);
                cmd.Parameters.AddWithValue("@reminder", t.Reminder);
                cmd.Parameters.AddWithValue("@clientId", t.ClientId);
                cmd.ExecuteNonQuery();
            }
        }
        //**************************************************************************
        //      Clients
        //****************************************************************************
        public List<Clients> GetAllClients()
        {
            List<Clients> list = new List<Clients>();
            SqlCommand cmd = new SqlCommand("Select * From Clients", conn);
            using (SqlDataReader reader = cmd.ExecuteReader()) // to escape use too mach memmory, for clean garbage
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("ClientId"));
                        string clientName = reader.GetString(reader.GetOrdinal("ClientName"));
                        string contactName = reader.GetString(reader.GetOrdinal("ContactName"));
                        string address = reader.GetString(reader.GetOrdinal("Address"));
                        string city = reader.GetString(reader.GetOrdinal("City"));
                        string location = reader.GetString(reader.GetOrdinal("Location"));
                        string country = reader.GetString(reader.GetOrdinal("Country"));
                        string postalCode = reader.GetString(reader.GetOrdinal("PostalCode"));
                        string phone = reader.GetString(reader.GetOrdinal("Phone"));
                        string description = reader.GetString(reader.GetOrdinal("Description"));
                        bool commercial = reader.GetBoolean(reader.GetOrdinal("Commercial"));
                        string fax = reader.GetString(reader.GetOrdinal("Fax"));
                        string email = reader.GetString(reader.GetOrdinal("Email"));
                        string webPage = reader.GetString(reader.GetOrdinal("WebPage"));
                        DateTime firstContacted = reader.GetDateTime(reader.GetOrdinal("FirstContacted"));
                        Clients cl = new Clients
                        {
                            ClientId = id,
                            ClientName = clientName,
                            ContactName = contactName,
                            Address = address,
                            City = city,
                            Location = location,
                            Country = country,
                            PostalCode = postalCode,
                            Phone = phone,
                            Description = description,
                            Commercial = commercial,
                            Fax = fax,
                            Email = email,
                            WebPage = webPage,
                            FirstContacted = firstContacted
                        };
                        list.Add(cl);
                    }
                }
            }
            return list;
        }
        public void AddClients(Clients cl)
        {
            using (SqlCommand cmd = new SqlCommand("Insert Into Clients (ClientName, ContactName, Address, City, Location, Country, PostalCode, Phone, Description, Commercial, Fax, Email,WebPage,FirstContacted) VALUES (@clientName, @contactName, @address, @city, @location, @country, @postalCode, @phone, @description, @commercial, @fax, @email,@webPage,@firstContacted)"))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@clientName", cl.ClientName);
                cmd.Parameters.AddWithValue("@contactName", cl.ContactName);
                cmd.Parameters.AddWithValue("@address", cl.Address);
                cmd.Parameters.AddWithValue("@city", cl.City);
                cmd.Parameters.AddWithValue("@location", cl.Location);
                cmd.Parameters.AddWithValue("@country", cl.Country);
                cmd.Parameters.AddWithValue("@postalCode", cl.PostalCode);
                cmd.Parameters.AddWithValue("@phone", cl.Phone);
                cmd.Parameters.AddWithValue("@description", cl.Description);
                cmd.Parameters.AddWithValue("@commercial", cl.Commercial);
                cmd.Parameters.AddWithValue("@fax", cl.Fax);
                cmd.Parameters.AddWithValue("@email", cl.Email);
                cmd.Parameters.AddWithValue("@webPage", cl.WebPage);
                cmd.Parameters.AddWithValue("@firstContacted", cl.FirstContacted);
                cmd.ExecuteNonQuery();
            }
        }
        //**************************************************************************
        //     
        //****************************************************************************



    }
}
