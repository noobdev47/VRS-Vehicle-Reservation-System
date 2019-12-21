using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles_Reservation_System.Logic
{
    sealed class Client
    {
        private int customerId;
        private string customerName;
        private double customerCnic;
        private int customerLicense;
        private double customerPhone;
        private string customerAddress;
        private string customerDoB;

        public Client(int id, string name, string address, double cnic, int license, double phone, string doB)
        {
            customerId = id;
            customerName = name;
            customerPhone = phone;
            customerCnic = cnic;
            customerLicense = license;
            customerAddress = address;
            customerDoB = doB;
        }

        public int getCustomerId()
        {
            return this.customerId;
        }

        public string getCustomerName()
        {
            return this.customerName;
        }

        public double getCustomerCnic()
        {
            return this.customerCnic;
        }

        public double getCustomerPhone()
        {
            return this.customerPhone;
        }

        public int getCustomerLicense()
        {
            return this.customerLicense;
        }

        public string getCustomerAddress()
        {
            return this.customerAddress;
        }

        public string getCustomerDoB()
        {
            return this.customerDoB;
        }
    }
}
