﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public partial class HicsTestDbEntities1 : DbContext
    {
        public HicsTestDbEntities1()
            : base("name=HicsTestDbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeShift> EmployeeShifts { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }
        public virtual DbSet<HouseKeepingStatu> HouseKeepingStatus { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<SecurityRank> SecurityRanks { get; set; }
        public virtual DbSet<MaintenanceLogs> MaintenanceLogs { get; set; }
        public virtual DbSet<MaintenanceTypes> MaintenanceTypes { get; set; }
        public virtual DbSet<RoomStatus> RoomStatus { get; set; }

        public List<HouseKeepingViewModel> GetRoomsForHouseKeeping()
        {
            var RoomList =  from room in Rooms
                            join HouseKeeping in HouseKeepingStatus on room.HousekeepingStatusId equals HouseKeeping.Id
                            join Building in Buildings on room.BuildingId equals Building.Id
                            join RoomStat in RoomStatus on room.RoomStatusId equals RoomStat.Id
                            where room.HousekeepingStatusId == HouseKeeping.Id && room.BuildingId == Building.Id && room.RoomStatusId == RoomStat.Id
                            select new HouseKeepingViewModel
                            {
                                Id = room.Id,
                                BuildingId = Building.Id,
                                BuildingName = Building.Building1,
                                HousekeepingStatusId = HouseKeeping.Id,
                                HousekeepingCleanStatus = HouseKeeping.CleanStatus,
                                FloorNumber = room.FloorNumber,
                                RoomNumber = room.RoomNumber,
                                RoomStatusId = RoomStat.Id,
                                RoomStatusDescription = RoomStat.Description
                            };
            return RoomList.ToList();
        }

        public System.Data.Entity.DbSet<HotelIntegratedComputerSystems.Models.HouseKeepingViewModel> HouseKeepingViewModels { get; set; }
    }
}
