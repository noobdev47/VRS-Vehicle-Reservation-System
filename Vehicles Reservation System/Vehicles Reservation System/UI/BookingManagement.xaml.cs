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
using Vehicles_Reservation_System.Database;
using Vehicles_Reservation_System.Logic;

namespace Vehicles_Reservation_System
{
    /// <summary>
    /// Interaction logic for BookingManagement.xaml
    /// </summary>
    public partial class BookingManagement
    {
        Controller controller3 = Controller.giveInstance();

        List<Customer> customers;
        List<Car> cars;

        int bookingId;
        int customerId;
        int carId;
        float bookingAmountDue;
        DateTime bookingDate;
        DateTime returnDate;

        public BookingManagement()
        {
            InitializeComponent();
        }

        private void Booking_Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtBookingId.Text = controller3.bookingIdIncrementer().ToString();
            txtDateToday.Text = DateTime.Now.ToString();

            customers = controller3.customerComboBoxPopulator();
            cars = controller3.carComboBoxPopulator();

            cmbxCustomer.ItemsSource = customers;
            cmbxCustomer.SelectedValuePath = "CUSTOMER_ID";
            cmbxCustomer.DisplayMemberPath = "NAME";

            cmbxCar.ItemsSource = cars;
            cmbxCar.SelectedValuePath = "CAR_ID";
            cmbxCar.DisplayMemberPath = "CAR_NAME";
        }

        private void btninsert_Click(object sender, RoutedEventArgs e)
        {
            bookingId = int.Parse(txtBookingId.Text);
            customerId = (int) cmbxCustomer.SelectedValue;
            carId = (int)cmbxCar.SelectedValue;
            bookingAmountDue = float.Parse(txtTotalAmount.Text);
            bookingDate = DateTime.Parse(txtDateToday.Text);
            returnDate = DateTime.Parse(returndate.Text);

            Reservation tempeservation = new Reservation(bookingId, customerId, carId, bookingAmountDue, bookingDate, returnDate);

            //controller3.addBooking(tempeservation);
        }

        private void selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            carId = (int)cmbxCar.SelectedValue;
            txtTotalAmount.Text = controller3.getRatePerDay(carId).ToString();
        }

    }
}
