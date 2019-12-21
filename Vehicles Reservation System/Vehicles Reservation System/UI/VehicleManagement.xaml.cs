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
using Vehicles_Reservation_System.Logic;
using Vehicles_Reservation_System.Database;

namespace Vehicles_Reservation_System.UI
{
    /// <summary>
    /// Interaction logic for VehicleManagement.xaml
    /// </summary>
    public partial class VehicleManagement
    {
        private int id;
        private string name;
        private string category;
        private string color;
        private string mfgDate;
        private float insuranceNo;
        private string regNo;
        private float ratePerDay;
        private string message;
        private string vehicleStatus;

        Controller controller = Controller.giveInstance();
        Notification notification = Notification.giveInstance();

        List<Car> vehicles = new List<Car>();

        public VehicleManagement()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tabAdd_Loaded(object sender, RoutedEventArgs e)
        {
            txtVehicleNo.Text = controller.carIdIncrementer().ToString();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            id = int.Parse(txtVehicleNo.Text);
            name = txtVehicleName.Text;
            category = cmbxCategory.Text;
            color = txtVehicleColor.Text;
            mfgDate = datePickerMfg.Text;
            insuranceNo = float.Parse(txtVehicleInsuranceNo.Text);
            regNo = txtVehicleRegNo.Text;
            ratePerDay = float.Parse(txtVehicleRatePerDay.Text);

            Vehicle tempVehicle = new Vehicle(id, name, category, color, mfgDate, insuranceNo, regNo, ratePerDay);

            name = controller.addCar(tempVehicle);

            notification.successNotifier(name + " has been added Successfully");
        }

        private void btnBack1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tabDelete_Loaded(object sender, RoutedEventArgs e)
        {
            vehicles = controller.vehicleManagementComboBoxPopulator();

            cmbxVehicleRegNo.ItemsSource = vehicles;
            cmbxVehicleRegNo.SelectedValuePath = "CAR_ID";
            cmbxVehicleRegNo.DisplayMemberPath = "REG_NO";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            regNo = cmbxVehicleRegNo.Text;

            regNo = controller.removeCar(id);

            if (regNo == cmbxVehicleRegNo.Text)
                notification.successNotifier(name + " has been removed Successfully");
            else
                notification.errorNotifier(name);
        }

        private void tabUpdate_Loaded(object sender, RoutedEventArgs e)
        {
            vehicles = controller.vehicleManagementComboBoxPopulator();

            cmbxVehicleRegNo1.ItemsSource = vehicles;
            cmbxVehicleRegNo1.SelectedValuePath = "REG_NO";
            cmbxVehicleRegNo1.DisplayMemberPath = "REG_NO";
        }

        private void cmbxVehicleRegNo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rdoBtnAvailable.IsEnabled = true;
            rdoBtnReserved.IsEnabled = true;
            
            regNo = cmbxVehicleRegNo1.SelectedValue.ToString();

            vehicleStatus = controller.getStatus(regNo);

            if (vehicleStatus != null)
            {
                txtUpdateStatus.Text = vehicleStatus;

                if (txtUpdateStatus.Text == "Available")
                    rdoBtnAvailable.IsEnabled = false;
                else
                    rdoBtnReserved.IsEnabled = false;
            }
            else
                notification.errorNotifier("Vehicle not Found");
        }

        private void btnBack2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (rdoBtnAvailable.IsChecked == true)
            {
                message = controller.updateStatus(regNo, "Available");
                notification.successNotifier(message);
            }
            else
            {
                message = controller.updateStatus(regNo, "Reserved");
                notification.successNotifier(message);
            }
        }
    }
}