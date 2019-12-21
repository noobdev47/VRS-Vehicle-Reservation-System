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
using MahApps.Metro;

namespace Vehicles_Reservation_System.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdminDashboard_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow window1 = new AdminWindow();
            window1.ShowDialog();
        }

        private void btnEntryOperatorDashboard_Clicked(object sender, RoutedEventArgs e)
        {
            EntryOperatorLoginPanel window2 = new EntryOperatorLoginPanel();
            window2.ShowDialog();
        }

        private void btnManagerDashboard_Click(object sender, RoutedEventArgs e)
        {
            ManagerLoginPanel window3 = new ManagerLoginPanel();
            window3.ShowDialog();
        }
    }
}
