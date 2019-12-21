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
using MahApps.Metro;
using MahApps.Metro.Controls.Dialogs;

namespace Vehicles_Reservation_System.UI
{
    /// <summary>
    /// Interaction logic for AdminRegisterWindow.xaml
    /// </summary>
    public partial class AdminRegisterWindow
    {
        private string uname;
        private string name;
        private string pword;
        private string confirmPword;

        Controller controller = Controller.giveInstance();
        Notification notification = Notification.giveInstance();

        public AdminRegisterWindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            uname = txtUname.Text;
            name = txtName.Text;
            pword = txtPword.Password;
            confirmPword = txtConfirmPword.Password;

            if (pword != confirmPword)
                notification.MessageDialog(this, "Error", "Passwords do not match");
            else
            {
                Administrator tempAdmin = new Administrator(uname, name, pword);

                name = controller.addAdmin(tempAdmin);

                if(name != null)
                {
                    notification.successNotifier(uname + " has Successfully Registered");

                    AdminDashboard adminBoard = new AdminDashboard();
                    adminBoard.status += uname;

                    adminBoard.Show();
                }
                else
                    notification.MessageDialog(this, "Error", "Username already exists");
                //this.Close();
            }
        }
    }
}
