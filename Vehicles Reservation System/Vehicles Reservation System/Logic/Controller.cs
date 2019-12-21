using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vehicles_Reservation_System.Database;
using MahApps.Metro;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;

namespace Vehicles_Reservation_System.Logic
{
    class Controller
    {
        private static Controller controller = new Controller();

        Database_Communicator communicator = new Database_Communicator();

        private Controller() { }

        public static Controller giveInstance()
        {
            return controller;
        }

        //Controller for Admin Addition
        public string addAdmin(Administrator tempAdmin)
        {
            return communicator.addAdmin(tempAdmin);
        }

        #region Controllers for Authenticators

        //Admin Authentication at Login
        public string adminAuthenticator(string uname, string pword)
        {
            return communicator.adminAuthenticator(uname, pword);
        }

        //Manager Authentication at Login
        public string managerAuthenticator(string uname, string pword)
        {
            return communicator.managerAuthenticator(uname, pword);
        }

        //Entry Operator Authentication at Login
        public string entryOpAuthenticator(string uname, string pword)
        {
           return communicator.entryOpAuthenticator(uname, pword);
        }
        #endregion Controllers for Authenticators

        #region Controllers for DataGrid Populators

        //DataGrid Populator with Admin Data in Manager Dashboard
        public List<Object> adminDataGridPopulator()
        {
            return communicator.adminDataGridPopulator();
        }

        //DataGrid Populator with Entry Operator Data in Manager Dashboard
        public List<Object> entryOpDataGridPopulator()
        {
            return communicator.entryOpDataGridPopulator();
        }

        //DataGrid Populator with Reservation Data in Manager Dashboard
        public List<Object> bookingDataGridPopulator()
        {
            return communicator.bookingDataGridPopulator();
        }
        #endregion Controllers for DataGrid Populators

        #region Controllers for ID Incrementers

        //Incrementer for Customer Distinction at Addition Tab
        public int customerIdIncrementer()
        {
            return communicator.customerIDIncrementer();
        }

        //Incrementer for Vehicle Distinction at Addition Tab
        public int carIdIncrementer()
        {
            return communicator.carIDIncrementer();
        }

        //Incrementer for Reservation Distinction at Addition Tab
        public int bookingIdIncrementer()
        {
            return communicator.bookingIDIncrementer();
        }
        #endregion Controllers for ID Incrementers

        #region Controllers for ComboBox Populators
        public List<EntryOperator> entryOperatorComboBoxPopulator()
        {
            return communicator.entryOpComboBoxPopulator();
        }

        public List<Manager> managerComboBoxPopulator()
        {
            return communicator.managerComboBoxPopulator();
        }

        public List<Customer> customerComboBoxPopulator()
        {
            return communicator.customerComboBoxPopulator();
        }

        public List<Car> vehicleManagementComboBoxPopulator()
        {
            return communicator.vehicleManagementComboBoxPopulator();
        }

        public List<Booking> reservationComboBoxPopulator()
        {
            return communicator.ReservationComboBoxPopulator();
        }

        public List<Car> carComboBoxPopulator()
        {
            return communicator.carComboBoxPopulator();
        }
        #endregion Controllers for ComboBox Populators

        #region Controllers for Admin Dashboard
        public string addManager(Boss boss)
        {
            return communicator.addManager(boss);
        }

        public string updateManager(Boss boss, string uname)
        {
            return communicator.updateManager(boss, uname);
        }

        public Boss getManagerCredentials(string uname)
        {
            return communicator.managerCredentials(uname);
        }

        public string removeManager(string name)
        {
            return communicator.deleteManager(name);
        }

        //public string removeCustomer(string name)
        //{
        //    return communicator.deleteCustomer(name);
        //}

        public string addEntryOperator(EntryOp entryOp)
        {
            return communicator.addEntryOperator(entryOp);
        }

        public string updateEntryOperator(EntryOp entryOp, string uname)
        {
            return communicator.updateEntryOperator(entryOp, uname);
        }

        public EntryOp getEntryOperatorCredentials(string uname)
        {
            return communicator.entryOperatorCredentials(uname);
        }

        public string removeEntryOperator(string name)
        {
            return communicator.deleteEntryOperator(name);
        }

        #endregion Controllers for Admin Dashboard

        #region Controller for Entry Operator Dashboard
        public string addClient(Client tempClient)
        {
            return communicator.addCustomer(tempClient);
        }

        public string updateCustomer(Client client, int id)
        {
            return communicator.updateCustomer(client, id);
        }

        public bool removeClient(string name)
        {
            return communicator.deleteClient(name);
        }

        public Client getCustomerCredentials(int id)
        {
            return communicator.customerUpdateCredentials(id);
        }

        public Client getCustomerRemovalCredentials(string name)
        {
            return communicator.customerRemovalCredentials(name);
        }

        public Reservation getReservationDetails(int id)
        {
            return communicator.reservationDetails(id);
        }

        public void addBooking(List<Reservation> listOfReservation)
        {
            communicator.addBooking(listOfReservation);
        }
        #endregion Controller for Entry Operator Dashboard

        #region Controllers for Vehicle Module
        public string removeCar(int id)
        {
            return communicator.deleteVehicle(id);
        }

        public double getRatePerDay(int carId)
        {
            return communicator.giveRatePerDay(carId);
        }

        public string addCar(Vehicle tempVehicle)
        {
            return communicator.addVehicle(tempVehicle);
        }

        public void changeCarStatus(int id)
        {
            communicator.changeCarStatus(id);
        }

        public string updateStatus(string regNo, string status)
        {
            return communicator.updateStatus(regNo, status);
        }

        public string getStatus(string regNo)
        {
            return communicator.returnStatus(regNo);
        }
        #endregion Controllers for Vehicle Module

        #region Controllers for PDF Report
        public int getTotalBookings()
        {
            return communicator.totalBookingsToDate();
        }

        public int getThisMonthBookings()
        {
            return communicator.thisMonthBookings();
        }

        public double getTotalIncome()
        {
            return communicator.totalIncomeGenerated();
        }

        public double getThisMonthIncome()
        {
            return communicator.thisMonthIncomeGenerated();
        }

        public int gettotalCustomers()
        {
            return communicator.totalCustomers();
        }

        public int getThisMonthCustomers()
        {
            return communicator.thisMonthCustomers();
        }

        public int getTotalVehicles()
        {
            return communicator.totalVehicles();
        }

        public int getThisMonthVehicles()
        {
            return communicator.thisMonthVehicles();
        }

        public int getTotalSedans()
        {
            return communicator.totalSedans();
        }
        public int getTotalHybrids()
        {
            return communicator.totalHybrids();
        }
        public int getTotalJeeps()
        {
            return communicator.totalJeeps();
        }
        #endregion Controllers for PDF Report

        //public List<Object> getCustomerDetailsForInvoice(int id)
        //{
        //    return communicator.customerDetailForInvoice(id);
        //}
    }
}
