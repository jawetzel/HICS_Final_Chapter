using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelIntegratedComputerSystems.Models.Admin
{
    public class ExpenseTypeViewModel
    {

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Type")]
        [Required(ErrorMessage = "Please Provide Type")]
        public string Type { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Please Provide Description")]
        public string Description { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Please Provide Price")]
        [Range(0, int.MaxValue, ErrorMessage = "Number Provided Must Be Positive")]
        public decimal Ammount { get; set; }
    }
}