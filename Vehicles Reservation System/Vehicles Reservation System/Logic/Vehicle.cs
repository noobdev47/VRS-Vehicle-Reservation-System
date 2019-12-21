using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles_Reservation_System.Logic
{
    sealed class Vehicle
    {
        private int carID;
        private string carName;
        private string carCategory;
        private string carColor;
        private string carMfgDate;
        private float carInsuranceNo;
        private string carRegNo;
        private float carRatePerDay;

        public Vehicle(int id, string name, string category, string color, string mfgDate, float insuranceNo, string regNo, float ratePerDay)
        {
            carID = id;
            carName = name;
            carCategory = category;
            carColor = color;
            carMfgDate = mfgDate;
            carInsuranceNo = insuranceNo;
            carRegNo = regNo;
            carRatePerDay = ratePerDay;
        }

        public int getCarId()
        {
            return this.carID;
        }

        public string getCarName()
        {
            return this.carName;
        }

        public string getCarCategory()
        {
            return this.carCategory;
        }

        public string getCarColor()
        {
            return this.carColor;
        }

        public string getCarMfgDate()
        {
            return this.carMfgDate;
        }

        public float getCarInsurance()
        {
            return this.carInsuranceNo;
        }

        public string getCarRegNo()
        {
            return this.carRegNo;
        }

        public float getCarRatePerDay()
        {
            return this.carRatePerDay;
        }
    }
}
