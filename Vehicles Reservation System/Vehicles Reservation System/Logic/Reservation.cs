using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles_Reservation_System.Logic
{
    sealed class Reservation
    {
        private int bookingId;
        private int customerId;
        private int carId;
        private float bookingAmountDue;
        private DateTime bookingDate;
        private DateTime returnDate;

        public Reservation(int bId, int cusId, int cId, float amountDue, DateTime bDate, DateTime rDate)
        {
            bookingId = bId;
            customerId = cusId;
            carId = cId;
            bookingAmountDue = amountDue;
            bookingDate = bDate;
            returnDate = rDate;
        }

        public int getBookingId()
        {
            return this.bookingId;
        }

        public int getCustomerId()
        {
            return this.customerId;
        }

        public int getCarId()
        {
            return this.carId;
        }

        public float getBookingAmountDue()
        {
            return this.bookingAmountDue;
        }

        public DateTime getBookingDate()
        {
            return this.bookingDate;
        }

        public DateTime getReturnDate()
        {
            return this.returnDate;
        }
    }
}
