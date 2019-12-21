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
    /// Interaction logic for EntryOperatorDashoard.xaml
    /// </summary>
    public partial class EntryOperatorDashoard
    {
        Notification notification = Notification.giveInstance();

        public string status = "Logged In as ";

        public EntryOperatorDashoard()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerManagement manageWindow3 = new CustomerManagement();
            manageWindow3.ShowDialog();
        }

        private void btnReservation_Click(object sender, RoutedEventArgs e)
        {
            ReservationManagement manageWindow4 = new ReservationManagement();
            manageWindow4.ShowDialog();
        }

        private void EntryOperatorDashboard_Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblLoggedIn.Content += status;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            notification.successNotifier("You've Logged Out");

            this.Close();
        }
    }
}
