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
