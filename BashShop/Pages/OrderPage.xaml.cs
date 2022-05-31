using BashShop.Data;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BashShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        Products order;
        public OrderPage(Products or)
        {
            InitializeComponent();
            order = or;
            NameProd.Text = or.Name;
            DesProd.Text = or.Description;
            PriceProd.Text = or.Price.ToString();
            PriceProds.Text = or.Price.ToString();
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            Orders or = new Orders(NameProd.Text, Convert.ToDouble(PriceProds.Text), DesProd.Text, Convert.ToInt32(CountProd.Text), App.user.Name, App.user.Phone);
            Orders.AddOrder(or);
            MessageBox.Show("Заказ отправлен");

        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(CountProd.Text);
            if (count == 1)
            {
                CountProd.Text = "1";
            }
            else
            {
                count--;
                CountProd.Text = count.ToString();
                PriceProds.Text = (count * order.Price).ToString();
            }
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(CountProd.Text);
            double pr = Convert.ToDouble(PriceProd.Text);
            if (count >= 50)
            {
                CountProd.Text = "50";
            }
            else
            {
                count++;
                CountProd.Text = count.ToString();
                PriceProds.Text = (count * pr).ToString();
            }
        }
    }
}
