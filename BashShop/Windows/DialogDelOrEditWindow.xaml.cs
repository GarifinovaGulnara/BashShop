using BashShop.APages;
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
    /// Логика взаимодействия для DialogDelOrEditWindow.xaml
    /// </summary>
    public partial class DialogDelOrEditWindow : Window
    {
        public Products products;
        public DialogDelOrEditWindow(Products prod)
        {
            InitializeComponent();
            products = prod;
        }

        private void DeleteProd_Click(object sender, RoutedEventArgs e)
        {
            Products.DeleteProd(products);
            MessageBox.Show("Товар удален");
            this.Close();
        }

        private void EditProd_Click(object sender, RoutedEventArgs e)
        {
            EditWindow apw = new EditWindow(products);
            apw.Show();
        }
    }
}
