using BashShop.Data;
using System.Windows;

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
