using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Employees;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelIntegratedComputerSystems.Services.Employee
{
    public class CustomerServices : BaseServices
    {
        public List<CustomersViewModel> GetCustomersList()
        {
            var customerList = from cust in Db.Customers
                               select new CustomersViewModel
                               {
                                   Id = cust.Id,
                                   Name = cust.Name,
                                   Address = cust.Address,
                                   Phone = cust.Phone,
                                   Email = cust.Email
                               };
            return customerList.ToList();
        }

        public void CreateNewCustomer(CustomersViewModel customer)
        {

            Db.Customers.Add(new Customer { Id = customer.Id, Address = customer.Address,
                                            Email = customer.Email, Name = customer.Name,
                                            Phone = customer.Phone});
            Db.SaveChanges();
        }

        public void PostChangesForEdit(CustomersViewModel editCustomer)
        {

            Db.Entry(new Customer {Id = editCustomer.Id, Address = editCustomer.Address, Email = editCustomer.Email,
                                   Name = editCustomer.Name, Phone = editCustomer.Phone })
                                   .State = EntityState.Modified;
            Db.SaveChanges();
        }
        
        public CustomersViewModel FindEntryById(int id)
        {
            var foundCustomer = Db.Customers.Find(id);
            return (new CustomersViewModel { Id = foundCustomer.Id, Address = foundCustomer.Address, Email = foundCustomer.Email,
                                             Name = foundCustomer.Name, Phone = foundCustomer.Phone }) ;
        }

        public CustomersViewModel FindEntryByName(BookingViewModel booking)
        {
            var foundCustomer = Db.Customers.FirstOrDefault(i => i.Name == booking.CustomerName);
                 
            return (new CustomersViewModel
            {
                Id = foundCustomer.Id,
                Address = foundCustomer.Address,
                Email = foundCustomer.Email,
                Name = foundCustomer.Name,
                Phone = foundCustomer.Phone
            });
        }

        public void DeleteEntry(int id)
        {
            var foundCustomer = Db.Customers.Find(id);
            Db.Customers.Remove(foundCustomer);
            Db.SaveChanges();
        }

        public bool CheckForDependencys(int id)
        {
            var customer = FindEntryById(id);
            var firstCheck = Db.Bookings.FirstOrDefault(r => r.CustomerId.Equals(customer.Id));

            return (firstCheck != null);
        }
    }
}