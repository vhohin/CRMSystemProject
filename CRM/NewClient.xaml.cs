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
        string address ="";
        string city = "";
        string location = "";
        string country="";
        string postalCode = "";
        string phone="";
        string description = "";
        string commercialYN;
        bool commercial;
        string fax = "";
        string email = "";
        string webPage = "";
        DateTime firstContacted;
        public NewClient()
        {
            InitializeComponent();
            dpFirstContact.SelectedDate = DateTime.Now;            
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            commercialYN = button.Content.ToString();
            
        }

        private bool CheckingDatas()
        {
            /* string description = tbDescription.Text;
             DateTime dueDate = dpFirstContact.SelectedDate.Value;
             bool isDone = false;
             if (cbIsDone.IsChecked == true)
             {
                 isDone = true;
             }
             Clients cl = new Clients() { Description = description, DueDate = dueDate, IsDone = isDone };
             db.AddClients(cl);*/
            //UpdateG();
            if (tbClientName.Text.Length < 2)
            { 
            
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
                MessageBox.Show("It is commercial client or no?","Error entering datas",MessageBoxButton.OK,MessageBoxImage.Hand);
                return false;
            }
            return true;
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CheckingDatas() == true)
            {
                Clients cl = new Clients{ClientName = clientName, ContactName = contactName, Address = address
                    ,City = city, Location = location, Country = country, PostalCode = postalCode, Phone = phone, Description = description
                    , Commercial = commercial, Fax = fax, Email = email, WebPage = webPage, FirstContacted = firstContacted};
                db.AddClients(cl);
            }
           
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
