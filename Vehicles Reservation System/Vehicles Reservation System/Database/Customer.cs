//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vehicles_Reservation_System.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Bookings = new HashSet<Booking>();
        }
    
        public int CUSTOMER_ID { get; set; }
        public string NAME { get; set; }
        public int LICENSE_NO { get; set; }
        public double CNIC { get; set; }
        public double PHONE { get; set; }
        public string DOB { get; set; }
        public string ADDRESS { get; set; }
        public System.DateTime DATE_OF_REG { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
