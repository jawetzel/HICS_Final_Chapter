using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelIntegratedComputerSystems.Models.Admin
{
    public class BuildingViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number Not Provided")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Not A Valid Phone Number")]
        public Int64 Phone { get; set; }

        [Required(ErrorMessage = "Address Not Provided")]
        [DisplayName("Address")]
        public string Address { get; set; }


        [DisplayName("Building Name")]
        [Required(ErrorMessage = "Name Not Provided")]
        public string BuildingName { get; set; }

    }
}