﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;
using HotelIntegratedComputerSystems.Services.Admin;

namespace HotelIntegratedComputerSystems.Controllers.Admin
{
    public class EmployeesController : BaseController
    {
        private EmployeeServies _servies = new EmployeeServies();

        public ActionResult Index()
        {
            return View(_servies.GetEmployeeList());
        }
        public ActionResult Create()
        {
            ViewBag.EmployeeTypeId = new SelectList(Db.EmployeeTypes, "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeTypeId,Name,EmployeeTypeTitle,Email,Address,Phone")] EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid) return View(employeeViewModel);
            _servies.CreateNewEmployee(employeeViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.EmployeeTypeId = new SelectList(Db.EmployeeTypes, "Id", "Title");
            var employeeViewModel = _servies.FindEntryById(id.Value);
            if (employeeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeTypeId,Name,EmployeeTypeTitle,Email,Address,Phone")] EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid) return View(employeeViewModel);
            _servies.PostChangesForEdit(employeeViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeViewModel = _servies.FindEntryById(id.Value);
            if (employeeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _servies.DeleteEntry(id);
            return RedirectToAction("Index");
        }
    }
}
