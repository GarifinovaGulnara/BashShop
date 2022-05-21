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
using BashShop.APages;
using BashShop.Pages;
using MongoDB.Bson;

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
            if (IsAdmin ==true)
            {
                MainFrame.Navigate(new AHomePage());
            }
            else
                MainFrame.Navigate(new HomePage());
        }

        private void Catalog_Click(object sender, RoutedEventArgs e)
        {
            if (IsAdmin == true)
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
