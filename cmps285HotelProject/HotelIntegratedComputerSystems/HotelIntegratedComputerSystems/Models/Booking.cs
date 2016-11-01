namespace HotelIntegratedComputerSystems.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            this.Expense = new HashSet<Expenses>();
        }


        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
  
        public int RoomId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<int> VolumeAdults { get; set; }
        public Nullable<int> VolumeChildren { get; set; }
        public int BookingStatusId { get; set; }
        public Nullable<System.DateTime> CheckedInDate { get; set; }
        public Nullable<System.DateTime> CheckedOutDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expenses> Expense { get; set; }
        public virtual BookingStatus BookingStatus { get; set; }
    }
}
