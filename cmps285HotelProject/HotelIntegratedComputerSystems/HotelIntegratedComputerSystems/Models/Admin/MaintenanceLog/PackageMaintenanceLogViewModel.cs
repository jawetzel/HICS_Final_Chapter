using System.Collections.Generic;

namespace HotelIntegratedComputerSystems.Models.Admin.MaintenanceLog
{
    public class PackageMaintenanceLogViewModel
    {
        public List<MaintenanceLogViewModel> MaintenanceLogsList { get; set; }
        public MaintenanceLogViewModel MaintenanceLog { get; set; }
        public List<RoomViewModel> RoomsList { get; set; }
        public RoomViewModel Room { get; set; }
        public List<MaintenanceTypeViewModel> MaintenanceTypeList { get; set; }
    }
}