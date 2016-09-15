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
    /// Interaction logic for TaskInformation.xaml
    /// </summary>
    public partial class TaskInformation : Window
    {
        Database db;

        //int taskId;
        int employeeId=0;
        string nameTask = "";
        string description = "";
        DateTime startDate=DateTime.Now;
        DateTime endDate = DateTime.Now;
        string informationNotes = "";
        string status = "";
        string taskType = "";
        string priority = "";
        string reminder = "";
        int clientId=0;
        int currentClientId=0;
        int currentEmployeeId=0;
        Tasks taskInfo;
        List<Clients> clientList;
        List<string> clientNamesList;
        List<Employees> employeeList;
        List<string> employeeNamesList;
        int taskId=0;      

        public TaskInformation(int t)
        {
            try
            {
                db = new Database();
                taskId = t;
                taskInfo = db.GetTaskById(taskId);
            }
            catch (Exception e)
            {
                MessageBox.Show("Fatal error: unable to connect to database" + e.Message, "Fatal error", MessageBoxButton.OK, MessageBoxImage.Stop);
                Environment.Exit(1);
            }
            InitializeComponent();
            UploadClientNames();
            UploadEmployeeNames();
            UploadStatus();
            UploadPriority();
            UploadReminder();
            UploadTaskType();
            //tbEmployeeName.Text = 
            dpStartDate.SelectedDate = taskInfo.StartDate;
            dpEndDate.SelectedDate = taskInfo.EndDate;
            tbTaskName.Text = taskInfo.NameTask;
            tbDescription.Text = taskInfo.Description;
           
        }
       
        private void UploadTaskType()
        {
            List<string> type = new List<string>();
            type.Add("");
            type.Add("Meeting");
            type.Add("Call");
            type.Add("Email");
            type.Add("Event");
            type.Add("Note");
            cbTaskType.ItemsSource = type;
            cbTaskType.Items.Refresh();
            foreach (string line in type)
            {
                if (line == taskInfo.TaskType)
                {
                    cbTaskType.SelectedItem = taskInfo.TaskType;
                    break;
                }
                else
                {
                    cbTaskType.SelectedItem = "";
                }
            }
        }
        private void UploadReminder()
        {
            List<string> reminder = new List<string>();
            reminder.Add("");
            reminder.Add("E-mail");
            reminder.Add("Call");
            reminder.Add("Message");
            cbReminder.ItemsSource = reminder;
            cbReminder.Items.Refresh();
            foreach (string line in reminder)
            {
                if (line == taskInfo.Reminder)
                {
                    cbReminder.SelectedItem = taskInfo.Reminder;
                    break;
                }
                else
                {
                    cbReminder.SelectedItem = "";
                }
            }
        }
        
        private void UploadPriority()
        {
            List<string> p = new List<string>();
            p.Add("");
            p.Add("Low");
            p.Add("Normal");
            p.Add("High");
            cbPriority.ItemsSource = p;
            cbPriority.Items.Refresh();
            foreach (string line in p)
            {
                if (line == taskInfo.Priority)
                {
                    cbPriority.SelectedItem = line;
                    //MessageBox.Show(cbPriority.SelectedItem.ToString());
                    break;
                }
                else
                {
                    cbPriority.SelectedItem = "";
                }
            }
        }
        private void UploadStatus()
        {
            List<string> status = new List<string>();
            status.Add("Select status");
            status.Add("Active");
            status.Add("Planned");
            status.Add("In progress");
            status.Add("Done");
            cbStatus.ItemsSource = status;
            cbStatus.Items.Refresh();
            foreach (string line in status)
            {
                if (line == taskInfo.Status)
                {
                    cbStatus.SelectedItem = taskInfo.Status;
                    break;
                }
                else
                {
                    cbStatus.SelectedItem = "";
                }
            }
        }
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
            for (int i=0;i<clientList.Count;i++)
            {
                clientNamesList.Add(clientList[i].ClientName);
                if (taskInfo.ClientId == clientList[i].ClientId)
                {
                    currentClientId = i;
                }
            }
            cbClientList.ItemsSource = clientNamesList;
            cbClientList.Items.Refresh();
            cbClientList.SelectedIndex = currentClientId;
        }
        private void UploadEmployeeNames()
        {
            try
            {
                employeeList = db.GetAllEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                Environment.Exit(1);
            }
            employeeNamesList = new List<string>();
            foreach (Employees line in employeeList)
            {                
                if (taskInfo.EmployeeId == line.EmployeeId)
                {
                    tbEmployeeName.Text = line.FirstName + " " + line.LastName;
                    currentEmployeeId = line.EmployeeId;
                }
            }                
        }
        //************************
        //
        //**************************
       
        private void cbTaskType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void cbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cbPriority_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cbReminder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

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
        } 

        
        //***********************************
        //
        //*********************************************

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
            priority = cbPriority.SelectedValue.ToString();
            reminder = cbReminder.SelectedValue.ToString();
            status = cbStatus.SelectedValue.ToString();
            taskType = cbTaskType.SelectedValue.ToString();  
            if (tbDescription.Text.Length > 0)
            {
                description = tbDescription.Text;
            }

            return true;
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateData() == true)
            {

                Tasks task = new Tasks() {TaskId=taskId, EmployeeId = currentEmployeeId, NameTask = nameTask, Description = description, StartDate = startDate, EndDate = endDate, InformationNotes = informationNotes, Status = status, TaskType = taskType, Priority = priority, Reminder = reminder, ClientId = clientId };
                try
                {
                    db.UpdateTask(task);
                    MessageBoxResult result = MessageBox.Show("The Task was succesfully updaded", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearAllData();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    // TODO: write details of the exception to log text file
                    Environment.Exit(1);
                }               
            }
        }
        private void ClearAllData()
        {
            nameTask = "";
            description = "";
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            informationNotes = "";
            status = "";
            taskType = "";
            priority = "";
            reminder = "";
        }
        

   }
}
