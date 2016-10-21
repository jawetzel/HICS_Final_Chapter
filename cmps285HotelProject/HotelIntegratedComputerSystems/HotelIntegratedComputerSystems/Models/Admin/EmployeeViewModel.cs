using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelIntegratedComputerSystems.Models.Admin
{
    public class EmployeeViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        [Required(ErrorMessage = "Select Employee Title")]
        public int EmployeeTypeId { get; set; }

        [DisplayName("Employee Type")]
        public string EmployeeTypeTitle { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Please Provide Name")]
        public string Name { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Please Provide Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DisplayName("Address")]
        [Required(ErrorMessage = "Please Provide Address")]
        public string Address { get; set; }


        [DisplayName("Phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Not A Valid Phone Number")]
        [Required(ErrorMessage = "Enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public Int64 Phone { get; set; }
    }
}