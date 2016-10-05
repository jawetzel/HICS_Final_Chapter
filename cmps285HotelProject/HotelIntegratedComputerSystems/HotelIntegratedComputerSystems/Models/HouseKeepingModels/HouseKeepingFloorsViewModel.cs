using System.Collections.Generic;

namespace HotelIntegratedComputerSystems.Models.HouseKeepingModels
{
    public class HouseKeepingFloorsViewModel
    {
        public List<RoomsViewModel> RoomsOnFloor { get; set; }
        public int RoomId { get; set; }
    }
}