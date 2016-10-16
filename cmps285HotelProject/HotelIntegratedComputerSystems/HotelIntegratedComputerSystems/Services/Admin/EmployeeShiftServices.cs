using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;

namespace HotelIntegratedComputerSystems.Services.Admin
{
    public class EmployeeShiftServices : BaseServices
    {
        public List<EmployeeShiftViewModel> GetEmployeeShiftList()
        {
            var employeeShiftList = from employeeShift in Db.EmployeeShifts
                                   select new EmployeeShiftViewModel
                                   {
                                       Id = employeeShift.Id,
                                       EmployeeId = employeeShift.EmployeeId,
                                       EmployeeName = employeeShift.Employee.Name,
                                       ClockIn = employeeShift.ClockIn,
                                       ClockOut = employeeShift.ClockOut,
                                       CashTakenIn = employeeShift.CashTakeIn,
                                       CashPutInSafe = employeeShift.CashPutInSafe
                                   };
            return employeeShiftList.ToList();
        }

        public void CreateNewEmployeeShift(EmployeeShiftViewModel employeeShift)
        {

            Db.EmployeeShifts.Add(new Models.EmployeeShift
            {
                Id = employeeShift.Id,
                EmployeeId = employeeShift.EmployeeId,
                ClockIn = employeeShift.ClockIn,
                ClockOut = employeeShift.ClockOut,
                CashTakeIn = employeeShift.CashTakenIn,
                CashPutInSafe = employeeShift.CashPutInSafe
            });
            Db.SaveChanges();
        }

        public EmployeeShiftViewModel FindEntryById(int id)
        {
            var employeeShift = Db.EmployeeShifts.Find(id);
            return (new EmployeeShiftViewModel
            {
                Id = employeeShift.Id,
                EmployeeId = employeeShift.EmployeeId,
                EmployeeName = employeeShift.Employee.Name,
                ClockIn = employeeShift.ClockIn,
                ClockOut = employeeShift.ClockOut,
                CashTakenIn = employeeShift.CashTakeIn,
                CashPutInSafe = employeeShift.CashPutInSafe
            });
        }

        public void PostChangesForEdit(EmployeeShiftViewModel editEmployeeShift)
        {

            Db.Entry(new EmployeeShift
            {
                Id = editEmployeeShift.Id,
                EmployeeId = editEmployeeShift.EmployeeId,
                ClockIn = editEmployeeShift.ClockIn,
                ClockOut = editEmployeeShift.ClockOut,
                CashTakeIn = editEmployeeShift.CashTakenIn,
                CashPutInSafe = editEmployeeShift.CashPutInSafe
            })
            .State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void DeleteEntry(int id)
        {
            EmployeeShift foundEmployeeShifts = Db.EmployeeShifts.Find(id);
            Db.EmployeeShifts.Remove(foundEmployeeShifts);
            Db.SaveChanges();
        }
    }
}