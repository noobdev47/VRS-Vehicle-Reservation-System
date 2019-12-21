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
using MahApps.Metro.Controls;
using Vehicles_Reservation_System.Logic;

namespace Vehicles_Reservation_System.UI
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow
    {
        private string uname;
        private string pword;
        private string returnValue;

        Controller controller = Controller.giveInstance();
        Notification notification = Notification.giveInstance();

        public AdminWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            uname = txtuname.Text;
            pword = txtpword.Password;

            returnValue = controller.adminAuthenticator(uname, pword);

            if (returnValue != uname)
                notification.errorNotifier(returnValue);
            else
            {
                AdminDashboard dashboard1 = new AdminDashboard();

                notification.successNotifier(uname + " has Logged In Successfully");

                dashboard1.status += uname;

                dashboard1.ShowDialog();

                //this.Close();
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            AdminRegisterWindow window1 = new AdminRegisterWindow();
            window1.ShowDialog();
        }
    }
}