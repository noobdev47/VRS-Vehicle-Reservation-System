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
    /// Interaction logic for ManagerManagement.xaml
    /// </summary>
    public partial class ManagerManagement
    {
        private string name;
        private string pword;
        private string uname;
        private string confirmPword;


        List<Manager> managers;

        Controller controller = Controller.giveInstance();
        Notification notification = Notification.giveInstance();

        public ManagerManagement()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            name = txtManagerName.Text;
            uname = txtManagerUname.Text;
            pword = txtPword.Password;
            confirmPword = txtConfirmPword.Password;

            if (pword != confirmPword)
                notification.MessageDialog(this, "Error", "Passwords do not match");
            else
            {
                Boss tempBoss = new Boss(uname, name, pword);

                name = controller.addManager(tempBoss);

                if (name != null)
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
            uname = cmbxUname.Text;
            name = txtManagerName1.Text;
            pword = txtPword1.Password;
            confirmPword = txtConfirmPword1.Password;

            if (pword != confirmPword)
                notification.MessageDialog(this, "Error", "Passwords dont match");
            else
            {
                Boss tempBoss = new Boss(uname, name, pword);

                name = controller.updateManager(tempBoss, tempBoss.getManagerName());

                notification.successNotifier(name + "'s Credentials Successfully Updated");
            }
        }

        private void tabUpdate_Loaded(object sender, RoutedEventArgs e)
        {
           managers = controller.managerComboBoxPopulator();

            cmbxUname.ItemsSource = managers;
            cmbxUname.SelectedValuePath = "MANAGER_UNAME";
            cmbxUname.DisplayMemberPath = "MANAGER_UNAME";  
        }

        private void cmbxUname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Boss boss = controller.getManagerCredentials(cmbxUname.SelectedValue.ToString());
            
            txtManagerName1.Text = boss.getManagerName();
            txtPword1.Password = boss.getManagerPword();
            txtConfirmPword1.Password = txtPword1.Password;
        }

        private void tabRemove_Loaded(object sender, RoutedEventArgs e)
        {
            managers = controller.managerComboBoxPopulator();

            cmbxName.ItemsSource = managers;
            cmbxName.SelectedValuePath = "MANAGER_NAME";
            cmbxName.DisplayMemberPath = "MANAGER_NAME";
        }

        private void cmbxName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Boss boss = controller.getManagerCredentials(cmbxName.SelectedValue.ToString());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            name = cmbxName.Text;

            name = controller.removeManager(name);

            if (name == cmbxName.Text)
                notification.successNotifier(name + "'s Record has been removed Successfully");
            else
                notification.errorNotifier(name);
        }

        private void btnBack1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBack2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
