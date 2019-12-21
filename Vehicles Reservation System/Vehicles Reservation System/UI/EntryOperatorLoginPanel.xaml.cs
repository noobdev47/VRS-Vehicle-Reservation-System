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
    /// Interaction logic for EntryOperatorLoginPanel.xaml
    /// </summary>
    public partial class EntryOperatorLoginPanel
    {
        private string uname;
        private string pword;
        private string returnValue;

        Controller controller = Controller.giveInstance();
        Notification notification = Notification.giveInstance();

        public EntryOperatorLoginPanel()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            uname = txtuname.Text;
            pword = txtpword.Password;

            returnValue = controller.entryOpAuthenticator(uname, pword);

            if (returnValue != uname)
                notification.errorNotifier(returnValue);
            else
            {
                EntryOperatorDashoard dashboard2 = new EntryOperatorDashoard();

                dashboard2.status += uname;

                notification.successNotifier(uname + " has Logged In Successfully");

                dashboard2.ShowDialog();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}