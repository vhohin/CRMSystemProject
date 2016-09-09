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
            dpStartDate.SelectedDate = DateTime.Now;
            dpEndDate.SelectedDate = DateTime.Now;
        } // end NewTAsk

        private void listTaskType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBoxItem)listTaskType.SelectedItem).Content;
            if (item == null)
            {
                return;
            }

        }

        private void listStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBoxItem)listStatus.SelectedItem).Content;
            if (item == null)
            {
                return;
            }

        }

        private void listPriority_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBoxItem)listPriority.SelectedItem).Content;
            if (item == null)
            {
                return;
            }

        }

        private void listReminder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBoxItem)listReminder.SelectedItem).Content;
            if (item == null)
            {
                return;
            }

        }

        private bool ValidateData ()
        {

            //clientId
            if (tbTaskName.Text.Length < 5)
            {
                MessageBox.Show("Task name must be at least 5 characters", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                nameTask = tbTaskName.Text;
            }

            // employeeId


            // !!!!!!!!!!!TODO - VALIDATE IF END DATE < STARTDATE

            
            startDate =  dpStartDate.SelectedDate.Value;
            endDate = dpEndDate.SelectedDate.Value;

            taskType = ((ComboBoxItem)listTaskType.SelectedItem).Content.ToString();
            if (taskType == "--Select option--")
            {
                MessageBox.Show("Invalid input. Please select a task type");
                return false;
            }

            status = ((ComboBoxItem)listStatus.SelectedItem).Content.ToString();
            if (status == "--Select option--")
            {
                MessageBox.Show("Invalid input. Please select a status");
                return false;
            }

            priority = ((ComboBoxItem)listPriority.SelectedItem).Content.ToString();
            if (priority == "--Select option--")
            {
                MessageBox.Show("Invalid input. Please select a priority");
                return false;
            }

            reminder = ((ComboBoxItem)listReminder.SelectedItem).Content.ToString();
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

            // TODO: CLEAR ALL FIELDS FROM COMBOBOX
            tbTaskName.Text = "";
            dpStartDate.SelectedDate = DateTime.Now;
            dpEndDate.SelectedDate = DateTime.Now;
            tbDescription.Text = "";
            
            
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {

            if (ValidateData() == true)
            {
                //TODO - EMployeeId and ClientId
                Tasks task = new Tasks() { EmployeeId=2, NameTask = nameTask, Description =description, StartDate=startDate, EndDate=endDate, InformationNotes="", Status=status, TaskType=taskType, Priority=priority, Reminder=reminder, ClientId=2};
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
