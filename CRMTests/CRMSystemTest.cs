using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM;
using NUnit.Framework;

namespace CRMTests
{
    [TestClass]
    public class CRMSystemTest
    {
        [TestMethod]
        public void ClientClassTest()
        {
            //Arrange
            int id = 1;
            string clientName = "BBC";
            string contactName = "John Smitt";
            string address = "35 Fish street";
            string city = "Boston";
            string location = "MN";
            string country = "USA";
            string postalCode = "123";
            string phone = "322-223-3322";
            string description = "Discription";
            bool commercial=true;
            string fax = "322-111-1111";
            string email = "bbc@hotmail.com";
            string webPage = "bbc.com";
            DateTime firstContacted = DateTime.Today;
            Clients cl;
            //Act
            cl = new Clients() { ClientId=id, ClientName = clientName, ContactName = contactName, Address = address, City = city, Location = location, Country = country, PostalCode = postalCode, Phone = phone, Description = description, Commercial = commercial, Fax = fax, Email = email, WebPage = webPage, FirstContacted = firstContacted };
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Boston", cl.City);
        }
        [TestMethod]
        public void EmployeeClassTest()
        {
            //Arrange
            int id = 1;
            string employeeUserName = "bobby";
            string employeePassword = "1234";
            string employeeFirstName = "Bob";
            string employeeMiddleName = "De";
            string employeeLastName = "Delan";
            string employeeAddress = "32 12 Avenue";
            string employeeCity = "Montreal";
            string employeeLocation = "QC";
            string employeeCountry = "Canada";
            string employeePostalCode = "h1h1h1";
            string employeePhone = "514-222-3333";
            string employeeEmail = "bob@mail.ru";
            string employeeDescription = "good boy";
            int employeePositionId = 1;
            int employeeDepartmentID = 1;
            int employeeImportance = 1;
            DateTime employeeDOB = DateTime.Today; ;
            DateTime employeeHireDate = DateTime.Today; 
            Employees em;
            //Act
            em = new Employees() { EmployeeId = id, UserName = employeeUserName, Password = employeePassword, Importance = employeeImportance, FirstName = employeeFirstName, MiddleName = employeeMiddleName, LastName = employeeLastName, Address = employeeAddress, City = employeeCity, Location = employeeLocation, Country = employeeCountry, ZipCode = employeePostalCode, Phone = employeePhone, Description = employeeDescription, Email = employeeEmail, PositionID = employeePositionId, DepartmentID = employeeDepartmentID, DOB = employeeDOB, HireDate = employeeHireDate };
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("1234", em.Password);
        }
        [TestMethod]
        public void ContactsClassTest()
        {
            //Arrange
            int id = 1;
            int contactEmployeeId = 1;
            int contactClientId = 1;
            string contactTypeName = "phone";
            string contactSubject = "sailing phones";
            string contactLocation = "local";
            string contactOutcome = "contract";
            string contactActionToDo = "speak";
            DateTime contactDate = DateTime.Today;
            Contacts co;
            //Act
            co = new Contacts() {ContactId=id, EmployeeId = contactEmployeeId, ClientId = contactClientId, ContactType = contactTypeName, Location = contactLocation, ContactDate = contactDate, Subject = contactSubject, Outcome = contactOutcome, ActionsToDo = contactActionToDo };
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("speak", co.ActionsToDo);
        }
        [TestMethod]
        public void DepartamentClassTest()
        {
            //Arrange
            int id = 1;           
            string departmentName = "Marketing";
            Departaments dp;
            //Act
            dp = new Departaments() { DepartmentId = id, DepartmentName = departmentName};
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Marketing", dp.DepartmentName);
        }
        [TestMethod]
        public void PositionsClassTest()
        {
            //Arrange
            int id = 1;
            string positionName = "Manager";
            Positions po;
            //Act
            po = new Positions() { PositionId = id, PositionName = positionName };
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Manager", po.PositionName);
        }
        [TestMethod]
        public void ProductsClassTest()
        {
            //Arrange
            int id = 1;
            string productType = "phone";
            string productName = "Samsung 5";
            string producerName = "Samsung";
            string model = "Samsung 5-zx";
            string descriprion = "good phone";
            string color = "black";
            double weight = 0.150;
            double unitPrice = 155.55;
            int unitsInStock = 100;
            int customerRating = 5;
            bool discontinued = true;            
            Products pr;
            //Act
            pr = new Products() { ProductId = id, ProductType = productType, ProductName= productName, ProducerName = producerName, Model = model , Descriprion = descriprion, Color= color, Weight= weight, UnitPrice= unitPrice, UnitsInStock= unitsInStock, CustomerRating = customerRating , Discontinued = discontinued };
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Samsung", pr.ProducerName);
        }
        [TestMethod]
        public void TasksClassTest()
        {
            //Arrange
            int id = 1;
            int employeeId=1;
            string nameTask = "BBC contact";
            string description = "about sailing phones";
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today;
            string informationNotes = "informaion";
            string status = "start";
            string taskType = "email";
            string priority = "medium";
            string reminder = "mail";
            int clientId =1;
            Tasks ta;
            //Act
            ta = new Tasks() { EmployeeId = employeeId, NameTask = nameTask, Description = description, StartDate = startDate, EndDate = endDate, InformationNotes = informationNotes, Status = status, TaskType = taskType, Priority = priority, Reminder = reminder, ClientId = clientId };
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("email", ta.TaskType);
        }
        [TestMethod]
        public void DatabaseGetTaskByIdTest()
        {
            //Arrange
            int id = 3;
            string name = "";          
            Database db =new Database();
            Tasks ta;
            //Act
            ta = db.GetTaskById(id);
            name = ta.NameTask;
            //Assert  Meeting with CFO
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Meeting with CFO", name);
        }
        [TestMethod]
        public void DatabaseGetContactsByEmployeeIdTest()
        {
            //Arrange
            int id = 5;
            string outcome = "contract";
            bool exist = false;
            Database db = new Database();            
            //Act
            List<Contacts> list = db.GetContactsByEmployeeId(id);
            foreach (Contacts line in list)
            {
                if (line.Outcome == outcome)
                {
                    exist = true;
                    break;
                }
            }
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(true, exist);
        }
        [TestMethod]
        public void DatabaseGetAllDepartmentsTest()
        {
            //Arrange
            string name = "Purchasing";
            bool exist = false;
            Database db = new Database();
            //Act
            List<Departaments> list = db.GetAllDepartments();
            foreach (Departaments line in list)
            {
                if (line.DepartmentName == name)
                {
                    exist = true;
                    break;
                }
            }
            //Assert  Purchasing
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(true, exist);
        }
    }
}
