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
    /// Interaction logic for CalendarTasks.xaml
    /// </summary>
    public partial class CalendarTasks : Window
    {
        public class DataObject
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
            public string D { get; set; }
            public string E { get; set; }
            public string F { get; set; }           
        }
        public CalendarTasks()
        {
            InitializeComponent();
            var list = new List<DataObject>();
            list.Add(new DataObject() { A = "Time-Day", B = "Mo", C = "Tu", D = "We", E = "Th", F = "Fr" });
            list.Add(new DataObject() { A = "8:00", B = "", C = "", D = "We", E = "Th", F = "Fr" });
            list.Add(new DataObject() { A = "9:00", B = "", C = "", D = "We", E = "Th", F = "Fr" });
            list.Add(new DataObject() { A = "10:00", B = "", C = "", D = "We", E = "Th", F = "Fr" });
            list.Add(new DataObject() { A = "11:00", B = "", C = "", D = "We", E = "Th", F = "Fr" });
            list.Add(new DataObject() { A = "12:00", B = "", C = "", D = "We", E = "Th", F = "Fr" });
            list.Add(new DataObject() { A = "13:00", B = "", C = "", D = "We", E = "Th", F = "Fr" });
            list.Add(new DataObject() { A = "14:00", B = "", C = "", D = "We", E = "Th", F = "Fr" });
            list.Add(new DataObject() { A = "15:00", B = "", C = "", D = "We", E = "Th", F = "Fr" });
            list.Add(new DataObject() { A = "16:00", B = "", C = "", D = "We", E = "Th", F = "Fr" });
            list.Add(new DataObject() { A = "17:00", B = "", C = "", D = "We", E = "Th", F = "Fr" });
            this.dataGrid1.ItemsSource = list;
        }
    }
}
