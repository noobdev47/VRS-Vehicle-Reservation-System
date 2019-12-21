﻿using System;
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
    /// Interaction logic for EntryOpDataGridWindow.xaml
    /// </summary>
    public partial class EntryOpDataGridWindow
    {
        Controller controller = Controller.giveInstance();

        public EntryOpDataGridWindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EntryOpDataGridWindow_Loaded(object sender, RoutedEventArgs e)
        {
            entryOpDataGrid.ItemsSource = controller.entryOpDataGridPopulator();
        }
    }
}