using BashShop.Data;
using BashShop.Windows;
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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            SaveUpdateBtn.Visibility = Visibility.Hidden;
            FIOTB.Text = App.user.Surname + " " + App.user.Name + " " + App.user.Patronic;
            DataContext = App.user;
            GetInfoOrderAsync();
        }
        public async Task GetInfoOrderAsync()
        {
            UsersLV.ItemsSource = await Orders.GetInfoOrder();
        }

        private void UpdateProfilBtn_Click(object sender, RoutedEventArgs e)
        {
            FIOTB.IsEnabled = true;
            PhoneLB.IsEnabled = true;
            PassLB.IsEnabled = true;
            SaveUpdateBtn.Visibility = Visibility.Visible;
        }

        private void SaveUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            FIOTB.IsEnabled = false;
            PhoneLB.IsEnabled = false;
            PassLB.IsEnabled = false;
            SaveUpdateBtn.Visibility = Visibility.Hidden;
            string[] fio = FIOTB.Text.Split(' ');
            App.user.Surname = fio[0];
            App.user.Name = fio[1];
            App.user.Patronic = fio[2];
            Users.EditProfile();

        }

        private void UsersLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DialogDelWindow dia = new DialogDelWindow();
            if (dia.ShowDialog()==true)
            {
                var item = UsersLV.SelectedItem as Orders;
            }
        }
    }
}
