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
    /// Interaction logic for TablePage.xaml
    /// </summary>
    public partial class TablePage : Page
    {
        public TablePage()
        {
            InitializeComponent();
            DataGridAccidents.ItemsSource = DTP_Entities.GetContext().Accident.ToList();
        }

        private void TablePage_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DTP_Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataGridAccidents.ItemsSource = DTP_Entities.GetContext().Accident.ToList();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.TableFrame.Navigate(new AddEditAccidentsPage(null));
        }

        private void BigEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridAccidents.SelectedItem==null)
            {
                MessageBox.Show("Не был выбран элемент для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                Manager.TableFrame.Navigate(new AddEditAccidentsPage((Accident)DataGridAccidents.SelectedItem));
            }    
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var accidentsForRemoving = DataGridAccidents.SelectedItems.Cast<Accident>().ToList();
            if (MessageBox.Show($"Вы действительно хотите удалить следующие {accidentsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    DTP_Entities.GetContext().Accident.RemoveRange(accidentsForRemoving);
                    DTP_Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DataGridAccidents.ItemsSource = DTP_Entities.GetContext().Accident.ToList();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }


    }
}
