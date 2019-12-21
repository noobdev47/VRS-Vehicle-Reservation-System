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
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard
    {
        Notification notification = Notification.giveInstance();

        public string status = "Logged In as ";

        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblLoggedIn.Content += status;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            notification.successNotifier("You've Logged Out");

            this.Close();
        }

        private void btnManager_Click(object sender, RoutedEventArgs e)
        {
            ManagerManagement manageWindow1 = new ManagerManagement();
            manageWindow1.ShowDialog();
        }

        private void btnEntryOp_Click(object sender, RoutedEventArgs e)
        {
            EntryOperatorManagement manageWindow2 = new EntryOperatorManagement();
            manageWindow2.ShowDialog();
        }
    }
}
