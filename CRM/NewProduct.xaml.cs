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
    /// Interaction logic for NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {

        Database db;

        List<Products> listProducts;
        int productId;
        string productType = "";
        string productName = "";
        string producerName = "";
        string model = "";
        string descriprion = "";
        string color = "";
        double unitPrice = 0;
        double weight = 0;
        int unitsInStock = 0;
        int customerRating = 0;
        string discontinuedYN;
        bool discontinued;
        int currentProduct = 0;



        public NewProduct()
        {
            InitializeComponent();

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
        }


        private bool ValidateProductData()
        {
            // TODO
            if (tbAddProductType.Text.Length < 2)
            {
                MessageBox.Show("Product Type must be at least 2 characters", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                productType = tbAddProductType.Text;
            }

            if (tbAddProductName.Text.Length < 2)
            {
                MessageBox.Show("Product Name must be at least 2 characters", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                productName = tbAddProductName.Text;
            }



            if (tbAddProducerName.Text.Length < 2)
            {
                MessageBox.Show("ProducerName name must be at least 2 characters", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                producerName = tbAddProducerName.Text;
            }

            if (tbAddProductModel.Text.Length < 2)
            {
                MessageBox.Show("Model must be at least 2 characters", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                model = tbAddProductModel.Text;
            }

            if (tbAddProductColor.Text.Length < 2)
            {
                MessageBox.Show("Color must be at least 2 characters", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                color = tbAddProductColor.Text;
            }


            if (tbAddProductDescription.Text.Length < 5)
            {
                MessageBox.Show("Product Description name must be at least 5 characters", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
            else
            {
                descriprion = tbAddProductDescription.Text;
            }

            if (!Double.TryParse(tbAddProductWeight.Text, out weight))
            {
                MessageBox.Show("Weight must be a float number", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;

            }

            if (!Double.TryParse(tbAddProductUnitPrice.Text, out unitPrice))
            {
                MessageBox.Show("Price must be a float number", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;

            }

            if (!int.TryParse(tbAddProductUnitsInStock.Text, out unitsInStock))
            {
                MessageBox.Show("Units in stock must be an integer number", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;

            }

            if (!int.TryParse(tbAddProductCustomerRating.Text, out customerRating))
            {
                MessageBox.Show("Customer Rating must be an integer number", "Error entering data", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;

            }

            if (discontinuedYN == "YES")
            {
                discontinued = true;
            }
            else if (discontinuedYN == "NO")
            {
                discontinued = false;
            }
            else
            {
                MessageBox.Show("Is it discontunued product or not?", "Error entering datas", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }

            return true;
        }

        private void ClearAllData()
        {
            productType = "";
            productName = "";
            producerName = "";
            model = "";
            descriprion = "";
            color = "";
            unitPrice = 0;
            weight = 0;
            unitsInStock = 0;
            customerRating = 0;
            discontinued = true;


        }

        private void ClearForm()
        {
            tbAddProductType.Text = "";
            tbAddProductName.Text = "";
            tbAddProducerName.Text = "";
            tbAddProductModel.Text = "";
            tbAddProductColor.Text = "";
            tbAddProductWeight.Text = "";
            tbAddProductUnitPrice.Text = "";
            tbAddProductUnitsInStock.Text = "";
            tbAddProductCustomerRating.Text = "";
            tbAddProductDescription.Text = "";


        }


        private void btAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateProductData() == true)
            {

                Products product = new Products()
                {
                    ProductId = productId,
                    ProductType = productType,
                    ProductName = productName,
                    ProducerName = producerName,
                    Model = model,
                    Descriprion = descriprion,
                    Color = color,
                    UnitPrice = unitPrice,
                    Weight = weight,
                    UnitsInStock = unitsInStock,
                    CustomerRating = customerRating,
                    Discontinued = discontinued
                };
                db.AddProduct(product);
                ClearAllData();
                MessageBoxResult result = MessageBox.Show("New Product was succesfully added. Clear Form?", "Add", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    ClearForm();
                }

            }
            
        }

        private void btCloseProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RadioButtonAddProduct_Checked (object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            discontinuedYN = button.Content.ToString();
        }
    }
}
