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
    /// Interaction logic for AddEditAccidentsPage.xaml
    /// </summary>
    public partial class AddEditAccidentsPage : Page
    {
        private Accident _currentAccident = new Accident();
        public AddEditAccidentsPage()
        {
            InitializeComponent();
            DataContext = _currentAccident;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errorString = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentAccident.Address))
                errorString.AppendLine("Адрес должен быть указан");

            if (errorString.Length>0)
            {
                MessageBox.Show(errorString.ToString());
                    return;
            }

            if (_currentAccident.AccidentID == 0)
                DTP_Entities.GetContext().Accident.Add(_currentAccident);

            try 
            {
                DTP_Entities.GetContext().SaveChanges(); 
                Manager.TableFrame.GoBack();
                MessageBox.Show("Информация сохранена!");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public AddEditAccidentsPage(Accident selectedAccident)
        {
            InitializeComponent();

            if (selectedAccident != null)
                _currentAccident = selectedAccident;

            DataContext = _currentAccident;
        }

        private void GoBackwardButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.TableFrame.GoBack();
        }
    }
}
