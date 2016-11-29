using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models.Admin;

namespace HotelIntegratedComputerSystems.Models.Employees
{
    public class BookingViewModel
    {
        [DisplayName("Booking #")]
        public int Id { get; set; }

        [DisplayName("Customer Name:")]
        public string CustomerName { get; set;}

        [DisplayName("Customer Id:")]
        public int CustomerId { get; set; }
        [DisplayName("Building")]

        [Required(ErrorMessage = "Field Requiered")]
        public string BuildingName { get; set; } //room

        [DisplayName("Floor")]
        [Required(ErrorMessage = "Field Requiered")]
        public int FloorNumber { get; set; } //room


        [DisplayName("Room #:")]
        public string RoomNumber { get; set;}

        [DisplayName("Room Id:")]
        public int RoomId { get; set; }

        [DisplayName("Start Date:")]
        public System.DateTime StartDate { get; set; }

        [DisplayName("End Date:")]
        public System.DateTime EndDate { get; set; }

        [DisplayName("Adults:")]
        public Nullable<int> VolumeAdults { get; set; }
        [DisplayName("Children:")]
        public Nullable<int> VolumeChildren { get; set; }

        public string BookingStatusDescription { get; set; }

        [DisplayName("Checked In:")]
        public Nullable<System.DateTime> CheckedInDate { get; set; }

        [DisplayName("Check Out:")]
        public Nullable<System.DateTime> CheckedOutDate { get; set; }

        [DisplayName("Booking Status:")]
        public int BookingStatusId { get; set; }

        [DisplayName("Total Cost:")]
        public decimal totalSum { get; set; }

        public string RoomType { get; set; }

        public string HouseKeepingStatus { get; set; }
        
        public virtual Room Room { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public List<RoomViewModel> RoomsList { get; set; }
        public virtual List<ExpensesViewModel> Expense { get; set; }
        public virtual List<CustomersViewModel> customers { get; set; }
    }
}