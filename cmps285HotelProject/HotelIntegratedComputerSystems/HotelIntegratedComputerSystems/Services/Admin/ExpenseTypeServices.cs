using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;

namespace HotelIntegratedComputerSystems.Services.Admin
{
    public class ExpenseTypeServices : BaseServices
    {
        public List<ExpenseTypeViewModel> GetExpenseTypesList()
        {
            var expenseTypeList = from expenseType in Db.ExpenseTypes
                               select new ExpenseTypeViewModel
                               {
                                   Id = expenseType.Id,
                                   Type = expenseType.Type,
                                   Description = expenseType.Description,
                                   Ammount = expenseType.Ammount                                  
                               };
            return expenseTypeList.ToList();
        }

        public void CreateNewExpenseType(ExpenseTypeViewModel expenseType)
        {

            Db.ExpenseTypes.Add(new ExpenseType()
            {
                Id = expenseType.Id,
                Type = expenseType.Type,
                Description = expenseType.Description,
                Ammount = expenseType.Ammount
            });
            Db.SaveChanges();
        }

        public void PostChangesForEdit(ExpenseTypeViewModel editRoomType)
        {

            Db.Entry(new ExpenseType()
            {
                Id = editRoomType.Id,
                Type = editRoomType.Type,
                Description = editRoomType.Description,
                Ammount = editRoomType.Ammount
            })
            .State = EntityState.Modified;
            Db.SaveChanges();
        }

        public ExpenseTypeViewModel FindEntryById(int id)
        {
            var expenseType = Db.ExpenseTypes.Find(id);
            return (new ExpenseTypeViewModel
            {
                Id = expenseType.Id,
                Type = expenseType.Type,
                Description = expenseType.Description,
                Ammount = expenseType.Ammount
            });
        }

        public void DeleteEntry(int id)
        {
            var foundExpenseType = Db.ExpenseTypes.Find(id);
            Db.ExpenseTypes.Remove(foundExpenseType);
            Db.SaveChanges();
        }

        public bool CheckForDependencys(int id)
        {
            var expenseType = FindEntryById(id);
            var firstCheck = Db.Expenses1.FirstOrDefault(r => r.ExpenseTypeId.Equals(expenseType.Id));

            return (firstCheck != null);
        }
    }
}