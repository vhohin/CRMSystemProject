using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMUnitTests2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProductClassTestNazar()
        {
            //Arrange
            int productId = 2;
            string productType = "printer";
            string productName = "canon";
            string producerName = "Canon";
            string model = "PIXMA-4056";
            string descriprion = "brand new";
            string color = "white";
            double unitPrice = 125;
            double weight = 2.36;
            int unitsInStock = 10;
            int customerRating = 5;
            bool discontinued = true;
            Products p;

            //Act
            p = new Products()
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
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(5, p.CustomerRating);

        }
        [TestMethod]
        public void DatabaseGetAllProductsTestNazar()
        {
            //Arrange
            string productType = "computer2";
            bool exist = false;
            Database db = new Database();
            
            //Act
            List<Products> list = db.GetAllProducts();
            foreach (Products item in list)
            {
                if (productType == item.ProductType)

                {
                    exist = true;
                    break;
                }
              
            }
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(false, exist);
        
        }
    }
}
