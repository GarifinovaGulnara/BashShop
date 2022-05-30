using BashShop.Data;
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
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        public CatalogPage()
        {
            InitializeComponent();
            GetInfoProdAsync();
        }

        public async Task GetInfoProdAsync()
        {
            listprod.ItemsSource = await Products.GetProd();
        }
        private void listprod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lstp = listprod.SelectedItem as Products;
            this.NavigationService.Navigate(new OrderPage(lstp));
        }
        public async Task GetSearchList()
        {
            listprod.ItemsSource = await Products.SearchList(SearchWord.Text);
        }
        public async Task GetSotringList()
        {
            listprod.ItemsSource = await Products.SortingList();
        }
        public async Task GetSotringListMinus()
        {
            listprod.ItemsSource = await Products.SortingLisrMinus();
        }
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            GetSearchList();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            GetSotringList();
        }

        private void Sort_Copy_Click(object sender, RoutedEventArgs e)
        {
            GetSotringListMinus();
        }
    }
}
