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
        public MainForm()
        {
            InitializeComponent();
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
            NewTaskForm newTaskWindow = new NewTaskForm();
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
    }
}
