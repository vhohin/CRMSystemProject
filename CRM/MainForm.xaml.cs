using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRM
{
    public partial class MainForm : Window
    {
        Database db;
        List<Employees> listEmployee;
        List<string> listEmployeesNames;
        List<Contacts> listContacts;
        List<Clients> listClients;
        List<string> listClientsNames;
        List<Positions> listPositions;
        List<string> listPositionsNames;
        List<Departaments> listDepartments;
        List<string> listDepartmentsNames;
        //client fields
        string clientName = "";
        string contactName = "";
        string address = "";
        string city = "";
        string location = "";
        string country = "";
        string postalCode = "";
        string phone = "";
        string description = "";
        string commercialYN;
        bool commercial;
        string fax = "";
        string email = "";
        string webPage = "";
        DateTime firstContacted;
        int currentClient = 0;
        //employee fields
        string employeeUserName = "";
        string employeePassword = "";
        string employeeFirstName = "";
        string employeeMiddleName = "";
        string employeeLastName = "";
        string employeeAddress = "";
        string employeeCity = "";
        string employeeLocation = "";
        string employeeCountry = "";
        string employeePostalCode = "";
        string employeePhone = "";
        string employeeEmail = "";
        string employeeDescription = "";
        int employeePositionId = 0;
        int employeeDepartmentID = 0;
        int employeeImportance = 0;
        DateTime employeeDOB;
        DateTime employeeHireDate;
        int currentEmployee = 0;
        //contact fields
        List<string> listContactTypeName;
        int contactEmployeeId = 0;
        int contactClientId = 0;
        string contactTypeName = "";
        string contactSubject = "";
        string contactLocation = "";
        string contactOutcome = "";
        string contactActionToDo = "";
        DateTime contactDate;
        bool changeEC = true;
        // products fields
        List<Products> listProducts;
        int productId;
        string productType = "";
        string productName = "";
        string producerName = "";
        string model = "";
        string descriprion = "";
        string color = "";
        double unitPrice = 0;
        double weight = 0;
        int unitsInStock = 1;
        int customerRating = 1;
        string discontinuedYN;
        bool discontinued;
        int currentProduct = 0;

        public MainForm(string user, int importance)
        {
            try
            {
                db = new Database();
            }
            catch (Exception e)
            {
                MessageBox.Show("Fatal error: unable connect to database" + e.Message, "Fatal error", MessageBoxButton.OK, MessageBoxImage.Stop);
                Environment.Exit(1);
            }
            InitializeComponent();
            this.Title = " CRM System User: " + user;
            tblUserName.Text = user;

            tbEmployeeUserName.Visibility = Visibility.Hidden;
            tbEmployeePassword.Visibility = Visibility.Hidden;
            lblEmployeeUserName.Visibility = Visibility.Hidden;
            lblEmployeePassword.Visibility = Visibility.Hidden;            
            if (importance == 0)
                {
                    EnterNoBoss();
                }
            UpdateGridListTasks();
            UpdateGridListContacts();
            UploadContactType();
            UpdateGridListClients();
            UpdateGridListEmployees();
            UpdateGridListPositions();
            UpdateGridListDepartments();
            UploadEmployeePositions();
            UploadEmployeeDepartments();
            UploadEmployeeContactsNames();
            UploadClientsContactsNames();
        }
        private void EnterNoBoss()
        {
            tbEmployeeUserName.Visibility = Visibility.Hidden;
            tbEmployeePassword.Visibility = Visibility.Hidden;
            lblEmployeeUserName.Visibility = Visibility.Hidden;
            lblEmployeePassword.Visibility = Visibility.Hidden;
            btNewEmployee.Visibility = Visibility.Hidden;
            //contacts
            //cbEmployeeContactName.IsReadOnly = true;
            //cbClientContactName.IsReadOnly = true;
            cbContactType.IsReadOnly = true;
            tbContactSubject.IsReadOnly = true;
            tbContactLocation.IsReadOnly = true;
            tbContactOutcome.IsReadOnly = true;
            tbContactActionsToDo.IsReadOnly = true;
            dpContactDate.IsEnabled = false;
            //btUpdateContact.Visibility = Visibility.Hidden;
            //Clients
            tbClientName.IsReadOnly = true;
            tbContactName.IsReadOnly = true;
            tbAddress.IsReadOnly = true;
            tbCity.IsReadOnly = true;
            tbCountry.IsReadOnly = true;
            tbLocation.IsReadOnly = true;
            tbPostalCode.IsReadOnly = true;
            tbLocation.IsReadOnly = true;
            tbPhone.IsReadOnly = true;
            tbFax.IsReadOnly = true;
            tbEmail.IsReadOnly = true;
            tbWeb.IsReadOnly = true;
            tbDescription.IsReadOnly = true;
            rbYesCommercial.IsEnabled = false;
            rbNoCommercial.IsEnabled = false;
            dpFirstContact.IsEnabled = false;
            btClientUpdate.Visibility = Visibility.Hidden;
            //btClientClear.Visibility = Visibility.Hidden;
            btClientDelete.Visibility = Visibility.Hidden;
            //Employees
            tbEmployeeFirstName.IsReadOnly = true;
            tbEmployeeLastName.IsReadOnly = true;
            tbEmployeeAddress.IsReadOnly = true;
            tbEmployeeCity.IsReadOnly = true;
            tbEmployeeCountry.IsReadOnly = true;
            tbEmployeeLocation.IsReadOnly = true;
            tbEmployeePostalCode.IsReadOnly = true;
            tbEmployeeLocation.IsReadOnly = true;
            tbEmployeePhone.IsReadOnly = true;
            tbEmployeeEmail.IsReadOnly = true;
            cbEmployeePositions.IsReadOnly = true;
            cbEmployeeDepartments.IsReadOnly = true;
            tbEmployeeDescription.IsReadOnly = true;
            dpEmployeeDOB.IsEnabled = false;
            dpEmployeeHireDate.IsEnabled = false;
            btEmployeeUpdate.Visibility = Visibility.Hidden;            
            btEmployeeDelete.Visibility = Visibility.Hidden;
            tbEmployeeUserName.Visibility = Visibility.Hidden;
            tbEmployeePassword.Visibility = Visibility.Hidden;
            lblEmployeeUserName.Visibility = Visibility.Hidden;
            lblEmployeePassword.Visibility = Visibility.Hidden;
        }
        //*******************************************************
        //  Update Grid Lists
        //*******************************************************

        // will be Changed******************************************
        private void UpdateGridListTasks()
        {
            try
            {
                List<Tasks> list = db.GetTasksByEmployeeId(2);
                dgTasksList.ItemsSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }
            dgTasksList.Items.Refresh();

        }
        private void UpdateGridListContacts()
        {
            try
            {
                listContacts = db.GetAllContacts();
                dgContactsList.ItemsSource = listContacts;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }
            dgClientsList.Items.Refresh();
        }
        private void UpdateGridListClients()
        {
            try
            {
                listClients = db.GetAllClients();
                dgClientsList.ItemsSource = listClients;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }
            dgClientsList.Items.Refresh();
        }
        private void UpdateGridListEmployees()
        {
            try
            {
                listEmployee = db.GetAllEmployees();
                dgEmployeesList.ItemsSource = listEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }
            dgEmployeesList.Items.Refresh();
        }
        private void UpdateGridListPositions()
        {
            try
            {
                listPositions = db.GetAllPositions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }
            //dgEmployeesList.Items.Refresh();
        }
        private void UpdateGridListDepartments()
        {
            try
            {
                listDepartments = db.GetAllDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }
            //dgEmployeesList.Items.Refresh();
        }

        private void UpdateGridListProducts()
        {
            try
            {
                listProducts = db.GetAllProducts();
                dgProductsList.ItemsSource = listProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }
            dgProductsList.Items.Refresh();
        }



        //*******************************************************
        //  Grid Lists Selections  
        //*******************************************************
        private void dgTasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void dgContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contacts co = dgContactsList.SelectedItem as Contacts;
            if (co == null)
            {                
                return;
            }
            changeEC = false;
            cbEmployeeContactName.SelectedIndex = co.EmployeeId;
            cbClientContactName.SelectedIndex = co.ClientId;
            cbContactType.SelectedValue = co.ContactType;
            tbContactSubject.Text = co.Subject;
            tbContactLocation.Text = co.Location;
            tbContactOutcome.Text = co.Outcome;
            tbContactActionsToDo.Text = co.ActionsToDo;
            dpContactDate.SelectedDate = co.ContactDate;
            changeEC = true;
        }
        private void dgClientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clients cl = dgClientsList.SelectedItem as Clients;
            if (cl == null)
            {
                currentClient = 0;
                return;
            }
            currentClient = cl.ClientId;
            tbClientName.Text = cl.ClientName;
            tbContactName.Text = cl.ContactName;
            tbAddress.Text = cl.Address;
            tbCity.Text = cl.City;
            tbCountry.Text = cl.Country;
            tbLocation.Text = cl.Location;
            tbPostalCode.Text = cl.PostalCode;
            tbPhone.Text = cl.Phone;
            tbFax.Text = cl.Fax;
            tbEmail.Text = cl.Email;
            tbWeb.Text = cl.WebPage;
            tbDescription.Text = cl.Description;
            if (cl.Commercial == true)
            {
                rbYesCommercial.IsChecked = true;
            }
            else
            {
                rbNoCommercial.IsChecked = true;
            }
            dpFirstContact.SelectedDate = cl.FirstContacted;
        }
        private void dgEmployeesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employees em = dgEmployeesList.SelectedItem as Employees;
            if (em == null)
            {
                currentEmployee = 0;
                return;
            }
            currentEmployee = em.EmployeeId;

            tbEmployeeFirstName.Text = em.FirstName;
            tbEmployeeLastName.Text = em.LastName;
            tbEmployeeUserName.Text = em.UserName;
            tbEmployeePassword.Text = em.Password;
            tbEmployeeAddress.Text = em.Address;
            tbEmployeeCity.Text = em.City;
            tbEmployeeCountry.Text = em.Country;
            tbEmployeeLocation.Text = em.Location;
            tbEmployeePostalCode.Text = em.ZipCode;
            tbEmployeePhone.Text = em.Phone;
            tbEmployeeEmail.Text = em.Email;
            cbEmployeePositions.SelectedItem = PositionsToString(em.PositionID);
            cbEmployeeDepartments.SelectedItem = DepartmentToString(em.DepartmentID);
            dpEmployeeDOB.SelectedDate = em.DOB;
            dpEmployeeHireDate.SelectedDate = em.HireDate;
            tbDescription.Text = em.Description;
            employeeImportance = em.Importance;
        }

        private void dgProductsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Products p = dgProductsList.SelectedItem as Products;
            if (p == null)
            {
                currentProduct = 0;
                return;
            }
            currentProduct = p.ProductId;

            tbProductType.Text = p.ProductType;
            tbProducerName.Text = p.ProductName;
            tbModel.Text = p.Model;
            tbColor.Text = p.Color;
            tbWeight.Text = String.Format("{0}",p.Weight);
            tbPricePerItem.Text = String.Format("{0}",p.UnitPrice);
            tbUnitsInStock.Text = String.Format("{0}", p.UnitsInStock);
            tbCustomerRating.Text = String.Format("{0}", p.CustomerRating); ;
            tbProductDescription.Text = p.Descriprion; 

            if (p.Discontinued == true)
            {
                rbYesDiscontinued.IsChecked = true;
            }
            else
            {
                rbNoDiscontinued.IsChecked = true;
            }            
        }
        //*******************************************************
        //  Upploads combos
        //*******************************************************
        private void UploadContactType()
        {
            listContactTypeName = new List<string>();
            listContactTypeName.Add("phone");
            listContactTypeName.Add("mail");
            listContactTypeName.Add("meeting");
            listContactTypeName.Add("fax");
            listContactTypeName.Add("skype");
            listContactTypeName.Add("call");
            cbContactType.ItemsSource = listContactTypeName;
            cbContactType.Items.Refresh();
        }
        private void UploadEmployeeContactsNames()
        {
            /*try
            {
                listEmployeesNames = db.GetAllEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }*/
            listEmployeesNames = new List<string>();
            foreach (Employees line in listEmployee)
            {
                listEmployeesNames.Add(line.FirstName + " " + line.LastName);
            }
            cbEmployeeContactName.ItemsSource = listEmployeesNames;
            cbEmployeeContactName.Items.Refresh();
        }
        private void UploadClientsContactsNames()
        {
            /*try
            {
                listClients = db.GetAllClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }*/
            listClientsNames = new List<string>();
            foreach (Clients line in listClients)
            {
                listClientsNames.Add(line.ClientName);
            }
            cbClientContactName.ItemsSource = listClientsNames;
            cbClientContactName.Items.Refresh();
        }
        private void UploadEmployeePositions()
        {
            listPositionsNames = new List<string>();
            foreach (Positions line in listPositions)
            {
                listPositionsNames.Add(line.PositionName);
            }            
            cbEmployeePositions.ItemsSource = listPositionsNames;
            cbEmployeePositions.Items.Refresh();
        }
        private void UploadEmployeeDepartments()
        {
            listDepartmentsNames = new List<string>();
            foreach (Departaments line in listDepartments)
            {
                listDepartmentsNames.Add(line.DepartmentName);
            }
            cbEmployeeDepartments.ItemsSource = listDepartmentsNames;
            cbEmployeeDepartments.Items.Refresh();
        }

        private void cbEmployeePositions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEmployeePositions.SelectedIndex == -1)
            {
                return;
            }
            Positions p = listPositions[cbEmployeePositions.SelectedIndex];
            employeePositionId = p.PositionId;           
        }
        private void cbEmployeeDepartmets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEmployeeDepartments.SelectedIndex == -1)
            {
                return;
            }
            Departaments d = listDepartments[cbEmployeeDepartments.SelectedIndex];
            employeeDepartmentID = d.DepartmentId;
        }

        //*******************************************************
        //  Positions And Departaments Strings
        //*******************************************************

        private string PositionsToString(int id)
        {
            string positionName = "";
            if (listPositions.Count > 0)
            {
                foreach (Positions p in listPositions)
                    if (p.PositionId == id)
                    {
                        positionName = p.PositionName;
                    }
            }           
            return positionName;
        }
        private string DepartmentToString(int id)
        {
            string departmentName = "";
            if (listDepartments.Count > 0)
            {
                foreach (Departaments d in listDepartments)
                    if (d.DepartmentId == id)
                    {
                        departmentName = d.DepartmentName;
                    }
            }
            return departmentName;
        }
        //*******************************************************
        //  Buttons Clicks
        //*******************************************************

        private void btNewTasks_Click(object sender, RoutedEventArgs e)
        {
            NewTask newTaskWindow = new NewTask();
            newTaskWindow.Owner = this;
            newTaskWindow.Show();

        }
        private void btNewContact_Click(object sender, RoutedEventArgs e)
        {
            NewContact newContactWindow = new NewContact();
            newContactWindow.Owner = this;
            newContactWindow.Show();
        }
        private void btNewClient_Click(object sender, RoutedEventArgs e)
        {
            NewClient addClientWindow = new NewClient();
            addClientWindow.Owner = this;
            addClientWindow.Show();
        }
        private void btNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            NewEmployee addEmployeeWindow = new NewEmployee();
            addEmployeeWindow.Owner = this;
            addEmployeeWindow.Show();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            commercialYN = button.Content.ToString();

        }

        private void btClientUpdate_Click(object sender, RoutedEventArgs e)
        {
            Clients cl = dgClientsList.SelectedItem as Clients;
            if (cl == null)
            {
                currentClient = 0;
                UpdateGridListClients();
                return;
            }
            MessageBoxResult result = MessageBox.Show("Do you want to update client information?", "Updating", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (CheckingClientDatas() == true)
                    {
                        Clients clU = new Clients() {ClientId=cl.ClientId, ClientName = clientName, ContactName = contactName, Address = address, City = city, Location = location, Country = country, PostalCode = postalCode, Phone = phone, Description = description, Commercial = commercial, Fax = fax, Email = email, WebPage = webPage, FirstContacted = firstContacted };
                        db.UpdateClient(clU);
                        MessageBox.Show("Client " + cl.ClientName + " information was succesful updated.", "Updating", MessageBoxButton.OK, MessageBoxImage.Information);
                        ClearFormClients();
                        UpdateGridListClients();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to update client information in database." + ex.Message, "Updating error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    // TODO: write details of the exception to log text file
                    return;
                }
            }
        }

        private void btClientClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFormClients();
        }
        private void btClientDelete_Click(object sender, RoutedEventArgs e)
        {
            Clients cl = dgClientsList.SelectedItem as Clients;
            if (cl == null)
            {
                currentClient = 0;
                return;
            }
            MessageBoxResult result = MessageBox.Show("Do you want to delete client " + cl.ClientName + "?", "Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    db.DeleteClientById(currentClient);
                    MessageBox.Show("Client " + cl.ClientName + " information was succesful deleted.", "Deletion", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFormClients();
                    UpdateGridListClients();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to update client information in database." + ex.Message, "Updating error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    // TODO: write details of the exception to log text file
                    return;
                }
            }
        }
        private void btEmployeeUpdate_Click(object sender, RoutedEventArgs e)
        {
            Employees em = dgEmployeesList.SelectedItem as Employees;
            if (em == null)
            {
                currentClient = 0;
                UpdateGridListEmployees();
                return;
            }
            MessageBoxResult result = MessageBox.Show("Do you want to update emlpoyee "+ em.FirstName + " " + em.LastName + " information?", "Updating", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (CheckingEmployeeDatas() == true)
                    {
                        Employees emU = new Employees() { EmployeeId = em.EmployeeId, UserName= employeeUserName, Password = employeePassword, Importance = employeeImportance, FirstName = employeeFirstName, MiddleName= employeeMiddleName, LastName = employeeLastName, Address = employeeAddress, City = employeeCity, Location = employeeLocation, Country = employeeCountry, ZipCode = employeePostalCode, Phone = employeePhone, Description = employeeDescription,  Email = employeeEmail, PositionID= employeePositionId,DepartmentID= employeeDepartmentID, DOB= employeeDOB, HireDate = employeeHireDate };
                        db.UpdateEmployee(emU);
                        MessageBox.Show("Employee " + emU.FirstName + " " + emU.LastName + " information was succesful updated.", "Updating", MessageBoxButton.OK, MessageBoxImage.Information);
                        ClearFormEmployee();
                        UpdateGridListEmployees();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to update employee information in database." + ex.Message, "Updating error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    // TODO: write details of the exception to log text file
                    return;
                }
            }
        }

        private void btEmployeeClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFormEmployee();
        }
        private void btEmployeeDelete_Click(object sender, RoutedEventArgs e)
        {
            Employees em = dgEmployeesList.SelectedItem as Employees;
            if (em == null)
            {
                currentEmployee = 0;
                return;
            }
            MessageBoxResult result = MessageBox.Show("Do you want to delete employee " + em.FirstName + " " + em.LastName + "?", "Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {                
                try
                {
                    db.DeleteEmployeesById(currentEmployee);
                    MessageBox.Show("Client " + em.FirstName + " " + em.LastName + " information was succesful deleted.", "Deletion", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFormEmployee();
                    UpdateGridListEmployees();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to update client information in database." + ex.Message, "Updating error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    // TODO: write details of the exception to log text file
                    return;
                }
            }
        }

        //*******************************************************
        //  Clears Forms
        //*******************************************************
        private void ClearFormClients()
        {
            tbClientName.Text = "";
            tbContactName.Text = "";
            tbAddress.Text = "";
            tbCity.Text = "";
            tbCountry.Text = "";
            tbLocation.Text = "";
            tbPostalCode.Text = "";
            tbPhone.Text = "";
            tbFax.Text = "";
            tbEmail.Text = "";
            tbWeb.Text = "";
            tbDescription.Text = "";
            rbYesCommercial.IsChecked = false;
            rbNoCommercial.IsChecked = false;
            dpFirstContact.SelectedDate = DateTime.Now;
        }
        private void ClearFormEmployee()
        {
            tbEmployeeFirstName.Text = "";
            tbEmployeeLastName.Text = "";
            tbEmployeeUserName.Text = "";
            tbEmployeePassword.Text = "";
            tbEmployeeAddress.Text = "";
            tbEmployeeCity.Text = "";
            tbEmployeeCountry.Text = "";
            tbEmployeeLocation.Text = "";
            tbEmployeePostalCode.Text = "";
            tbEmployeePhone.Text = "";
            tbEmployeeEmail.Text = "";
            tbEmployeeDescription.Text = "";
            cbEmployeePositions.SelectedIndex = -1;
            cbEmployeeDepartments.SelectedIndex = -1;
            dpEmployeeDOB.SelectedDate = DateTime.Now;
            dpEmployeeHireDate.SelectedDate = DateTime.Now;
        }
        //*******************************************************
        //  Checking Forms
        //*******************************************************
        private bool CheckingClientDatas()
        {
            if (tbClientName.Text.Length < 2)
            {
                MessageBox.Show("Client name must be at least 2 characters", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                clientName = tbClientName.Text;
            }

            if (tbContactName.Text.Length < 2)
            {
                MessageBox.Show("Contact name must be at least 2 characters", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                contactName = tbContactName.Text;
            }

            if (tbAddress.Text.Length < 1)
            {
                MessageBox.Show("Enter Address please", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                address = tbAddress.Text;
            }

            if (tbCity.Text.Length < 1)
            {
                MessageBox.Show("Enter City please", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                city = tbCity.Text;
            }

            if (tbCountry.Text.Length < 1)
            {
                MessageBox.Show("Enter Country please", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                country = tbCountry.Text;
            }

            if (tbLocation.Text.Length > 0)
            {
                location = tbLocation.Text;
            }

            if (tbPostalCode.Text.Length > 0)
            {
                postalCode = tbPostalCode.Text;
            }

            if (tbPhone.Text.Length > 0)
            {
                phone = tbPhone.Text;
            }

            if (tbFax.Text.Length > 0)
            {
                fax = tbFax.Text;
            }

            if (tbEmail.Text.Length > 0)
            {
                email = tbEmail.Text;
            }

            if (tbWeb.Text.Length > 0)
            {
                webPage = tbWeb.Text;
            }

            if (tbDescription.Text.Length > 0)
            {
                description = tbDescription.Text;
            }

            if (commercialYN == "YES")
            {
                commercial = true;
            }
            else if (commercialYN == "NO")
            {
                commercial = false;
            }
            else
            {
                MessageBox.Show("It is commercial client or no?", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            firstContacted = dpFirstContact.SelectedDate.Value;
            return true;
        }
        private bool CheckingEmployeeDatas()
        {
            if (tbEmployeeUserName.Text.Length < 2)
            {
                MessageBox.Show("User name must be at least 2 characters", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                employeeUserName = tbEmployeeUserName.Text;
            }

            if (tbEmployeePassword.Text.Length < 2)
            {
                MessageBox.Show("Password must be at least 2 characters", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                employeePassword = tbEmployeePassword.Text;
            }

            if (tbEmployeeFirstName.Text.Length < 2)
            {
                MessageBox.Show("Employee first name must be at least 2 characters", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                employeeFirstName = tbEmployeeFirstName.Text;
            }

            if (tbEmployeeLastName.Text.Length < 2)
            {
                MessageBox.Show("Employee last name must be at least 2 characters", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                employeeLastName = tbEmployeeLastName.Text;
            }

            if (tbEmployeeAddress.Text.Length < 1)
            {
                MessageBox.Show("Enter Address please", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                employeeAddress = tbEmployeeAddress.Text;
            }

            if (tbEmployeeCity.Text.Length < 1)
            {
                MessageBox.Show("Enter City please", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                employeeCity = tbEmployeeCity.Text;
            }

            if (tbEmployeeCountry.Text.Length < 1)
            {
                MessageBox.Show("Enter Country please", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                employeeCountry = tbEmployeeCountry.Text;
            }

            if (tbEmployeeLocation.Text.Length > 0)
            {
                employeeLocation = tbEmployeeLocation.Text;
            }

            if (tbEmployeePostalCode.Text.Length > 0)
            {
                employeePostalCode = tbEmployeePostalCode.Text;
            }

            if (tbEmployeePhone.Text.Length > 0)
            {
                employeePhone = tbEmployeePhone.Text;
            }            

            if (tbEmployeeEmail.Text.Length > 0)
            {
                employeeEmail = tbEmployeeEmail.Text;
            }            

            if (tbEmployeeDescription.Text.Length > 0)
            {
                employeeDescription = tbEmployeeDescription.Text;
            }
            employeeDOB = dpEmployeeDOB.SelectedDate.Value;
            employeeHireDate = dpEmployeeHireDate.SelectedDate.Value; 
            return true;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        
        private void btProductUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btProductCleal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btProductDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btAllContacts_Click(object sender, RoutedEventArgs e)
        {
            UpdateGridListContacts();
        }

        private void cbClientContactName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (changeEC == false)
            {
                return;
            }
            if (cbClientContactName.SelectedIndex == -1)
            {
                return;
            }
            Clients cl = listClients[cbClientContactName.SelectedIndex];
            contactClientId = cl.ClientId;
            if (cbEmployeeContactName.SelectedIndex == -1)
            {
                try
                {
                    listContacts = db.GetContactsByClientId(contactClientId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    // TODO: write details of the exception to log text file
                    Environment.Exit(1);
                }
            }
            else
            {
                Employees em = listEmployee[cbEmployeeContactName.SelectedIndex];
                contactEmployeeId = em.EmployeeId;
                try
                {
                    listContacts = db.GetContactsByEmployeeAndClientId(contactEmployeeId, contactClientId); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    // TODO: write details of the exception to log text file
                    Environment.Exit(1);
                }
            }
            
            dgContactsList.ItemsSource = listContacts;
            dgContactsList.Items.Refresh();
            
        }

        private void cbEmployeeContactName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (changeEC == false)
            {
                return;
            }
            if (cbEmployeeContactName.SelectedIndex == -1)
            {
                return;
            }
            Employees em = listEmployee[cbEmployeeContactName.SelectedIndex];
            contactEmployeeId = em.EmployeeId;
            if (cbClientContactName.SelectedIndex == -1)
            {
                
                try
                {
                    listContacts = db.GetContactsByEmployeeId(contactEmployeeId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    // TODO: write details of the exception to log text file
                    Environment.Exit(1);
                }
            }
            else
            {                
                Clients cl = listClients[cbClientContactName.SelectedIndex];
                contactClientId = cl.ClientId;
                try
                {
                    listContacts = db.GetContactsByEmployeeAndClientId(contactEmployeeId, contactClientId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    // TODO: write details of the exception to log text file
                    Environment.Exit(1);
                }
            }
            dgContactsList.ItemsSource = listContacts;
            dgContactsList.Items.Refresh();            
        }

        private void cbContactType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }
    }
}
