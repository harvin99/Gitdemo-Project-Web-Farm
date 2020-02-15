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

namespace QLTro
{
    /// <summary>
    /// Interaction logic for ConfirmWindow.xaml
    /// </summary>
    public partial class ConfirmWindow : Window
    {
        public ConfirmWindow(string description)
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            lbdescription.Content = description;
        }

        private void btok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btcancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
