namespace HotelIntegratedComputerSystems.Models.HouseKeepingModels
{
    public class RoomsViewModel
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int HousekeepingStatusId { get; set; }
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public int RoomStatusId { get; set; }
        public string CleanStatus { get; set; } //Housekeeping table
        public string Description { get; set; } //RoomStatus table
    }
}