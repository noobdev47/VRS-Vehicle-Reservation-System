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

namespace Vehicles_Reservation_System
{
    /// <summary>
    /// Interaction logic for CarManagement.xaml
    /// </summary>
    public partial class CarManagement
    {
        Controller controller2 = Controller.giveInstance();

        int id;
        string name;
        string category;
        string color;
        string mfgDate;
        float insuranceNo;
        string regNo;
        float price;

        public CarManagement()
        {
            InitializeComponent();
        }

        private void car_Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtcarid.Text = controller2.carIdIncrementer().ToString();
        }

        private void btninsert_Click(object sender, RoutedEventArgs e)
        {
            id = int.Parse(txtcarid.Text);
            name = txtcarname.Text;
            category = cmbcategory.Text;
            color = txtcolor.Text;
            mfgDate = datetimemfd.Text;
            insuranceNo = float.Parse(txtinsurance.Text);
            regNo = txtregno.Text;
            price = float.Parse(txtdeilyprice.Text);

            Vehicle tempVehicle = new Vehicle(id, name, category, color, mfgDate, insuranceNo, regNo, price);

            controller2.addCar(tempVehicle);
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            id = int.Parse(txtdeleteandsearch.Text);

            controller2.removeCar(id);

            MessageBox.Show("Car #" + id.ToString() + " removed Succesfully", "Vehicle Reservation System");
        }




    }
}
