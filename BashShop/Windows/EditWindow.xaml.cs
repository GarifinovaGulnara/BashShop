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
using System.Windows.Shapes;

namespace BashShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        Products products;
        public EditWindow(Products prod)
        {
            InitializeComponent();
            products = prod;
            NameProd.Text = prod.Name;
            PriceProd.Text = prod.Price.ToString();
            DesProd.Text = prod.Description;
        }

        private void EdirProd_Click(object sender, RoutedEventArgs e)
        {
            App.products.Name = NameProd.Text;
            App.products.Price = Convert.ToInt32(PriceProd.Text);
            App.products.Description = DesProd.Text;
            Products.EditProd();
        }
    }
}
