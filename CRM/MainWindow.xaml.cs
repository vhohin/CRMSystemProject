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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db;
        string employee = "";
        int importance = 0;
        public MainWindow()
        {
            try
            {
                db = new Database();
            }
            catch (Exception e)
            {
                MessageBox.Show("Fatal error: unable coonect to database" + e.Message, "Fatal error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
                //throw e;
            }
            InitializeComponent();

            tbUserName.Focus();

        }
        private bool EnterCheck()
        {
            if (tbUserName.Text == "")
            {
                MessageBox.Show("Enter name, please.", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }
            if (pbPsw.Password == "")
            {
                MessageBox.Show("Enter password, please.", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }
            try
            {
                List<Employees> list = db.GetAllEmployees();
                foreach (Employees e in list)
                {
                    if ((tbUserName.Text == e.UserName) && (pbPsw.Password == e.Password))
                    {
                        employee = e.FirstName + "   " + e.LastName;
                        importance = e.Importance;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          /*  if (EnterCheck() == true)
            {
                MainForm taskWindow = new MainForm(employee, importance);
                taskWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Name or Password is not correct.", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                tbUserName.Text = "";
                pbPsw.Password = "";
                return;
            }*/
             MainForm taskWindow = new MainForm("Valeriy Hohin", 1);
             taskWindow.Show();
             this.Close();
        }
    }

}