using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelIntegratedComputerSystems.Models.Admin
{
    public class MaintenanceTypeViewModel
    {
        public int Id { get; set; }

        [DisplayName("Maintenance Type")]
        [Required(ErrorMessage = "Please Provide Maintenance Type")]
        public string Type { get; set; }
    }
}