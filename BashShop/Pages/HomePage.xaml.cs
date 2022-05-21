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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BashShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            SaveUpdateBtn.Visibility = Visibility.Hidden;
        }

        private void UpdateProfilBtn_Click(object sender, RoutedEventArgs e)
        {
            FIOTB.IsEnabled = true;
            DateBirhtTB.IsEnabled = true;
            PassLB.IsEnabled = true;
            SaveUpdateBtn.Visibility = Visibility.Visible;
        }

        private void SaveUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            FIOTB.IsEnabled = false;
            DateBirhtTB.IsEnabled = false;
            PassLB.IsEnabled = false;
            SaveUpdateBtn.Visibility = Visibility.Hidden;
        }
    }
}
