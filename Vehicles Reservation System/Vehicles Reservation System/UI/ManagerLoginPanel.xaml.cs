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

namespace Vehicles_Reservation_System.UI
{
    /// <summary>
    /// Interaction logic for ManagerLoginPanel.xaml
    /// </summary>
    public partial class ManagerLoginPanel
    {
        private string uname;
        private string pword;
        private string returnValue;

        Controller controller = Controller.giveInstance();
        Notification notification = Notification.giveInstance();

        public ManagerLoginPanel()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            uname = txtuname.Text;
            pword = txtpword.Password;

            returnValue = controller.managerAuthenticator(uname, pword);

            if (returnValue != uname)
                notification.errorNotifier(returnValue);
            else
            {
                ManagerDashboard dashboard1 = new ManagerDashboard();

                dashboard1.status += uname;

                notification.successNotifier(uname + " has Logged In Successfully");

                dashboard1.ShowDialog();

                this.Close();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
