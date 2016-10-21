using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelIntegratedComputerSystems.Models.Admin
{
    public class RoomTypeViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Bedding")]
        [Required(ErrorMessage = "Please Provide Bedding Type")]
        public string Bedding { get; set; }

        [DisplayName("Kitchen")]
        [Required(ErrorMessage = "Please Provide Kitchen Type")]
        public string Kitchen { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Number Provided Must Be Positive")]
        [DisplayName("# Rooms")]
        [Required(ErrorMessage = "Please Provide Number Of Rooms")]
        public int Rooms { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Number Provided Must Be Positive")]
        [DisplayName("# Bathrooms")]
        [Required(ErrorMessage = "Please Provide Number of Bathrooms")]
        public decimal BathRooms { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Number Provided Must Be Positive")]
        [DisplayName("Max Occupants")]
        [Required(ErrorMessage = "Please Provide Maximum Occupants")]
        public int SleepsVolume { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Number Provided Must Be Positive")]
        [DisplayName("Nightly Rate")]
        [Required(ErrorMessage = "Please Provide Nightly Rate")]
        public decimal NightlyRate { get; set; }

    }
}