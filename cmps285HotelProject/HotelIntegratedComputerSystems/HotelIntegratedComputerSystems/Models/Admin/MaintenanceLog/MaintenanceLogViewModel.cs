using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace HotelIntegratedComputerSystems.Models.Admin.MaintenanceLog
{
    public class MaintenanceLogViewModel
    {       
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int BuildingId { get; set; } //rooom
        public string BuildingName { get; set; } //room > Building
        public int Floor { get; set; } //Room
        public string RoomNumber { get; set; } //room
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int MaintenanceTypeId { get; set; }
        public string MaintenanceType { get; set; }
    }
}