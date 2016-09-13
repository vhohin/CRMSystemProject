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
    /// <summary>
    /// Interaction logic for NewContact.xaml
    /// </summary>
    public partial class NewContact : Window
    {
        Database db;
        List<Employees> listEmployees;
        List<Clients> listClients;        
        List<string> listEmployeesNames;        
        List<string> listClientsNames;
        List<string> listContactTypeName;
        int contactEmployeeId = 0;
        int contactClientId = 0;
        string contactTypeName = "";
        string contactSubject = "";
        string contactLocation = "";
        string contactOutcome = "";
        string contactActionToDo = "";
        DateTime contactDate;
        public NewContact()
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
            UploadEmployeeNames();
            UploadClientsNames();
            UploadContactType();
            dpContactDate.SelectedDate = DateTime.Now;
        }
        //**********************************************
        //  upload combos
        //**********************************************
        private void UploadEmployeeNames()
        {
            try
            {
                listEmployees = db.GetAllEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }
            listEmployeesNames = new List<string>();
            foreach (Employees line in listEmployees)
            {
                listEmployeesNames.Add(line.FirstName+" "+line.LastName);
            }
            cbEmployeeContactName.ItemsSource = listEmployeesNames;
            cbEmployeeContactName.Items.Refresh();
        }
        private void UploadClientsNames()
        {
            try
            {
                listClients = db.GetAllClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }
            listClientsNames = new List<string>();
            foreach (Clients line in listClients)
            {
                listClientsNames.Add(line.ClientName);
            }
            cbClientContactName.ItemsSource = listClientsNames;
            cbClientContactName.Items.Refresh();
        }
        private void UploadContactType()
        {
            listContactTypeName = new List<string>();
            listContactTypeName.Add("phone");
            listContactTypeName.Add("mail");
            listContactTypeName.Add("meeting");
            listContactTypeName.Add("fax");
            listContactTypeName.Add("skype");
            cbContactType.ItemsSource = listContactTypeName;
            cbContactType.Items.Refresh();
        }
      
        private void cbClientContactName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbClientContactName.SelectedIndex == -1)
            {
                return;
            }
            Clients cl = listClients[cbClientContactName.SelectedIndex];
            contactClientId = cl.ClientId;
        }

        private void cbEmployeeContactName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEmployeeContactName.SelectedIndex == -1)
            {
                return;
            }
            Employees em = listEmployees[cbEmployeeContactName.SelectedIndex];
            contactEmployeeId = em.EmployeeId;
        }

        private void cbContactType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbContactType.SelectedIndex == -1)
            {
                return;
            }
            contactTypeName = cbContactType.SelectedValue.ToString();
        }
        //**********************************************
        //  checking datas
        //**********************************************
        private bool CheckingContactDatas()
        {
            if (cbEmployeeContactName.SelectedIndex == -1)
            {
                return false;
            }
            if (cbClientContactName.SelectedIndex == -1)
            {
                return false;
            }
            if (cbEmployeeContactName.SelectedIndex == -1)
            {
                return false;
            }
            if (tbContactSubject.Text.Length < 2)
            {
                MessageBox.Show("Contact Subject must be completed", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                contactSubject = tbContactSubject.Text;
            }
            if (tbContactLocation.Text.Length > 0)            
            {
                contactLocation = tbContactLocation.Text;
            }
            if (tbContactOutcome.Text.Length < 2)
            {
                MessageBox.Show("Contact Outcome must be completed", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                contactOutcome = tbContactOutcome.Text;
            }
            if (tbContactActionsToDo.Text.Length < 2)
            {
                MessageBox.Show("Contact Actions To Do must be completed", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                contactActionToDo = tbContactActionsToDo.Text;
            }
            contactDate = dpContactDate.SelectedDate.Value;

            return true;
        }

        //**********************************************
        //  click buttons
        //**********************************************
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CheckingContactDatas() == true)//contactEmployeeId
            {
                Contacts co = new Contacts() { EmployeeId = contactEmployeeId, ClientId = contactClientId, ContactType = contactTypeName, Location = contactLocation, ContactDate = contactDate, Subject = contactSubject, Outcome = contactOutcome, ActionsToDo = contactActionToDo };
                try
                {
                    db.AddContacts(co);
                    ClearDatas();
                    MessageBoxResult result = MessageBox.Show("New Client was succesful added. Clear Form?", "Addition", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to add records to database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    // TODO: write details of the exception to log text file
                    Environment.Exit(1);
                }                
            }
        }
        private void ClearDatas()
        {
            contactEmployeeId = 0;
            contactClientId = 0;
            contactTypeName = "";
            contactSubject = "";
            contactLocation = "";
            contactOutcome = "";
            contactActionToDo = "";
            contactDate = DateTime.Now;
        }
        private void ClearForm()
        {
            cbEmployeeContactName.SelectedIndex = -1;
            cbClientContactName.SelectedIndex = -1;
            cbContactType.SelectedIndex = -1;
            tbContactSubject.Text = "";
            tbContactLocation.Text = "";
            tbContactOutcome.Text = "";
            tbContactActionsToDo.Text = "";
            dpContactDate.SelectedDate = DateTime.Now;
        }
        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}
