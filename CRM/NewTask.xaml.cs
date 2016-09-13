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
    /// Interaction logic for NewTask.xaml
    /// </summary>
    public partial class NewTask : Window
    {

        Database db;

        //int taskId;
        int employeeId;
        string nameTask = "";
        string description = "";
        DateTime startDate;
        DateTime endDate;
        string informationNotes = "";
        string status = "";
        string taskType = "";
        string priority = "";
        string reminder = "";
        int clientId;
        List<Clients> clientList;
        List<string> clientNamesList;

        List<Employees> employeeList;
        List<string> employeeNamesList;



        public NewTask()
        {

            try
            {
                db = new Database();

            }
            catch (Exception e)
            {
                MessageBox.Show("Fatal error: unable to connect to database" + e.Message, "Fatal error", MessageBoxButton.OK, MessageBoxImage.Stop);
                Environment.Exit(1);
            }
            InitializeComponent();
            UploadClientNames();
            
            UploadEmployeeNames();
           
            dpStartDate.SelectedDate = DateTime.Now;
            dpEndDate.SelectedDate = DateTime.Now;


        } // end NewTask


        // method to upload ClientNames into ComboBox
        private void UploadClientNames()
        {
            try
            {
                clientList = db.GetAllClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }               
            clientNamesList = new List<string>();
            foreach (Clients line in clientList)
            {
                clientNamesList.Add(line.ClientName);
            }
            cbClientList.ItemsSource = clientNamesList;
            cbClientList.Items.Refresh();
            cbClientList.Text = "--Select option--";
        }

        // method to upload EmployeeNames into ComboBox
        private void UploadEmployeeNames()
        {            
            try
            {
                employeeList = db.GetAllEmployees(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }    
            employeeNamesList = new List<string>();
            foreach (Employees line in employeeList)
            {
                employeeNamesList.Add(line.FirstName + " " + line.LastName);
            }
            cbEmployeeList.ItemsSource = employeeNamesList;
            cbEmployeeList.Items.Refresh();
            cbEmployeeList.Text = "--Select option--";
        }


        private void cbTaskType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBoxItem)cbTaskType.SelectedItem).Content;
            if (item == null)
            {
                return;
            }

        }

        private void cbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBoxItem)cbStatus.SelectedItem).Content;
            if (item == null)
            {
                return;
            }

        }

        private void cbPriority_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBoxItem)cbPriority.SelectedItem).Content;
            if (item == null)
            {
                return;
            }

        }

        private void cbReminder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBoxItem)cbReminder.SelectedItem).Content;
            if (item == null)
            {
                return;
            }

        }

        private void cbClientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            foreach (Clients line in clientList)
            {
                if (cbClientList.SelectedItem == line.ClientName)
                {
                    clientId = line.ClientId;
                }
            }
           

        } // end cbClientList_SelectionChanged

        private void cbEmployeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEmployeeList.SelectedIndex == -1)
            {
                return;
            }
            Employees employee = employeeList[cbEmployeeList.SelectedIndex];
            employeeId = employee.EmployeeId;
            //MessageBox.Show("employ id is " + employee.EmployeeId);

        } // end cbEmployeeList_SelectionChanged




        private bool ValidateData()
        {

            if (tbTaskName.Text.Length < 5)
            {
                MessageBox.Show("Task name must be at least 5 characters", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                nameTask = tbTaskName.Text;
            }

           
            startDate = dpStartDate.SelectedDate.Value;
            endDate = dpEndDate.SelectedDate.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("End date must be greater than Start date", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }

            taskType = ((ComboBoxItem)cbTaskType.SelectedItem).Content.ToString();
            if (taskType == "--Select option--")
            {
                MessageBox.Show("Invalid input. Please select a task type", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }

            status = ((ComboBoxItem)cbStatus.SelectedItem).Content.ToString();
            if (status == "--Select option--")
            {
                MessageBox.Show("Invalid input. Please select a status", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }

            priority = ((ComboBoxItem)cbPriority.SelectedItem).Content.ToString();
            if (priority == "--Select option--")
            {
                MessageBox.Show("Invalid input. Please select a priority", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }

            reminder = ((ComboBoxItem)cbReminder.SelectedItem).Content.ToString();
            /*if (reminder == "--Select option--")
            {
                MessageBox.Show("Invalid input. Please select a reminder", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }*/

            if (tbDescription.Text.Length > 0)
            {
                description = tbDescription.Text;
            }

            return true;
        }

        private void ClearAllData()
        {
            nameTask = "";
            description = "";
            DateTime startDate;
            DateTime endDate;
            informationNotes = "";
            status = "";
            taskType = "";
            priority = "";
            reminder = "";

        }

        private void ClearForm()
        {

            cbClientList.Text = "--Select option--";
            cbEmployeeList.Text = "--Select option--";
            tbTaskName.Text = "";
            dpStartDate.SelectedDate = DateTime.Now;
            dpEndDate.SelectedDate = DateTime.Now;
            tbDescription.Text = "";
            cbTaskType.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            cbPriority.SelectedIndex = 0;
            cbReminder.SelectedIndex = 0;


        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {

            if (ValidateData() == true)
            {
               
                Tasks task = new Tasks() { EmployeeId = employeeId, NameTask = nameTask, Description = description, StartDate = startDate, EndDate = endDate, InformationNotes = "", Status = status, TaskType = taskType, Priority = priority, Reminder = reminder, ClientId = clientId };
                try
                {
                    db.AddTasks(task);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    // TODO: write details of the exception to log text file
                    Environment.Exit(1);
                }                
                ClearAllData();
                MessageBoxResult result = MessageBox.Show("New Task was succesfully added. Clear Form?", "Add", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    ClearForm();
                }
            }

        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Clear Form?", "Clear Form", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ClearForm();
                ClearAllData();
            }
        }
    }
}
