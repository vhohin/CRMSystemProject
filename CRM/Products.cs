using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public string ProducerName { get; set; }
        public string Model { get; set; }
        public string Descriprion { get; set; }
        public string Color { get; set; }
        public double Weight { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int CustomerRating { get; set; }
        public bool Discontinued { get; set; }

    }
}
