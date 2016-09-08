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
    /// Interaction logic for NewTaskForm.xaml
    /// </summary>
    public partial class NewTaskForm : Window
    {
        public NewTaskForm()
        {
            InitializeComponent();
        }

        private void listTaskType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBoxItem)listTaskType.SelectedItem).Content;
            if (item == null)
            {
                return;
            }

            //MessageBox.Show(item.ToString());
        }

        private void listStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBoxItem)listStatus.SelectedItem).Content;
            if (item == null)
            {
                return;
            }

            //MessageBox.Show(item.ToString());
        }

        private void listPriority_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBoxItem)listPriority.SelectedItem).Content;
            if (item == null)
            {
                return;
            }

            //MessageBox.Show(item.ToString());
        }

        private void listReminder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBoxItem)listReminder.SelectedItem).Content;
            if (item == null)
            {
                return;
            }

            //MessageBox.Show(item.ToString());
        }


    }
}
