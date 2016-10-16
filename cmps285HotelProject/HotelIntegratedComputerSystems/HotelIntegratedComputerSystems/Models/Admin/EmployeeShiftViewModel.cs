using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelIntegratedComputerSystems.Models.Admin
{
    public class EmployeeShiftViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        [DisplayName("Employee")]
        [Required(ErrorMessage = "Please Select Employee")]
        public int EmployeeId { get; set; }
        [DisplayName("Employee")]
        public string EmployeeName { get; set; }



        [DisplayName("Clock In")]
        [Required(ErrorMessage = "Clock In Time Requiered")]
        [DataType(DataType.Date)]
        public DateTime ClockIn { get; set; }



        [DisplayName("Clock Out")]
        [DataType(DataType.Date)]
        public DateTime? ClockOut { get; set; }
        [DisplayName("Cash Taken In")]
        public decimal CashTakenIn { get; set; }
        [DisplayName("Cash Put In Safe")]
        public decimal CashPutInSafe { get; set; }
    }
}