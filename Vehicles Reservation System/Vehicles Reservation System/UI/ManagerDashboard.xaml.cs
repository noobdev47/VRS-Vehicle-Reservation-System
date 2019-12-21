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
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Vehicles_Reservation_System.Logic;
using MahApps.Metro;
using Vehicles_Reservation_System.Database;

namespace Vehicles_Reservation_System.UI
{
    /// <summary>
    /// Interaction logic for ManagerDashboard.xaml
    /// </summary>
    public partial class ManagerDashboard
    {
        Controller controller = Controller.giveInstance();
        Notification notification = Notification.giveInstance();
        PDFWriter writer = new PDFWriter();

        List<Object> carsBooked = new List<Object>();

        public string status = "Logged In as ";

        public ManagerDashboard()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            notification.successNotifier("You've Logged Out");

            this.Close();
        }

        private void btnViewEntryOps_Click(object sender, RoutedEventArgs e)
        {
            EntryOpDataGridWindow window2 = new EntryOpDataGridWindow();

            window2.ShowDialog();
        }

        private void btnViewAdmins_Click(object sender, RoutedEventArgs e)
        {
            AdminDataGridWindow window1 = new AdminDataGridWindow();

            window1.ShowDialog();
        }

        private void btnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            int totalBookings = controller.getTotalBookings();
            int thisMonthBookings = controller.getThisMonthBookings();
            double totalIncome = controller.getTotalIncome();
            double thisMonthIncome = controller.getThisMonthIncome();
            int totalCustomers = controller.gettotalCustomers();
            int thisMonthCustomers = controller.getThisMonthCustomers();
            int totalVehicles = controller.getTotalVehicles();
            int thisMonthVehicles = controller.getThisMonthVehicles();
            int totalSedans = controller.getTotalSedans();
            int totalHybrids = controller.getTotalHybrids();
            int totalJeeps = controller.getTotalJeeps();

            writer.reportWriter(totalBookings, totalIncome, thisMonthIncome, 
                                thisMonthBookings, totalCustomers, thisMonthCustomers, 
                                totalVehicles, thisMonthVehicles, totalSedans, totalHybrids, totalJeeps);

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PDF document (*.pdf)|*.pdf";

            fileDialog.ShowDialog();

            string command = @"C:\Users\Sumair Saif\Documents\Visual Studio 2013\Projects\Vehicles Reservation System\Vehicles Reservation System\bin\Debug\VRS-Report.pdf";

            var process = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo(command)
            };

            process.Start();
        }

        private void btnViewCars_Click(object sender, RoutedEventArgs e)
        {
            VehicleManagement window2 = new VehicleManagement();

            window2.ShowDialog();
        }

        private void btnViewBookings_Click(object sender, RoutedEventArgs e)
        {
            BookingDataGridWindow window = new BookingDataGridWindow();
            window.ShowDialog();
        }

        private void ManagerDashboard_Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblLoggedIn.Content += status;
        }
    }
}