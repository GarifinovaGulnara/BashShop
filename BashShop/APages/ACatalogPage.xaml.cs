using BashShop.Data;
using BashShop.Windows;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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