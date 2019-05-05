using ITI.UI.MVC.ITI.UI.MVC.Day3.Lab.Models;
using ITI.UI.MVC.ITI.UI.MVC.Day3.Lab.Models.Entities;
using ITI.UI.MVC.ITI.UI.MVC.Day3.Lab.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.UI.MVC.ITI.UI.MVC.Day3.Lab.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        static ModelContext context = new ModelContext();
        public ActionResult Index()
        {
           
            EmployeeViewModel empVm = new EmployeeViewModel();
            empVm.Employees = context.Employees.ToList();
            empVm.Departments = context.Departments.ToList();
            return View(empVm);
        }

        //[HttpGet]
        //public ActionResult Add()
        //{
        //    EmployeeViewModel empVm = new EmployeeViewModel();
        //    empVm.Departments = context.Departments.ToList();
        //    ViewBag.Action = "Add";
        //    return View("AddEdit", empVm);
        //}

        [HttpPost]
        public ActionResult Add(EmployeeViewModel empVM)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(empVM.Employee);
                context.SaveChanges();
                return PartialView("_PartialEmployeeRow", empVM.Employee);
            }
            EmployeeViewModel empVm = new EmployeeViewModel();
            empVm.Departments = context.Departments.ToList();
            return View("AddEdit",empVm);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            Employee emp = context.Employees.FirstOrDefault(e => e.id == id);
            if (emp != null)
            {
                return View("AddEdit", emp);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModel empVM)
        {
            if (ModelState.IsValid)
            {
                var oldemp = context.Employees.FirstOrDefault(e => e.id == empVM.Employee.id);
                if (oldemp != null)
                {
                    oldemp.Name = empVM.Employee.Name;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            return View("AddEdit" , empVM);
        }

        public ActionResult Delete(int id)
        {
            Employee result = context.Employees.FirstOrDefault(e => e.id == id);
            if (result != null)
            {
                context.Employees.Remove(result);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}