using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Room Not Provided")]
        public string BuildingName { get; set; } //room > Building
        [Required(ErrorMessage = "Room Not Provided")]
        public int Floor { get; set; } //Room
        [Required(ErrorMessage = "Room Not Provided")]
        public string RoomNumber { get; set; } //room
        [Required(ErrorMessage = "Description Not Provided")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Date Not Provided")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public int MaintenanceTypeId { get; set; }
        [Required(ErrorMessage = "Maintenance Type Not Provided")]
        public string MaintenanceType { get; set; }
    }
}