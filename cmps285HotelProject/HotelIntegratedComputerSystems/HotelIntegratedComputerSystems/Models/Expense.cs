//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelIntegratedComputerSystems.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Expense
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int ExpenseTypeId { get; set; }
        public int BookingId { get; set; }
    
        public virtual ExpenseType ExpenseType { get; set; }
        public virtual Room Room { get; set; }
        public virtual Booking Booking { get; set; }
    }
}