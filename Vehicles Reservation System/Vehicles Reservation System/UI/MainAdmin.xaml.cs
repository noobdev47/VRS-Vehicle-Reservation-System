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

namespace Vehicles_Reservation_System
{
    /// <summary>
    /// Interaction logic for MainAdmin.xaml
    /// </summary>
    public partial class MainAdmin : Window
    {
        public MainAdmin()
        {
            InitializeComponent();
        }

        
        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerManagement custWin = new CustomerManagement();
            this.Close();
            custWin.Show();
        }

        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            BookingManagement bookWin = new BookingManagement();
            this.Close();
            bookWin.Show();
        }

        private void btncar_Click(object sender, RoutedEventArgs e)
        {
            CarManagement carWin = new CarManagement();
            this.Close();
            carWin.Show();
        }
    }
}
