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
    /// Interaction logic for NewEmployee.xaml
    /// </summary>
    public partial class NewEmployee : Window
    {
        Database db;
        List<Employees> listEmployee;        
        List<Positions> listPositions;
        List<string> listPositionsNames;
        List<Departaments> listDepartments;
        List<string> listDepartmentsNames;
        string employeeUserName = "";
        string employeePassword = "";
        string employeeFirstName = "";
        string employeeMiddleName = "";
        string employeeLastName = "";
        string employeeAddress = "";
        string employeeCity = "";
        string employeeLocation = "";
        string employeeCountry = "";
        string employeePostalCode = "";
        string employeePhone = "";
        string employeeEmail = "";
        string employeeDescription = "";
        int employeePositionId = 0;
        int employeeDepartmentID = 0;
        int employeeImportance = 0;
        DateTime employeeDOB;
        DateTime employeeHireDate;
        public NewEmployee()
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
            UploadEmployeePositions();
            UploadEmployeeDepartments();
        }
        //*******************************************************
        //  Upploads combos
        //*******************************************************
        private void UploadEmployeePositions()
        {
            try
            {
                listPositions = db.GetAllPositions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }
            listPositionsNames = new List<string>();
            foreach (Positions line in listPositions)
            {
                listPositionsNames.Add(line.PositionName);
            }
            cbEmployeePositions.ItemsSource = listPositionsNames;
            cbEmployeePositions.Items.Refresh();
        }
        private void UploadEmployeeDepartments()
        {
            try
            {
                listDepartments = db.GetAllDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to fetch records from database." + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Stop);
                // TODO: write details of the exception to log text file
                Environment.Exit(1);
            }
            listDepartmentsNames = new List<string>();
            foreach (Departaments line in listDepartments)
            {
                listDepartmentsNames.Add(line.DepartmentName);
            }
            cbEmployeeDepartments.ItemsSource = listDepartmentsNames;
            cbEmployeeDepartments.Items.Refresh();
        }

        private void cbEmployeePositions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEmployeePositions.SelectedIndex == -1)
            {
                return;
            }
            Positions p = listPositions[cbEmployeePositions.SelectedIndex];
            employeePositionId = p.PositionId;
        }
        private void cbEmployeeDepartmets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEmployeeDepartments.SelectedIndex == -1)
            {
                return;
            }
            Departaments d = listDepartments[cbEmployeeDepartments.SelectedIndex];
            employeeDepartmentID = d.DepartmentId;
        }
        private string PositionsToString(int id)
        {
            string positionName = "";
            if (listPositions.Count > 0)
            {
                foreach (Positions p in listPositions)
                    if (p.PositionId == id)
                    {
                        positionName = p.PositionName;
                    }
            }
            return positionName;
        }
        private string DepartmentToString(int id)
        {
            string departmentName = "";
            if (listDepartments.Count > 0)
            {
                foreach (Departaments d in listDepartments)
                    if (d.DepartmentId == id)
                    {
                        departmentName = d.DepartmentName;
                    }
            }
            return departmentName;
        }

        private void btEmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    if (CheckingEmployeeDatas() == true)
                    {
                        Employees em = new Employees() { UserName = employeeUserName, Password = employeePassword, Importance = employeeImportance, FirstName = employeeFirstName, MiddleName = employeeMiddleName, LastName = employeeLastName, Address = employeeAddress, City = employeeCity, Location = employeeLocation, Country = employeeCountry, ZipCode = employeePostalCode, Phone = employeePhone, Description = employeeDescription, Email = employeeEmail, PositionID = employeePositionId, DepartmentID = employeeDepartmentID, DOB = employeeDOB, HireDate = employeeHireDate };
                        db.AddEmployees(em);
                        MessageBox.Show("Employee information was succesful added.", "Addition", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                        ClearFormEmployee();                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to update employee information in database." + ex.Message, "Updating error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    // TODO: write details of the exception to log text file
                    return;
                }            
        }

        private void btEmployeeClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFormEmployee();
        }
        private void btEmployeeClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ClearFormEmployee()
        {
            tbEmployeeFirstName.Text = "";
            tbEmployeeLastName.Text = "";
            tbEmployeeUserName.Text = "";
            tbEmployeePassword.Text = "";
            tbEmployeeAddress.Text = "";
            tbEmployeeCity.Text = "";
            tbEmployeeCountry.Text = "";
            tbEmployeeLocation.Text = "";
            tbEmployeePostalCode.Text = "";
            tbEmployeePhone.Text = "";
            tbEmployeeEmail.Text = "";
            tbEmployeeDescription.Text = "";
            cbEmployeePositions.SelectedIndex = -1;
            cbEmployeeDepartments.SelectedIndex = -1;
            dpEmployeeDOB.SelectedDate = DateTime.Now;
            dpEmployeeHireDate.SelectedDate = DateTime.Now;
        }
        private bool CheckingEmployeeDatas()
        {
            if (tbEmployeeUserName.Text.Length < 2)
            {
                MessageBox.Show("User name must be at least 2 characters", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                employeeUserName = tbEmployeeUserName.Text;
            }

            if (tbEmployeePassword.Text.Length < 2)
            {
                MessageBox.Show("Password must be at least 2 characters", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                employeePassword = tbEmployeePassword.Text;
            }

            if (tbEmployeeFirstName.Text.Length < 2)
            {
                MessageBox.Show("Employee first name must be at least 2 characters", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                employeeFirstName = tbEmployeeFirstName.Text;
            }

            if (tbEmployeeLastName.Text.Length < 2)
            {
                MessageBox.Show("Employee last name must be at least 2 characters", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                employeeLastName = tbEmployeeLastName.Text;
            }

            if (tbEmployeeAddress.Text.Length < 1)
            {
                MessageBox.Show("Enter Address please", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                employeeAddress = tbEmployeeAddress.Text;
            }

            if (tbEmployeeCity.Text.Length < 1)
            {
                MessageBox.Show("Enter City please", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                employeeCity = tbEmployeeCity.Text;
            }

            if (tbEmployeeCountry.Text.Length < 1)
            {
                MessageBox.Show("Enter Country please", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                employeeCountry = tbEmployeeCountry.Text;
            }

            if (tbEmployeeLocation.Text.Length > 0)
            {
                employeeLocation = tbEmployeeLocation.Text;
            }

            if (tbEmployeePostalCode.Text.Length > 0)
            {
                employeePostalCode = tbEmployeePostalCode.Text;
            }

            if (tbEmployeePhone.Text.Length > 0)
            {
                employeePhone = tbEmployeePhone.Text;
            }

            if (tbEmployeeEmail.Text.Length > 0)
            {
                employeeEmail = tbEmployeeEmail.Text;
            }

            if (tbEmployeeDescription.Text.Length > 0)
            {
                employeeDescription = tbEmployeeDescription.Text;
            }
            employeeDOB = dpEmployeeDOB.SelectedDate.Value;
            employeeHireDate = dpEmployeeHireDate.SelectedDate.Value;
            return true;
        }
    }

}
