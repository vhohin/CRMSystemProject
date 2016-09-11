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
        List<Clients> listClients;
        List<Positions> listPositions;
        List<Departaments> listDepartments;
        string commercialYN="";
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
            this.Title = " CRM System User: "+user;
            tblUserName.Text = user;
            if (importance != 0)
            {
                EnterBoss();
            }
            UpdateGridListTasks();
            UpdateGridListClients();
            UpdateGridListEmployees();
            UpdateGridListPositions();
            UpdateGridListDepartments();
        }
        private void EnterBoss()
        {
            //Clients
            tbClientName.IsReadOnly= false;
            tbContactName.IsReadOnly = false;
            tbAddress.IsReadOnly = false;
            tbCity.IsReadOnly = false;
            tbCountry.IsReadOnly = false;
            tbLocation.IsReadOnly = false;
            tbPostalCode.IsReadOnly = false;
            tbLocation.IsReadOnly = false;
            tbPhone.IsReadOnly = false;
            tbFax.IsReadOnly = false;
            tbEmail.IsReadOnly = false;
            tbWeb.IsReadOnly = false;
            tbDescription.IsReadOnly = false;
            rbYesCommercial.IsEnabled = true;
            rbNoCommercial.IsEnabled = true;
            dpFirstContact.IsEnabled = true;
            btClientUpdate.Visibility = Visibility.Visible;
            btClientClear.Visibility = Visibility.Visible;
            btClientDelete.Visibility = Visibility.Visible;
            //Employees
            tbEmployeeFirstName.IsReadOnly = false;
            tbEmployeeLastName.IsReadOnly = false;
            tbEmployeeAddress.IsReadOnly = false;
            tbEmployeeCity.IsReadOnly = false;
            tbEmployeeCountry.IsReadOnly = false;
            tbEmployeeLocation.IsReadOnly = false;
            tbEmployeePostalCode.IsReadOnly = false;
            tbEmployeeLocation.IsReadOnly = false;
            tbEmployeePhone.IsReadOnly = false;
            tbEmployeePosition.IsReadOnly = false;
            tbEmployeeDepartament.IsReadOnly = false;
            tbEmployeeDescription.IsReadOnly = false;
            dpEmployeeDOB.IsEnabled = true;
            dpEmployeeHireDate.IsEnabled = true;
            btEmployeeUpdate.Visibility = Visibility.Visible;
            btEmployeeClear.Visibility = Visibility.Visible;
            btEmployeeDelete.Visibility = Visibility.Visible;
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
            dgEmployeesList.Items.Refresh();
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
            dgEmployeesList.Items.Refresh();
        }
        //*******************************************************
        //  Grid Lists Selections
        //*******************************************************
        private void dgTasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //int currentClient = 0;
        private void dgClientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clients cl = dgClientsList.SelectedItem as Clients;
            if (cl == null)
            {
                //currentClient = 0;
                return;
            }
            //currentClient = cl.ClientId;
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
                //currentClient = 0;
                return;
            }
            //currentClient = cl.ClientId;
            tbEmployeeFirstName.Text = em.FirstName;
            tbEmployeeLastName.Text = em.LastName;
            tbEmployeeAddress.Text = em.Address;
            tbEmployeeCity.Text = em.City;
            tbEmployeeCountry.Text = em.Country;
            tbEmployeeLocation.Text = em.Location;
            tbEmployeePostalCode.Text = em.ZipCode;
            tbEmployeePhone.Text = em.Phone;
            tbEmployeeEmail.Text = em.Email;
            tbEmployeePosition.Text = PositionsToString(em.PositionID);
            tbEmployeeDepartament.Text = DepartmentToString(em.DepartmentID);
            dpEmployeeDOB.SelectedDate = em.DOB;
            dpEmployeeHireDate.SelectedDate = em.HireDate;           
            tbDescription.Text = em.Description;
        }

        //*******************************************************
        //  Positions And Departaments Strings
        //*******************************************************

        private string PositionsToString(int id)
        {
            string positionName="";
            if (listPositions.Count > 0)
            {
                foreach (Positions p in listPositions)
                    if (p.PositionId == id)
                    {
                        positionName = p.PositionName;
                    }
            }                
            /*try
            {
                positionName = db.GetPositionsById(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                Environment.Exit(1);
            }*/
            return positionName;
        }
        private string DepartmentToString(int id)
        {
            string departmentName = "";
            if (listPositions.Count > 0)
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
            
        }
        private void btNewClient_Click(object sender, RoutedEventArgs e)
        {
            NewClient addClientWindow = new NewClient();
            addClientWindow.Owner = this;
            addClientWindow.Show();
        }
        private void btNewEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            commercialYN = button.Content.ToString();

        }

        private void btClientUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btClientClear_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btClientDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btEmployeeUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btEmployeeClear_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btEmployeeDelete_Click(object sender, RoutedEventArgs e)
        {

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
            //rbYesCommercial.IsChecked = false;
            //rbNoCommercial.IsChecked = false;
            dpFirstContact.SelectedDate = DateTime.Now;
        }
        
    }
}
