using System.ComponentModel;

namespace HotelIntegratedComputerSystems.Models.MaidService
{
    public class HouseKeepingViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int BuildingId { get; set; }

        [DisplayName("Building")]
        public string BuildingName { get; set; } //building table

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int HousekeepingStatusId { get; set; }

        [DisplayName("Clean Status")]
        public string HousekeepingCleanStatus { get; set; } //housekeeping table

        [DisplayName("Floor")]
        public int FloorNumber { get; set; }

        [DisplayName("Room")]
        public string RoomNumber { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int RoomStatusId { get; set; }

        [DisplayName("Room Status")]
        public string RoomStatusDescription { get; set; } //RoomStatus table
        [DisplayName("Bedding Type")]
        public string RoomBedding { get; set; }
    }
}