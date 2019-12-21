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
using Vehicles_Reservation_System.Logic;
using Vehicles_Reservation_System.Database;
using MahApps.Metro;

namespace Vehicles_Reservation_System.UI
{
    /// <summary>
    /// Interaction logic for ReservationManagement.xaml
    /// </summary>
    public partial class ReservationManagement
    {
        private string carStatus;
        private int bookingId;
        private int customerId;
        private int carId;
        private float bookingAmountDue;
        private DateTime bookingDate;
        private DateTime returnDate;

        private List<Customer> customers;
        private List<Car> cars;
        private List<Booking> bookings;
        private List<Reservation> vehiclesBooked = new List<Reservation>();


        Controller controller = Controller.giveInstance();
        Notification notification = Notification.giveInstance();
        PDFWriter writer = new PDFWriter();

        public ReservationManagement()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tabAdd_Loaded(object sender, RoutedEventArgs e)
        {
            txtReservationNo.Text = controller.bookingIdIncrementer().ToString();
            txtReservationDate.Text = DateTime.Now.ToString();

            customers = controller.customerComboBoxPopulator();
            cars = controller.carComboBoxPopulator();

            cmbxCustomerName.ItemsSource = customers;
            cmbxCustomerName.SelectedValuePath = "CUSTOMER_ID";
            cmbxCustomerName.DisplayMemberPath = "NAME";

            cmbxVehicleName.ItemsSource = cars;
            cmbxVehicleName.SelectedValuePath = "CAR_ID";
            cmbxVehicleName.DisplayMemberPath = "CAR_NAME";
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            bookingId = int.Parse(txtReservationNo.Text);
            customerId = (int)cmbxCustomerName.SelectedValue;
            carId = (int)cmbxVehicleName.SelectedValue;
            bookingAmountDue = float.Parse(txtAmountDue.Text);
            bookingDate = DateTime.Parse(txtReservationDate.Text);
            returnDate = DateTime.Parse(datePicker.Text);
            carStatus = "Reserved";

            Reservation tempReservation = new Reservation(bookingId, customerId, carId, bookingAmountDue, bookingDate, returnDate);

            vehiclesBooked.Add(tempReservation);

            controller.addBooking(vehiclesBooked);
            controller.changeCarStatus(carId);

            //List<Object> customer = controller.getCustomerDetailsForInvoice(customerId);

            //writer.invoiceWriter(customer);

            notification.successNotifier("Reservation has been made Successfully");
        }

        private void cmbxVehicleName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            carId = (int)cmbxVehicleName.SelectedValue;
            txtAmountDue.Text = controller.getRatePerDay(carId).ToString();
        }

        private void btnNextBooking_Click(object sender, RoutedEventArgs e)
        {
            bookingId = int.Parse(txtReservationNo.Text);
            customerId = (int)cmbxCustomerName.SelectedValue;
            carId = (int)cmbxVehicleName.SelectedValue;
            bookingAmountDue = float.Parse(txtAmountDue.Text);
            bookingDate = DateTime.Parse(txtReservationDate.Text);
            returnDate = DateTime.Parse(datePicker.Text);

            Reservation tempReservation = new Reservation(bookingId, customerId, carId, bookingAmountDue, bookingDate, returnDate);

            vehiclesBooked.Add(tempReservation);

            txtReservationNo.Text = controller.bookingIdIncrementer().ToString();
            //txtReservationDate.Text = DateTime.Now.ToString();

            txtAmountDue.Text = null;

        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime reservationDate = DateTime.Parse(txtReservationDate.Text);
            int reservationDay = DateTime.Parse(txtReservationDate.Text).Day;
            int reservationMonth = DateTime.Parse(txtReservationDate.Text).Month;
            int dayDifference;
            int monthDifference;
            float totalCalculator = 0;

            //txtAmountDue.Text = bookingAmountDue.ToString();

            //totalCalculator = float.Parse(txtAmountDue.Text);

            if (reservationDate.Month == datePicker.SelectedDate.Value.Month)
            {
                int returnDay = datePicker.SelectedDate.Value.Day;

                //dayDifference = (returnDay - reservationDate.Day) - 1;

                //totalCalculator = float.Parse(txtAmountDue.Text) * dayDifference;

                do
                {
                    reservationDay++;
                    totalCalculator += float.Parse(txtAmountDue.Text);

                } while (returnDay != reservationDay);

                txtAmountDue.Text = totalCalculator.ToString();

                //if (returnDay > reservationDate.Day)
                //{
                //    dayDifference = returnDay - reservationDate.Day;

                //    totalCalculator = float.Parse(txtAmountDue.Text) * dayDifference;

                //    txtAmountDue.Text = totalCalculator.ToString();
                //}
                //else if(returnDay < reservationDate.Day)
                //{
                //    dayDifference = reservationDate.Day - returnDay;

                //    totalCalculator = float.Parse(txtAmountDue.Text) * dayDifference;

                //    txtAmountDue.Text = totalCalculator.ToString();
                //}
            }
            else if (reservationDate.Month > datePicker.SelectedDate.Value.Month)
            {
                int returnDay = datePicker.SelectedDate.Value.Day;

                monthDifference = reservationDate.Month - datePicker.SelectedDate.Value.Month;

                do
                {
                    if (reservationDay == 30)
                    {
                        totalCalculator += totalCalculator;
                        reservationDay = 1;
                    }
                    else
                    {
                        totalCalculator += totalCalculator;
                        reservationDay++;
                    }
                } while (returnDay != reservationDate.Day);

                txtAmountDue.Text = totalCalculator.ToString();

                //if (returnDay > reservationDate.Day)
                //{
                //    dayDifference = returnDay - reservationDate.Day;

                //    totalCalculator = float.Parse(txtAmountDue.Text) * dayDifference;

                //    txtAmountDue.Text = totalCalculator.ToString();
                //}
                //else if (returnDay < reservationDate.Day)
                //{
                //    dayDifference = reservationDate.Day - returnDay;

                //    totalCalculator = float.Parse(txtAmountDue.Text) * dayDifference;

                //    txtAmountDue.Text = totalCalculator.ToString();
                //}
            }

        }

