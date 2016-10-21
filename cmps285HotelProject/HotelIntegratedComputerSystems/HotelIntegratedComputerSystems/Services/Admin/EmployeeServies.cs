using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;

namespace HotelIntegratedComputerSystems.Services.Admin
{
    public class EmployeeServies : BaseServices
    {
        public List<EmployeeViewModel> GetEmployeeList()
        {
            var employeeList = from employee in Db.Employees
                           select new EmployeeViewModel
                           {
                               Id = employee.Id,
                               EmployeeTypeId = employee.EmployeeTypeId,
                               EmployeeTypeTitle = employee.EmployeeType.Title,
                               Email = employee.Email,
                               Address = employee.Address,
                               Phone = employee.Phone,
                               Name = employee.Name
                           };
            return employeeList.ToList();
        }

        public void CreateNewEmployee(EmployeeViewModel employee)
        {

            Db.Employees.Add(new Models.Employee
            {
                Id = employee.Id,
                EmployeeTypeId = employee.EmployeeTypeId,
                Email = employee.Email,
                Address = employee.Address,
                Phone = employee.Phone,
                Name = employee.Name
            });
            Db.SaveChanges();
        }

        public EmployeeViewModel FindEntryById(int id)
        {
            var employee = Db.Employees.Find(id);
            return (new EmployeeViewModel
            {
                Id = employee.Id,
                EmployeeTypeId = employee.EmployeeTypeId,
                EmployeeTypeTitle = employee.EmployeeType.Title,
                Email = employee.Email,
                Address = employee.Address,
                Phone = employee.Phone,
                Name = employee.Name              
            });
        }

        public void PostChangesForEdit(EmployeeViewModel editEmployee)
        {

            Db.Entry(new Models.Employee()
            {
                Id = editEmployee.Id,
                EmployeeTypeId = editEmployee.EmployeeTypeId,
                Email = editEmployee.Email,
                Address = editEmployee.Address,
                Phone = editEmployee.Phone,
                Name = editEmployee.Name
            })
            .State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void DeleteEntry(int id)
        {
            var foundEmployee = Db.Employees.Find(id);
            Db.Employees.Remove(foundEmployee);
            Db.SaveChanges();
        }

        public bool CheckForDependencys(int id)
        {
            var employee = FindEntryById(id);
            var firstCheck = Db.EmployeeShifts.FirstOrDefault(r => r.EmployeeId.Equals(employee.Id));

            return (firstCheck != null);
        }
    }
}