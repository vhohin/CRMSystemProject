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
    /// Interaction logic for ClientInfo.xaml
    /// </summary>
    public partial class ClientInfo : Window
    {
        Database db;
        string clientName = "";
        string contactName = "";
        string address = "";
        string city = "";
        string location = "";
        string country = "";
        string postalCode = "";
        string phone = "";
        string description = "";
        string commercialYN;
        bool commercial;
        string fax = "";
        string email = "";
        string webPage = "";
        DateTime firstContacted;
        public ClientInfo()
        {
            try
            {
                db = new Database();
            }
            catch (Exception e)
            {
                MessageBox.Show("Fatal error: unable coonect to database" + e.Message, "Fatal error", MessageBoxButton.OK, MessageBoxImage.Stop);
                Environment.Exit(1);
            }
            InitializeComponent();
            UpdateGridListClients();
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
           /* lblId.Content = "...";
            tbDescription.Text = "";
            dpDueDate.SelectedDate = DateTime.Today;
            cbIsDone.IsChecked = false;*/
        }

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
        int currentClient = 0;
        private void dgClientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clients cl = dgClientsList.SelectedItem as Clients;
            if (cl == null)
            {
                currentClient = 0;
                return;
            }
            currentClient = cl.ClientId;
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
    }
}
