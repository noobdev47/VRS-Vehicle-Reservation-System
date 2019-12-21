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
//using Vehicles_Reservation_System.Database;
using Vehicles_Reservation_System.Logic;

namespace Vehicles_Reservation_System.UI
{
    /// <summary>
    /// Interaction logic for AdminDataGridWindow.xaml
    /// </summary>
    public partial class AdminDataGridWindow
    {
        //List<Admin> = new List<Admin>();

        Controller controller = Controller.giveInstance();

        public AdminDataGridWindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AdminGridDataWindow_Loaded(object sender, RoutedEventArgs e)
        {
            adminDataGrid.ItemsSource = controller.adminDataGridPopulator();
        }
    }
}