        //private void datePicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    DateTime reservationDate = DateTime.Parse(txtReservationDate.Text);
        //    int reservationDay = DateTime.Parse(txtReservationDate.Text).Day;
        //    int reservationMonth = DateTime.Parse(txtReservationDate.Text).Month;
        //    // int dayDifference;
        //    int monthDifference;
        //    float totalCalculator = float.Parse(txtAmountDue1.Text);

        //    int returnDay = datePicker1.SelectedDate.Value.Day;

        //    if (datePicker1.SelectedDate.Value.Year < reservationDate.Year)
        //    {
        //        notification.MessageDialog(this, "Error", "Previous Date Selected");
        //        datePicker1.Text = "";
        //    }
        //    else if (datePicker1.SelectedDate.Value.Year == reservationDate.Year && datePicker1.SelectedDate.Value.Month < reservationDate.Month)
        //    {
        //        notification.MessageDialog(this, "Error", "Previous Date Selected");
        //        datePicker.Text = "";
        //    }
        //    else if (datePicker1.SelectedDate.Value.Year == reservationDate.Year && datePicker1.SelectedDate.Value.Month == reservationDate.Month && datePicker1.SelectedDate.Value.Day < reservationDate.Day)
        //    {
        //        notification.MessageDialog(this, "Error", "Previous Date Selected");
        //        datePicker1.Text = "";
        //    }
        //    else if (datePicker1.SelectedDate.Value.Year > reservationDate.Year && datePicker1.SelectedDate.Value.Month < reservationDate.Month)
        //    {
        //        notification.MessageDialog(this, "Error", "Previous Date Selected");
        //        datePicker1.Text = "";
        //    }
        //    else if (datePicker1.SelectedDate.Value.Year > reservationDate.Year && datePicker1.SelectedDate.Value.Month > reservationDate.Month && datePicker1.SelectedDate.Value.Day < reservationDate.Day)
        //    {
        //        notification.MessageDialog(this, "Error", "Previous Date Selected");
        //        datePicker1.Text = "";
        //    }
        //    else if (reservationDate.Month == datePicker1.SelectedDate.Value.Month)
        //    {
        //        do
        //        {
        //            reservationDay++;
        //            totalCalculator += totalCalculator;

        //        } while (returnDay != reservationDay);

        //        txtAmountDue1.Text = totalCalculator.ToString();

        //        //if (returnDay > reservationDate.Day)
        //        //{
        //        //    dayDifference = returnDay - reservationDate.Day;

        //        //    totalCalculator = float.Parse(txtAmountDue.Text) * dayDifference;

        //        //    txtAmountDue.Text = totalCalculator.ToString();
        //        //}
        //        //else if(returnDay < reservationDate.Day)
        //        //{
        //        //    dayDifference = reservationDate.Day - returnDay;

        //        //    totalCalculator = float.Parse(txtAmountDue.Text) * dayDifference;

        //        //    txtAmountDue.Text = totalCalculator.ToString();
        //        //}
        //    }
        //    else if (reservationDate.Month > datePicker1.SelectedDate.Value.Month)
        //    {
        //        monthDifference = reservationDate.Month - datePicker1.SelectedDate.Value.Month;

