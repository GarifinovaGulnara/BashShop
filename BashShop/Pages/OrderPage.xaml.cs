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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        Orders order;
        public OrderPage(Orders or)
        {
            InitializeComponent();
            order = or;
            NameProd.Text = or.NameProd;
            PriceProd.Text = or.PriceProd.ToString();
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            Orders or = new Orders(NameProd.Text, Convert.ToDouble(PriceProd.Text), App.user.Name, App.user.Phone);
            Orders.AddOrder(or);
            MessageBox.Show("Заказ отправлен");

        }
    }
}
