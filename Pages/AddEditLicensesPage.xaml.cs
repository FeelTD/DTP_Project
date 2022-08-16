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
    /// Interaction logic for AddEditLicensesPage.xaml
    /// </summary>
    public partial class AddEditLicensesPage : Page
    {
        private DrivingLicense _currentLicense = new DrivingLicense();
        public AddEditLicensesPage()
        {
            InitializeComponent();
            DataContext = _currentLicense;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errorString = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentLicense.DrivingLicenseNumber))
                errorString.AppendLine("Номер должен быть указан");
            if (string.IsNullOrWhiteSpace(_currentLicense.GIBDDCode))
                errorString.AppendLine("Код подразделения должен быть указан");
            if (string.IsNullOrWhiteSpace(_currentLicense.PlaceOfResidence))
                errorString.AppendLine("Место жительства должно быть указано");

            if (errorString.Length > 0)
            {
                MessageBox.Show(errorString.ToString());
                return;
            }

            if (_currentLicense.DrivingLicenseID == 0)
                DTP_Entities.GetContext().DrivingLicense.Add(_currentLicense);

            try
            {
                DTP_Entities.GetContext().SaveChanges();
                Manager.LicenseFrame.GoBack();
                MessageBox.Show("Информация сохранена!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void GoBackwardButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.LicenseFrame.GoBack();
        }

        public AddEditLicensesPage(DrivingLicense selectedLicense)
        {
            InitializeComponent();

            if (selectedLicense != null)
                _currentLicense = selectedLicense;

            DataContext = _currentLicense;
            //_ComboBoxName_.ItemsSource = DTP_Entites.GetContext()._FieldName_.ToList();
        }
    }
}
