using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelIntegratedComputerSystems.Models.Employees
{
    public class CustomersViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = true)]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name Not Provided")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address Not Provided")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number Not Provided")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Not A Valid Phone Number")]
        public Int64 Phone { get; set; }

        [DisplayName("E-Mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "No E-Mail Address Provided")]
        public string Email { get; set; }
    }
}