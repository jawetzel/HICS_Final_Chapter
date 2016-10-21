using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelIntegratedComputerSystems.Models.Admin
{
    public class EmployeeTypeViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Security Rank")]
        [Required(ErrorMessage = "Select A Security Rank")]
        public int SecurityRankId { get; set; }

        [DisplayName("Security Rank")]
        public string SecurityRankDescription { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "Select A Title")]
        public string Title { get; set; }

        [DisplayName("Pay Rate")]
        [Required(ErrorMessage = "Select A Pay Rate")]
        [Range(1, int.MaxValue, ErrorMessage = "Number Provided Must Be Positive")]
        public decimal PayRate { get; set; }
    }
}