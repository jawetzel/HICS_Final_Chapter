using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models.Employees;

namespace HotelIntegratedComputerSystems.Models.Admin
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        [DisplayName("Building")]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        [Required(ErrorMessage = "Select A Building")]
        public int BuildingId { get; set; }

        [DisplayName("Building")]
        public string BuildingName { get; set; }

        [DisplayName("Room Type")]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        [Required(ErrorMessage = "Select A Room Type")]
        public int RoomTypeId { get; set; }

        [DisplayName("Room Type")]
        public string RoomType { get; set; }

        [DisplayName("Housekeeping Status")]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int HouseKeepingStatusId { get; set; }

        [DisplayName("Housekeeping Status")]
        public string HouseKeepingStatus { get; set; }

        [DisplayName("RoomStatus")]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int RoomStatusId { get; set; }

        [DisplayName("Room Status")]
        public string RoomStatus { get; set; }

        [DisplayName("Floor")]
        [Range(1, int.MaxValue, ErrorMessage = "Number Provided Must Be Positive")]
        [Required(ErrorMessage = "Please Provide A Floor Number")]
        public int FloorNumber { get; set; }

        [DisplayName("Room")]
        [Required(ErrorMessage = "Please Provide A Room Number")]
        public string RoomNumber { get; set; }
        public List<BookingViewModel> BookingsList { get; set; }

        public RoomViewModel()
        {
            BookingsList = new List<BookingViewModel>();
        }
    }
}