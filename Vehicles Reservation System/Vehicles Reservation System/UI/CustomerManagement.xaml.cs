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
    /// Interaction logic for CustomerManagement.xaml
    /// </summary>
    public partial class CustomerManagement
    {
        private int id;
        private string name;
        private float cnic;
        private int license;
        private float phone;
        private string address;
        private string doB;
        private bool returnValue;

        Controller controller = Controller.giveInstance();
        Notification notification = Notification.giveInstance();

        List<Customer> customers;

        public CustomerManagement()
        {
            InitializeComponent();
        }

        private void CustomerManagementWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtCustomerNo.Text = controller.customerIdIncrementer().ToString();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            id = int.Parse(txtCustomerNo.Text);
            name = txtCustomerName.Text;
            cnic = float.Parse(txtCustomerCnic.Text);
            license = int.Parse(txtCustomerLicenseNo.Text);
            phone = float.Parse(txtCustomerContact.Text);
            address = txtCustomerAddress.Text;
            doB = datePicker.Text;

            Client tempClient = new Client(id, name, address, cnic, license, phone, doB);

            name = controller.addClient(tempClient);

            if (name != null)
            {
                notification.successNotifier(name + "'s record has been Inserted Successfully");
            }
            else
            {
                notification.MessageDialog(this, "Error", "CNIC already exists");
            }
        }

        private void btnBack1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBack3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tabUpdate_Loaded(object sender, RoutedEventArgs e)
        {
            customers = controller.customerComboBoxPopulator();

            cmbxCustomerNo.ItemsSource = customers;
            cmbxCustomerNo.SelectedValuePath = "CUSTOMER_ID";
            cmbxCustomerNo.DisplayMemberPath = "CUSTOMER_ID";
        }

        private void tabRemove_Loaded(object sender, RoutedEventArgs e)
        {
            customers = controller.customerComboBoxPopulator();

            cmbxCustomerName.ItemsSource = customers;
            cmbxCustomerName.SelectedValuePath = "NAME";
            cmbxCustomerName.DisplayMemberPath = "NAME";
        }

        private void btnBack2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbxCustomerName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client client = controller.getCustomerRemovalCredentials(cmbxCustomerName.SelectedValue.ToString());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            name = cmbxCustomerName.Text;

            returnValue = controller.removeClient(name);

            if (returnValue == true)
                notification.successNotifier(name + "'s Record has been removed Successfully");
            else
                notification.errorNotifier(name);
        }

        private void cmbxCustomerNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client client = controller.getCustomerCredentials((int) cmbxCustomerNo.SelectedValue);

            txtCustomerName1.Text = client.getCustomerName();
            txtCustomerAddress1.Text = client.getCustomerAddress();
            txtCustomerCnic1.Text = client.getCustomerCnic().ToString();
            txtCustomerLicenseNo1.Text = client.getCustomerLicense().ToString();
            txtCustomerContact1.Text = client.getCustomerPhone().ToString();
            datePicker1.Text = client.getCustomerDoB();
        }

        private void btnInsert1_Click(object sender, RoutedEventArgs e)
        {
            id = int.Parse(cmbxCustomerNo.Text);
            name = txtCustomerName1.Text;
            cnic = float.Parse(txtCustomerCnic1.Text);
            license = int.Parse(txtCustomerLicenseNo1.Text);
            phone = float.Parse(txtCustomerContact1.Text);
            address = txtCustomerAddress1.Text;
            doB = datePicker1.Text;

            Client tempClient = new Client(id, name, address, cnic, license, phone, doB);

            name = controller.updateCustomer(tempClient, id);

            notification.successNotifier(name + "'s record has been Inserted Successfully");
        }
    }
}
