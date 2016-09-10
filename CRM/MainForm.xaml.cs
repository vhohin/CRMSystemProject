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
            tblUserName.Text = user;
            if (importance != 0)
            {
                EnterBoss();
            }
            UpdateGridListTasks();
            UpdateGridListClients();
            UpdateGridListEmployees();
        }
        private void EnterBoss()
        { 
        
        }
        //*******************************************************
        //  Update Grid Lists
        //*******************************************************
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
                List<Clients> list = db.GetAllClients();
                dgClientsList.ItemsSource = list;
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
                List<Employees> list = db.GetAllEmployees();
                dgEmployeesList.ItemsSource = list;
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
                tbCommercial.Text = "YES";
            }
            else
            {
                tbCommercial.Text = "NO";
            }
            //rbYesCommercial.IsChecked = false;
            //rbNoCommercial.IsChecked = false;
            tbFirstContact.Text = cl.FirstContacted.ToShortDateString();
            //dpFirstContact.SelectedDate = cl.FirstContacted;
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
            //tbEmployeePosition.Text = cl.Fax;
            //tbEmployeeDepartament.Text = em.DepartmentID;            
            tbEmployeeDOB.Text = em.DOB.ToShortDateString();
            tbEmployeeHireDate.Text = em.HireDate.ToShortDateString();
            tbDescription.Text = em.Description;
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
