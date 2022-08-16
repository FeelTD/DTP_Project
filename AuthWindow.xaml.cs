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

namespace DTP_Project
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {

        public static User authUser;
        public static User adminFound;
        public static User employeeFound;
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var question = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            authUser = DTP_Entities.GetContext().User.FirstOrDefault(i => i.UserNickname == UsernameBox.Text && i.UserPassword == PasswordBox.Password);

            if (authUser != null)
            {
                adminFound = DTP_Entities.GetContext().User.Where(i => i.UserRole == 1 && i.UserNickname == authUser.UserNickname).FirstOrDefault();
                employeeFound = DTP_Entities.GetContext().User.Where(i => i.UserRole == 2 && i.UserNickname == authUser.UserNickname).FirstOrDefault();

                if (employeeFound == null && adminFound == null)
                {
                    MessageBox.Show("Идентификация не пройдена. Пользователь не найден.", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (employeeFound != null)
                {
                    MessageBox.Show($"Здравствуйте, сотрудник {employeeFound.UserNickname}.", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Hide();
                }
                else if (adminFound != null)
                {
                    MessageBox.Show($"Здравствуйте, администратор {adminFound.UserNickname}.", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Hide();
                }
            }
            else
            {
                if (String.IsNullOrWhiteSpace(PasswordBox.Password) && !String.IsNullOrWhiteSpace(UsernameBox.Text))
                {
                    MessageBox.Show("Вы не ввели пароль.", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (String.IsNullOrWhiteSpace(PasswordBox.Password) && String.IsNullOrWhiteSpace(UsernameBox.Text))
                {
                    MessageBox.Show("Вы не заполнили данные для авторизации.", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (!String.IsNullOrWhiteSpace(UsernameBox.Text) && !String.IsNullOrWhiteSpace(PasswordBox.Password))
                {
                    MessageBox.Show("В доступе отказано. Проверьте правильность введенных данных.", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (String.IsNullOrWhiteSpace(UsernameBox.Text) && !String.IsNullOrWhiteSpace(PasswordBox.Password))
                {
                    MessageBox.Show("Вы не ввели логин.", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
