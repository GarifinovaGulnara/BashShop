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
    /// Логика взаимодействия для AboutUsPage.xaml
    /// </summary>
    public partial class AboutUsPage : Page
    {
        public AboutUsPage()
        {
            InitializeComponent();
            GetInfoReviews();
        }

        private void AddRevBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DesRev.Text == " ")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                Reviews rev = new Reviews(DesRev.Text, App.user.Name);
                Reviews.AddReview(rev);
                GetInfoReviews();
            }
        }

        public async Task GetInfoReviews()
        {
            ReviewsLV.ItemsSource = await Reviews.GetInfoReview();
        }
    }
}
