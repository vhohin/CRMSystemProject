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
    /// Interaction logic for NewClient.xaml
    /// </summary>
    public partial class NewClient : Window
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
        public NewClient()
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
            dpFirstContact.SelectedDate = DateTime.Now;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            commercialYN = button.Content.ToString();

        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            DateTime? date = picker.SelectedDate;
        }

        private bool CheckingDatas()
        {
            if (tbClientName.Text.Length < 2)
            {
                MessageBox.Show("Client name must be at least 2 characters", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                clientName = tbClientName.Text;
            }

            if (tbContactName.Text.Length < 2)
            {
                MessageBox.Show("Contact name must be at least 2 characters", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                contactName = tbContactName.Text;
            }

            if (tbAddress.Text.Length < 1)
            {
                MessageBox.Show("Enter Address please", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                address = tbAddress.Text;
            }

            if (tbCity.Text.Length < 1)
            {
                MessageBox.Show("Enter City please", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                city = tbCity.Text;
            }

            if (tbCountry.Text.Length < 1)
            {
                MessageBox.Show("Enter Country please", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                country = tbCountry.Text;
            }

            if (tbLocation.Text.Length > 0)
            {
                location = tbLocation.Text;
            }

            if (tbPostalCode.Text.Length > 0)
            {
                postalCode = tbPostalCode.Text;
            }

            if (tbPhone.Text.Length > 0)
            {
                phone = tbPhone.Text;
            }

            if (tbFax.Text.Length > 0)
            {
                fax = tbFax.Text;
            }

            if (tbEmail.Text.Length > 0)
            {
                email = tbEmail.Text;
            }

            if (tbWeb.Text.Length > 0)
            {
                webPage = tbWeb.Text;
            }

            if (tbDescription.Text.Length > 0)
            {
                description = tbDescription.Text;
            }

            if (commercialYN == "YES")
            {
                commercial = true;
            }
            else if (commercialYN == "NO")
            {
                commercial = false;
            }
            else
            {
                MessageBox.Show("It is commercial client or no?", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            firstContacted = dpFirstContact.SelectedDate.Value;
            return true;
        }

        private void ClearDatas()
        {
            clientName = "";
            contactName = "";
            address = "";
            city = "";
            location = "";
            country = "";
            postalCode = "";
            phone = "";
            description = "";
            fax = "";
            email = "";
            webPage = "";
        }

        private void ClearForm()
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
            rbYesCommercial.IsChecked = false;
            rbNoCommercial.IsChecked = false;
            dpFirstContact.SelectedDate = DateTime.Now;
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CheckingDatas() == true)
            {
                Clients cl = new Clients() { ClientName = clientName, ContactName = contactName, Address = address, City = city, Location = location, Country = country, PostalCode = postalCode, Phone = phone, Description = description, Commercial = commercial, Fax = fax, Email = email, WebPage = webPage, FirstContacted = firstContacted };
                try
                {
                    db.AddClients(cl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to add records to database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    // TODO: write details of the exception to log text file
                    Environment.Exit(1);
                } 
                ClearDatas();
                MessageBoxResult result = MessageBox.Show("New Client was succesful added. Clear Form?", "Addition", MessageBoxButton.YesNo, MessageBoxImage.Information);
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
                ClearDatas();
            }
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            if ((tbClientName.Text != "") || (tbContactName.Text != "") || (tbAddress.Text != "")
            || (tbCity.Text != "") || (tbCountry.Text != "")
            || (tbLocation.Text != "") || (tbPostalCode.Text != "")
            || (tbPhone.Text != "") || (tbFax.Text != "") || (tbEmail.Text != "")
            || (tbWeb.Text != "") || (tbDescription.Text != ""))
            {
                MessageBoxResult result = MessageBox.Show("Close Form?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
