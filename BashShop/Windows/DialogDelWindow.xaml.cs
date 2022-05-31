using System.Windows;

namespace BashShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для DialogDelWindow.xaml
    /// </summary>
    public partial class DialogDelWindow : Window
    {
        public DialogDelWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
