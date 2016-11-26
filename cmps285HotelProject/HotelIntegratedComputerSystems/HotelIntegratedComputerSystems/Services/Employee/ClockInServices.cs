using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Controllers.Default;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;
using HotelIntegratedComputerSystems.Services.Admin;

namespace HotelIntegratedComputerSystems.Services.Employee
{
    public class ClockInServices : BaseServices
    {
        readonly EmployeeShiftServices _employeeShiftService = new EmployeeShiftServices();
        public List<EmployeeShiftViewModel> GetShiftsForEmployee()
        {
            return _employeeShiftService.GetEmployeeShiftList().Where(x => x.EmployeeName == GoogleAccount.Name).OrderByDescending(x => x.ClockInDate).ToList();
        }

        public Models.Employee GetCurrentEmployee()
        {
            return Db.Employees.First(x => x.Email == GoogleAccount.Email);
        }

        public int GetOpenEmployeeShift()
        {
            var employee = GetCurrentEmployee();
            var shift = Db.EmployeeShifts.FirstOrDefault(x => x.EmployeeId == employee.Id && x.ClockOut == null);
            return shift?.Id ?? 0;
        }

        public void CreateNewEmployeeShift(EmployeeShiftViewModel shift)
        {
            
            Db.EmployeeShifts.Add(new EmployeeShift()
            {
                EmployeeId = GetCurrentEmployee().Id,
                CashTakeIn = shift.CashTakenIn,
                ClockIn = DateTime.Now,
            });
            Db.SaveChanges();
        }

        public void PostChangesForEdit(EmployeeShiftViewModel shift)
        {
            Db.Entry(Db.EmployeeShifts.Local.First()).State = EntityState.Modified;
            Db.EmployeeShifts.Local.First().ClockOut = DateTime.Now;
            Db.EmployeeShifts.Local.First().CashPutInSafe = shift.CashPutInSafe;
            Db.SaveChanges();
        }

        public EmployeeShiftViewModel FindEntryById(int id)
        {
            var foundShift = Db.EmployeeShifts.Find(id);
            return (new EmployeeShiftViewModel()
            {
                Id = foundShift.Id,
                CashPutInSafe = foundShift.CashPutInSafe,
                CashTakenIn = foundShift.CashTakeIn,
                ClockOut = foundShift.ClockOut,
                ClockIn = foundShift.ClockIn,
                EmployeeId = foundShift.EmployeeId
            });
        }
    }
}