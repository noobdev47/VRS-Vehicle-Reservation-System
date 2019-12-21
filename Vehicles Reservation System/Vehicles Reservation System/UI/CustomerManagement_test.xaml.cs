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
    /// Interaction logic for CustomerManagement.xaml
    /// </summary>
    public partial class CustomerManagement
    {
        Controller controller2 = Controller.giveInstance();

        int customerId;
        string customerName;
        float cnic;
        int license;
        float phone;
        string address;
        string doB;


        public CustomerManagement()
        {
            InitializeComponent();
        }

        private void customer_Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtcus.Text = controller2.customerIdIncrementer().ToString();
        }

        private void btninsert_Click(object sender, RoutedEventArgs e)
        {
            customerId = int.Parse(txtcus.Text);
            customerName = txtfname.Text;
            cnic = float.Parse(txtnicno.Text);
            license = int.Parse(txtlno.Text);
            phone = float.Parse(txtphoneno.Text);
            address = txtaddress.Text;
            doB = dateandtime.Text;

            Client tempClient = new Client(customerId, customerName, address, cnic, license, phone, doB);

            controller2.addClient(tempClient);
        }

        private void btndel_Click(object sender, RoutedEventArgs e)
        {
            customerId = int.Parse(txtdel.Text);

            //controller2.removeClient(customerId);

            MessageBox.Show("Customer #" + customerId.ToString() + " removed Succesfully", "Vehicle Reservation System");

        }
    }
}
