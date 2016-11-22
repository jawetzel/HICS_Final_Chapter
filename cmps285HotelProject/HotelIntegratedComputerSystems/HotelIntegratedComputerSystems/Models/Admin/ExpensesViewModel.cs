using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models.Employees;

namespace HotelIntegratedComputerSystems.Models.Admin
{
    public class ExpensesViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public List<RoomViewModel> RoomsList { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int RoomId { get; set; }

        [DisplayName("Building")]
        [Required(ErrorMessage = "Field Requiered")]
        public string BuildingName { get; set; } //room

        [DisplayName("Floor")]
        [Required(ErrorMessage = "Field Requiered")]
        public int FloorNumber { get; set; } //room

        [DisplayName("Rooms")]
        [Required(ErrorMessage = "Field Requiered")]
        public string RoomNumber { get; set; } //room

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int BookingId { get; set; }

        public List<BookingViewModel> BookingsList { get; set; }

        [Required(ErrorMessage = "Field Requiered")]
        [DisplayName("Customer")]
        public string CustomerName { get; set; } //booking

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int ExpenseTypeId { get; set; }

        public List<ExpenseTypeViewModel> ExpenseList { get; set; }

        [DisplayName("Type")]
        [Required(ErrorMessage = "Field Requiered")]
        public string ExpenseTypeType { get; set; } //expenseType

        [DisplayName("Description")]
        [Required(ErrorMessage = "Field Requiered")]
        public string ExpenseTypeDescription { get; set; } //expenseType

        [DisplayName("Ammount")]
        [Required(ErrorMessage = "Field Requiered")]
        public decimal ExpenseTypeAmmount { get; set; } //expenseType
    }
}