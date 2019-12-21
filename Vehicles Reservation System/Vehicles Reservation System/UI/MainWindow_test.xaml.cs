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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vehicles_Reservation_System.Logic;

namespace Vehicles_Reservation_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller1 = Controller.giveInstance();

        string uname;
        string pword;
        string returnValue;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            uname = unameTextBox.Text;
            pword = pwordTextBox.Password;

            returnValue = controller1.entryOpAuthenticator(uname, pword);

            if (returnValue != uname)
            {
                MessageBox.Show(returnValue, "Vehicle Reservation System");
                this.Show();
            }
            else
            {
                MessageBox.Show(returnValue + " Logged In Succesfully", "Vehicle Reservation System");

                MainAdmin adminWin = new MainAdmin();
                this.Close();
                adminWin.Show();
            }

            
        }
    }
}