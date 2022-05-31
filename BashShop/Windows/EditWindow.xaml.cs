using BashShop.Data;
using System;
using System.Windows;

namespace BashShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow(Products prod)
        {
            InitializeComponent();
            App.products = prod;
            EditNameProd.Text = prod.Name;
            EditPriceProd.Text = prod.Price.ToString();
            EditDesProd.Text = prod.Description;
        }

        private void EdirProd_Click(object sender, RoutedEventArgs e)
        {
            App.products.Name = EditNameProd.Text.ToString();
            App.products.Price = Convert.ToInt32(EditPriceProd.Text);
            App.products.Description = EditDesProd.Text.ToString();
            Products.EditProd();
        }
    }
}
