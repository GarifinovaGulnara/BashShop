using BashShop.Data;
using System;
using System.Windows;

namespace BashShop.APages
{
    /// <summary>
    /// Логика взаимодействия для AddProdWindow.xaml
    /// </summary>
    public partial class AddProdWindow : Window
    {
        public AddProdWindow()
        {
            InitializeComponent();
        }

        private void AddProdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameProd.Text == "" || DesProd.Text == "" || PriceProd.Text == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                Products pr = new Products(NameProd.Text, DesProd.Text, Convert.ToDouble(PriceProd.Text));
                Products.AddProd(pr);
                MessageBox.Show("Товар добавлен");
                NameProd.Text = "";
                DesProd.Text = "";
                PriceProd.Text = "";

            }
        }
    }
}
