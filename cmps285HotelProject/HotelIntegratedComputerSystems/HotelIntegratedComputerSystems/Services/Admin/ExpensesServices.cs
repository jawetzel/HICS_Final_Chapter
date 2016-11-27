using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;
using HotelIntegratedComputerSystems.Models.Employees;
using HotelIntegratedComputerSystems.Services.Employee;

namespace HotelIntegratedComputerSystems.Services.Admin
{
    public class ExpensesServices : BaseServices
    {
        private readonly ExpenseTypeServices _expenseTypeServices = new ExpenseTypeServices();
        private readonly RoomServices _roomServices = new RoomServices();

        public List<ExpensesViewModel> GetExpensesList()
        {
            var expensesList = from expenses in Db.Expenses1
                select new ExpensesViewModel()
                {
                    Id = expenses.Id,
                    BookingId = expenses.BookingId,
                    RoomId = expenses.RoomId,
                    BuildingName = expenses.Room.Building.BuildingName,
                    FloorNumber = expenses.Room.FloorNumber,
                    RoomNumber = expenses.Room.RoomNumber,
                    CustomerName = expenses.Booking.Customer.Name,
                    ExpenseTypeId = expenses.ExpenseTypeId,
                    ExpenseTypeType = expenses.ExpenseType.Type,
                    ExpenseTypeDescription = expenses.ExpenseType.Description,
                    ExpenseTypeAmmount = expenses.ExpenseType.Ammount
                };
            return expensesList.ToList();
        }

        public List<BookingViewModel> GetActiveBookings()
        {
            var bookings = from book in Db.Bookings
                           where book.BookingStatus.BookingStatusDescription == "Checked In"
                           select new BookingViewModel()
                           {
                               Id = book.Id,
                               CustomerId = book.CustomerId,
                               CustomerName = book.Customer.Name,
                               BuildingName = book.Room.Building.BuildingName,
                               FloorNumber = book.Room.FloorNumber,
                               RoomId = book.RoomId,
                               RoomNumber = book.Room.RoomNumber,
                               StartDate = book.StartDate,
                               EndDate = book.EndDate,
                               VolumeAdults = book.VolumeAdults,
                               VolumeChildren = book.VolumeChildren,
                               BookingStatusId = book.BookingStatusId,
                               CheckedInDate = book.CheckedInDate,
                               CheckedOutDate = book.CheckedOutDate,
                               BookingStatusDescription = book.BookingStatus.BookingStatusDescription,

                           };
            return bookings.ToList();
        }

        public ExpensesViewModel GetExpenseByIdEdit(int id)
        {
            var expense = Db.Expenses1.Find(id);
            

            var returnModel = new ExpensesViewModel
            {
                Id = expense.Id,
                BookingId = expense.BookingId,
                RoomId = expense.RoomId,
                BuildingName = expense.Room.Building.BuildingName,
                FloorNumber = expense.Room.FloorNumber,
                RoomNumber = expense.Room.RoomNumber,
                CustomerName = expense.Booking.Customer.Name,
                ExpenseTypeId = expense.ExpenseTypeId,
                ExpenseTypeType = expense.ExpenseType.Type,
                ExpenseTypeDescription = expense.ExpenseType.Description,
                ExpenseTypeAmmount = expense.ExpenseType.Ammount,

                BookingsList = GetActiveBookings(),
                ExpenseList = _expenseTypeServices.GetExpenseTypesList(),
            };
            return returnModel;
        }

        public List<ExpensesViewModel> GetExpenseByBookingId(BookingViewModel booking)
        {
            return (from expense in Db.Expenses1
                    where expense.BookingId == booking.Id
                    select new ExpensesViewModel()
                    {
                        Id = expense.Id,
                        BookingId = expense.BookingId,
                        RoomId = expense.RoomId,
                        BuildingName = expense.Room.Building.BuildingName,
                        FloorNumber = expense.Room.FloorNumber,
                        RoomNumber = expense.Room.RoomNumber,
                        CustomerName = expense.Booking.Customer.Name,
                        ExpenseTypeId = expense.ExpenseTypeId,
                        ExpenseTypeType = expense.ExpenseType.Type,
                        ExpenseTypeDescription = expense.ExpenseType.Description,
                        ExpenseTypeAmmount = expense.ExpenseType.Ammount

                    }).ToList();
        }

        public void PostChangesForEdit(ExpensesViewModel model)
        {
            model.RoomId = Db.Rooms.First(x => x.Building.BuildingName == model.BuildingName && x.FloorNumber == model.FloorNumber && x.RoomNumber == model.RoomNumber).Id;
            model.BookingId = Db.Bookings.First(x => x.RoomId == model.RoomId && x.Customer.Name == model.CustomerName && x.BookingStatus.BookingStatusDescription == "Checked In").Id;
            model.ExpenseTypeId = Db.ExpenseTypes.First(x => x.Type == model.ExpenseTypeType && x.Ammount == model.ExpenseTypeAmmount && x.Description == model.ExpenseTypeDescription).Id;

            Db.Entry(new Expenses()
            {
                Id = model.Id,
                RoomId = model.RoomId,
                BookingId = model.BookingId,
                ExpenseTypeId = model.ExpenseTypeId
            })
            .State = EntityState.Modified;
            Db.SaveChanges();
        }

        public ExpensesViewModel GetExpenseByIdCreate()
        {

            var returnModel = new ExpensesViewModel
            {
                BookingsList = GetActiveBookings(),
                ExpenseList = _expenseTypeServices.GetExpenseTypesList(),
            };
            return returnModel;
        }

        public void PostCreateExpense(ExpensesViewModel model)
        {
            model.RoomId = Db.Rooms.First(x => x.Building.BuildingName == model.BuildingName && x.FloorNumber == model.FloorNumber && x.RoomNumber == model.RoomNumber).Id;
            model.BookingId = Db.Bookings.First(x => x.RoomId == model.RoomId && x.Customer.Name == model.CustomerName && x.BookingStatus.BookingStatusDescription == "Checked In").Id;
            model.ExpenseTypeId = Db.ExpenseTypes.First(x => x.Type == model.ExpenseTypeType && x.Ammount == model.ExpenseTypeAmmount && x.Description == model.ExpenseTypeDescription).Id;

            Db.Expenses1.Add(new Expenses()
            {
                RoomId = model.RoomId,
                BookingId = model.BookingId,
                ExpenseTypeId = model.ExpenseTypeId
            });

            Db.SaveChanges();
        }

        public ExpensesViewModel GetExpenseByIdDelete(int id)
        {
            var expense = Db.Expenses1.Find(id);
            var returnModel = new ExpensesViewModel
            {
                Id = expense.Id,
                BookingId = expense.BookingId,
                RoomId = expense.RoomId,
                BuildingName = expense.Room.Building.BuildingName,
                FloorNumber = expense.Room.FloorNumber,
                RoomNumber = expense.Room.RoomNumber,
                CustomerName = expense.Booking.Customer.Name,
                ExpenseTypeId = expense.ExpenseTypeId,
                ExpenseTypeType = expense.ExpenseType.Type,
                ExpenseTypeDescription = expense.ExpenseType.Description,
                ExpenseTypeAmmount = expense.ExpenseType.Ammount,
            };

            return returnModel;
        }

        public void DeleteEntry(int id)
        {
            var expense = Db.Expenses1.Find(id);
            Db.Expenses1.Remove(expense);
            Db.SaveChanges();
        }
    }
}