        //        do
        //        {
        //            if (reservationDay == 30)
        //            {
        //                totalCalculator += totalCalculator;
        //                reservationDay = 1;
        //            }
        //            else
        //            {
        //                totalCalculator += totalCalculator;
        //                reservationDay++;
        //            }
        //        } while (returnDay != reservationDate.Day);

        //        txtAmountDue1.Text = totalCalculator.ToString();

        //        //if (returnDay > reservationDate.Day)
        //        //{
        //        //    dayDifference = returnDay - reservationDate.Day;

        //        //    totalCalculator = float.Parse(txtAmountDue.Text) * dayDifference;

        //        //    txtAmountDue.Text = totalCalculator.ToString();
        //        //}
        //        //else if (returnDay < reservationDate.Day)
        //        //{
        //        //    dayDifference = reservationDate.Day - returnDay;

        //        //    totalCalculator = float.Parse(txtAmountDue.Text) * dayDifference;

        //        //    txtAmountDue.Text = totalCalculator.ToString();
        //        //}
        //    }
        //}

        private void tabUpdate_Loaded(object sender, RoutedEventArgs e)
        {
            bookings = controller.reservationComboBoxPopulator();

            cmbxReservationNo.ItemsSource = bookings;
            cmbxReservationNo.SelectedValuePath = "BOOKING__ID";
            cmbxReservationNo.DisplayMemberPath = "BOOKING__ID";
        }

        //private void btnInsert1_Click(object sender, RoutedEventArgs e)
        //{
        //    bookingId = int.Parse(txtReservationNo.Text);
        //    customerId = (int)cmbxCustomerName.SelectedValue;
        //    carId = (int)cmbxVehicleName.SelectedValue;
        //    bookingAmountDue = float.Parse(txtAmountDue.Text);
        //    bookingDate = DateTime.Parse(txtReservationDate.Text);
        //    returnDate = DateTime.Parse(datePicker.Text);

        //    Reservation tempReservation = new Reservation(bookingId, customerId, carId, bookingAmountDue, bookingDate, returnDate);

        //    vehiclesBooked.Add(tempReservation);

        //    controller.addBooking(vehiclesBooked);
        //}

        private void btnBack1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void cmbxReservationNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Reservation reservation = controller.getReservationDetails((int)cmbxReservationNo.SelectedValue);

        //    txtAmountDue1.Text = reservation.getBookingAmountDue().ToString();
        //    txtCustomerId.Text = reservation.getCustomerId().ToString();
        //}

        //private void cmbxReservationNo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        //{
        //    //Client client = controller.getCustomerCredentials((int) cmbxCustomerNo.SelectedValue);

        //    Reservation tempReservation = controller.getReservationDetails((int)cmbxReservationNo.SelectedValue);

        //    //bookingId = int.Parse(txtReservationNo.Text);
        //    txtAmountDue1.Text = tempReservation.getBookingAmountDue().ToString();
        //    txtCustomerId.Text = tempReservation.getCustomerId().ToString();
        //    txtVehicleReserved.Text = tempReservation.getCarId().ToString();
        //    txtReservationDate.Text = tempReservation.getBookingDate().ToString();
        //    datePicker.Text = tempReservation.getReturnDate().ToString();

        //    //List<Object> customer = controller.getCustomerDetailsForInvoice(customerId);

        //    //writer.invoiceWriter(customer);

        //    //notification.successNotifier("Reservation has been made Successfully");
        //}

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            bookingId = int.Parse(txtReservationNo.Text);
            customerId = (int)cmbxCustomerName.SelectedValue;
            carId = (int)cmbxVehicleName.SelectedValue;
            bookingAmountDue = float.Parse(txtAmountDue.Text);
            bookingDate = DateTime.Parse(txtReservationDate.Text);
            returnDate = DateTime.Parse(datePicker.Text);

            Reservation tempReservation = new Reservation(bookingId, customerId, carId, bookingAmountDue, bookingDate, returnDate);

            vehiclesBooked.Add(tempReservation);

            controller.addBooking(vehiclesBooked);
        }

        private void cmbxReservationNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reservation tempReservation = controller.getReservationDetails((int)cmbxReservationNo.SelectedValue);

            //bookingId = int.Parse(txtReservationNo.Text);
            txtAmountDue1.Text = tempReservation.getBookingAmountDue().ToString();
            txtCustomerId.Text = tempReservation.getCustomerId().ToString();
            txtVehicleReserved.Text = tempReservation.getCarId().ToString();
            txtReservationDate1.Text = tempReservation.getBookingDate().ToString();
            datePicker1.Text = tempReservation.getReturnDate().ToString();
        }
    }
}
