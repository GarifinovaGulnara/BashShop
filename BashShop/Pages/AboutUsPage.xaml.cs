using BashShop.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
                DesRev.Text = "";
            }
        }

        public async Task GetInfoReviews()
        {
            ReviewsLV.ItemsSource = await Reviews.GetInfoReview();
        }
    }
}
