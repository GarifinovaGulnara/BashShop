using BashShop.Data;
using System.Windows;

namespace BashShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        public LogWindow()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            if (PhoneLogTB.Text == "" || PassLog.Password == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                Users us = new Users(PhoneLogTB.Text, PassLog.Password);
                Users.LogInUser(us);
                if (App.user.IsAdmin == true)
                {
                    MessageBox.Show("Приветсвуем, Администратор");
                    MainWindow mw = new MainWindow(us.IsAdmin);
                    mw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Успешный вход");
                    MainWindow mw = new MainWindow(us.IsAdmin);
                    mw.Show();
                    this.Close();
                }
            }
        }



        private void LogUp_Click(object sender, RoutedEventArgs e)
        {
            if (NameTB.Text == "" || SurnameTB.Text == "" || PatronicTB.Text == "" || DateBTB.Text == "" || PhoneRegTB.Text == "" || PassReg.Password == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                Users us = new Users(NameTB.Text, SurnameTB.Text, PatronicTB.Text, DateBTB.Text, PhoneRegTB.Text, PassReg.Password, null);
                Users.AddUser(us);
                MessageBox.Show("Вы зарегистрировались!");
                MainWindow mw = new MainWindow(us.IsAdmin);
                mw.Show();
                this.Close();
                App.user = us;
            }
        }
    }
}
