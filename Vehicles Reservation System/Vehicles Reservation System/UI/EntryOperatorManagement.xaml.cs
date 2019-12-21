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
using MahApps.Metro;

namespace Vehicles_Reservation_System.UI
{
    /// <summary>
    /// Interaction logic for EntryOperatorManagement.xaml
    /// </summary>
    public partial class EntryOperatorManagement
    {
        private string name;
        private string pword;
        private string uname;
        private string confirmPword;

        List<EntryOperator> entryOperators;

        Controller controller = Controller.giveInstance();
        Notification notification = Notification.giveInstance();

        public EntryOperatorManagement()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            name = txtEntryOpName.Text; 
            uname = txtEntryOpUname.Text;
            pword = txtEntryOpPword.Password;
            confirmPword = txtEntryOpConfirmPword.Password;

            if (pword != confirmPword)
                notification.MessageDialog(this, "Error", "Passwords do not match");
            else
            {
                EntryOp tempEntryOp = new EntryOp(uname, name, pword);

                name = controller.addEntryOperator(tempEntryOp);

                if(name != null)
                {
                    notification.successNotifier(name + " Successfully Registered");
                }
                else
                {
                    notification.MessageDialog(this, "Error", "Username already exists");
                }

            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            uname = cmbxEntryOpUname.Text;
            name = txtEntryOpName1.Text;
            pword = txtEntryOpPword1.Password;
            confirmPword = txtEntryOpConfirmPword1.Password;

            if (pword != confirmPword)
                notification.MessageDialog(this, "Error", "Passwords dont match");
            else
            {
                EntryOp tempEntryOp = new EntryOp(uname, name, pword);

                name = controller.updateEntryOperator(tempEntryOp, tempEntryOp.getEntryOpName());

                notification.successNotifier(name + "'s Credentials Successfully Updated");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            name = cmbxEntryOpName.Text;

            name = controller.removeEntryOperator(name);

            if (name == cmbxEntryOpName.Text)
                notification.successNotifier(name + "'s Record has been removed Successfully");
            else
                notification.errorNotifier(name);
        }

        private void tabUpdate_Loaded(object sender, RoutedEventArgs e)
        {
            entryOperators = controller.entryOperatorComboBoxPopulator();

            cmbxEntryOpUname.ItemsSource = entryOperators;
            cmbxEntryOpUname.SelectedValuePath = "UNAME";
            cmbxEntryOpUname.DisplayMemberPath = "UNAME";
        }

        private void cmbxEntryOpUname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EntryOp entryOp = controller.getEntryOperatorCredentials(cmbxEntryOpUname.SelectedValue.ToString());

            txtEntryOpName1.Text = entryOp.getEntryOpName();
            txtEntryOpPword1.Password = entryOp.getEntryOpPword();
            txtEntryOpConfirmPword1.Password = txtEntryOpPword1.Password;
        }

        private void tabRemove_Loaded(object sender, RoutedEventArgs e)
        {
            entryOperators = controller.entryOperatorComboBoxPopulator();

            cmbxEntryOpName.ItemsSource = entryOperators;
            cmbxEntryOpName.SelectedValuePath = "ENTRYOP_NAME";
            cmbxEntryOpName.DisplayMemberPath = "ENTRYOP_NAME";
        }

        private void cmbxEntryOpName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EntryOp entryOp = controller.getEntryOperatorCredentials(cmbxEntryOpName.SelectedValue.ToString());
        }

        private void btnBack2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBack1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
