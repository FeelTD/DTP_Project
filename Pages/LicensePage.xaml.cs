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

namespace DTP_Project
{
    /// <summary>
    /// Interaction logic for LicensePage.xaml
    /// </summary>
    public partial class LicensePage : Page
    {
       
        public LicensePage()
        {
            InitializeComponent();
            var currentLicenses = DTP_Entities.GetContext().DrivingLicense.ToList();
            ListViewLicense.ItemsSource = currentLicenses;
        }

        private void LicensePage_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DTP_Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListViewLicense.ItemsSource = DTP_Entities.GetContext().DrivingLicense.ToList();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.LicenseFrame.Navigate(new Pages.AddEditLicensesPage(null));
        }

        private void BigEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewLicense.SelectedItem==null)
            {
                MessageBox.Show("Не был выбран элемент для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                Manager.LicenseFrame.Navigate(new Pages.AddEditLicensesPage((DrivingLicense)ListViewLicense.SelectedItem));
            }    
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var licensesForRemoving = ListViewLicense.SelectedItems.Cast<DrivingLicense>().ToList();
            if (MessageBox.Show($"Вы действительно хотите удалить следующие {licensesForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    DTP_Entities.GetContext().DrivingLicense.RemoveRange(licensesForRemoving);
                    DTP_Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    ListViewLicense.ItemsSource = DTP_Entities.GetContext().DrivingLicense.ToList();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
