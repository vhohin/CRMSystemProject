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
            
            UpdateGridList();
        }
        private void UpdateGridList()
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
            /* lblId.Content = "...";
             tbDescription.Text = "";
             dpDueDate.SelectedDate = DateTime.Today;
             cbIsDone.IsChecked = false;*/
        }
        private void dgTasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btEmployees_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btContracts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btContacts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btClients_Click(object sender, RoutedEventArgs e)
        {
            ClientInfo clientInfo = new ClientInfo();
            clientInfo.Owner = this;
            clientInfo.Show();
        }

        private void btServices_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btProducts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btTasks_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btNewTasks_Click(object sender, RoutedEventArgs e)
        {
           /* NewTask newTaskWindow = new NewTask();
            newTaskWindow.Owner = this;
            newTaskWindow.Show();*/

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
    }
}
