using BashShop.Data;
using BashShop.Windows;
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

namespace BashShop.APages
{
    /// <summary>
    /// Логика взаимодействия для ACatalogPage.xaml
    /// </summary>
    public partial class ACatalogPage : Page
    {
        public ACatalogPage()
        {
            InitializeComponent();
            GetInfoProdAsync();
        }

        public async Task GetInfoProdAsync()
        {
            listprod.ItemsSource = await Products.GetProd();
        }

        private void AddProdBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProdWindow apw = new AddProdWindow();
            apw.Show();
        }

        private void listprod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lstp = listprod.SelectedItem as Products;
            DialogDelOrEditWindow ddoew = new DialogDelOrEditWindow(lstp);
            ddoew.Show();
        }
    }
}
