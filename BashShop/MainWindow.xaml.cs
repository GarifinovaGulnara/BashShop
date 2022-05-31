using System.Windows;
using BashShop.APages;
using BashShop.Pages;

namespace BashShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsAdmin;
        public MainWindow(bool id) 
        {
            InitializeComponent();
            IsAdmin = id;
        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            if (App.user.IsAdmin == true)
            {
                MainFrame.Navigate(new AHomePage());
            }
            else
                MainFrame.Navigate(new HomePage());
        }

        private void Catalog_Click(object sender, RoutedEventArgs e)
        {
            if (App.user.IsAdmin == true)
            {
                MainFrame.Navigate(new ACatalogPage());
            }
            else
                MainFrame.Navigate(new CatalogPage());
        }

        private void About_Us_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AboutUsPage());
        }
    }
}
