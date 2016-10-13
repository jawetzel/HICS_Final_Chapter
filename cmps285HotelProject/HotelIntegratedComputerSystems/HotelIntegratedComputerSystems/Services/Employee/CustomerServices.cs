using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Employees;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelIntegratedComputerSystems.Services.Employee
{
    public class CustomerServices
    {
        public HicsTestDbEntities1 db = new HicsTestDbEntities1();

        public List<CustomersViewModel> GetCustomersList()
        {
            var CustomerList = from Cust in db.Customers
                               select new CustomersViewModel
                               {
                                   Id = Cust.Id,
                                   Name = Cust.Name,
                                   Address = Cust.Address,
                                   Phone = Cust.Phone,
                                   Email = Cust.Email
                               };
            return CustomerList.ToList();
        }

        public void CreateNewCustomer(CustomersViewModel Customer)
        {

            db.Customers.Add(new Customer { Id = Customer.Id, Address = Customer.Address,
                                            Email = Customer.Email, Name = Customer.Name,
                                            Phone = Customer.Phone});
            db.SaveChanges();
        }

        public void PostChangesForEdit(CustomersViewModel EditCustomer)
        {

            db.Entry(new Customer {Id = EditCustomer.Id, Address = EditCustomer.Address, Email = EditCustomer.Email,
                                   Name = EditCustomer.Name, Phone = EditCustomer.Phone })
                                   .State = EntityState.Modified;
            db.SaveChanges();
        }
        
        public CustomersViewModel FindEntryById(int Id)
        {
            Customer FoundCustomer = db.Customers.Find(Id);
            return (new CustomersViewModel { Id = FoundCustomer.Id, Address = FoundCustomer.Address, Email = FoundCustomer.Email,
                                             Name = FoundCustomer.Name, Phone = FoundCustomer.Phone }) ;
        }

        public void DeleteEntry(int Id)
        {
            Customer FoundCustomer = db.Customers.Find(Id);
            db.Customers.Remove(FoundCustomer);
            db.SaveChanges();
        }

    }
}