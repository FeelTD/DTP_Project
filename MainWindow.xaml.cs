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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TableFrame.Navigate(new TablePage());
            LicenseFrame.Navigate(new LicensePage());
            UserFrame.Navigate(new Pages.UserPage());
            Manager.TableFrame = TableFrame;
            Manager.LicenseFrame = LicenseFrame;
            Manager.UserFrame = UserFrame;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        private void TabItemUsers_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (AuthWindow.adminFound != null)
                TabItemUsers.Visibility = Visibility.Visible;
            else
                TabItemUsers.Visibility = Visibility.Collapsed;
        }
    }
}
