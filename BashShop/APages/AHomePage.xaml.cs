using BashShop.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BashShop.APages
{
    /// <summary>
    /// Логика взаимодействия для AHomePage.xaml
    /// </summary>
    public partial class AHomePage : Page
    {
        public AHomePage()
        {
            InitializeComponent();
            GetInfoAllOrderAsynk();
        }
        public async Task GetInfoAllOrderAsynk()
        {
            AllOrdersLV.ItemsSource = await Orders.GetInfoAllOrders();
        }

        private void AllOrdersLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = AllOrdersLV.SelectedItem as Orders;
            Orders.DeleteOrder(item);
            MessageBox.Show("Заказ удален");
            GetInfoAllOrderAsynk();
        }
    }
}
