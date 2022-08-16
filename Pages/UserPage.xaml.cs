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

namespace DTP_Project.Pages
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            DataGridUsers.ItemsSource = DTP_Entities.GetContext().User.ToList();
        }
        private void UserPage_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DTP_Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataGridUsers.ItemsSource = DTP_Entities.GetContext().User.ToList();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.UserFrame.Navigate(new AddEditUsersPage(null));
        }

        private void BigEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridUsers.SelectedItem == null)
            {
                MessageBox.Show("Не был выбран элемент для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                Manager.UserFrame.Navigate(new AddEditUsersPage((User)DataGridUsers.SelectedItem));
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var accidentsForRemoving = DataGridUsers.SelectedItems.Cast<User>().ToList();
            if (MessageBox.Show($"Вы действительно хотите удалить следующие {accidentsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    DTP_Entities.GetContext().User.RemoveRange(accidentsForRemoving);
                    DTP_Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DataGridUsers.ItemsSource = DTP_Entities.GetContext().User.ToList();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
