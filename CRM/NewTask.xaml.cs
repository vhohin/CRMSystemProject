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
            clientList = db.GetAllClients();
            clientNamesList = new List<string>();
            foreach (Clients line in clientList)
            {
                clientNamesList.Add(line.ClientName);
            }
            cbClientList.ItemsSource = clientNamesList;
            cbClientList.Items.Refresh();
        }

        // method to upload EmployeeNames into ComboBox
        private void UploadEmployeeNames()
        {
            employeeList = db.GetAllEmployees();
            employeeNamesList = new List<string>();
            foreach (Employees line in employeeList)
            {
                employeeNamesList.Add(line.FirstName + " " + line.LastName);
            }
            cbEmployeeList.ItemsSource = employeeNamesList;
            cbEmployeeList.Items.Refresh();
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
            //MessageBox.Show("employ id is " + clientId);

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
                MessageBox.Show("Task name must be at least 5 characters", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
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
                MessageBox.Show("End date must be greater then Start date");
                return false;
            }

            taskType = ((ComboBoxItem)cbTaskType.SelectedItem).Content.ToString();
            if (taskType == "--Select option--")
            {
                MessageBox.Show("Invalid input. Please select a task type");
                return false;
            }

            status = ((ComboBoxItem)cbStatus.SelectedItem).Content.ToString();
            if (status == "--Select option--")
            {
                MessageBox.Show("Invalid input. Please select a status");
                return false;
            }

            priority = ((ComboBoxItem)cbPriority.SelectedItem).Content.ToString();
            if (priority == "--Select option--")
            {
                MessageBox.Show("Invalid input. Please select a priority");
                return false;
            }

            reminder = ((ComboBoxItem)cbReminder.SelectedItem).Content.ToString();
            if (reminder == "--Select option--")
            {
                MessageBox.Show("Invalid input. Please select a reminder");
                return false;
            }

            if (tbDescription.Text.Length > 0)
            {
                description = tbDescription.Text;
            }

            return true;
        }

        private void ClearAllData()
        {
            string nameTask = "";
            string description = "";
            DateTime startDate;
            DateTime endDate;
            string informationNotes = "";
            string status = "";
            string taskType = "";
            string priority = "";
            string reminder = "";
        }

        private void ClearForm()
        {
                        
            cbClientList.SelectedIndex = 0;
            cbEmployeeList.SelectedIndex = 0;
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
                db.AddTasks(task);
                ClearAllData();
                MessageBoxResult result = MessageBox.Show("New Task was succesfully added. Clear Form?", "Add", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    ClearForm();
                }
            }

        }




    }
}
