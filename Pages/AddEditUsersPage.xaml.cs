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
//using ViewModel;

namespace DTP_Project.Pages
{
    /// <summary>
    /// Interaction logic for AddEditUsersPage.xaml
    /// </summary>
    public partial class AddEditUsersPage : Page
    {

        private User _currentUser = new User();
        public AddEditUsersPage()
        {
            InitializeComponent();
            DataContext = _currentUser;
            //ComboBoxUserRole.ItemsSource = new RoleEntityViewModels();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.UserFrame.Navigate(new AddEditUsersPage(null));
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errorString = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentUser.UserNickname))
                errorString.AppendLine("Никнейм не может отсутствовать");
            if (string.IsNullOrWhiteSpace(_currentUser.UserPassword))
                errorString.AppendLine("Пароль не может отсутствовать");

            if (errorString.Length > 0)
            {
                MessageBox.Show(errorString.ToString());
                return;
            }

            if (_currentUser.UserID == 0)
                DTP_Entities.GetContext().User.Add(_currentUser);

            try
            {
                DTP_Entities.GetContext().SaveChanges();
                Manager.UserFrame.GoBack();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void GoBackwardButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.UserFrame.GoBack();
        }

        public AddEditUsersPage(User selectedUser)
        {
            InitializeComponent();

            if (selectedUser != null)
                _currentUser = selectedUser;

            DataContext = _currentUser;
        }
    }
}
