using ITI.UI.MVC.ITI.UI.MVC.Day3.Lab.Models;
using ITI.UI.MVC.ITI.UI.MVC.Day3.Lab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IITI.UI.MVC.Day3.Lab.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department

        static ModelContext context = new ModelContext();
        public ActionResult Index()
        {
            var Departments = context.Departments.ToList();
            return View(Departments);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddEdit");
        }

        [HttpPost]
        public ActionResult Add(Department dept)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Add(dept);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddEdit");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            Department dept = context.Departments.FirstOrDefault(e => e.id == id);
            if (dept != null)
            {
                return View("AddEdit", dept);
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Edit(Department dept)
        {
            if (ModelState.IsValid)
            {
                var olddept = context.Departments.FirstOrDefault(e => e.id == dept.id);
                if (olddept != null)
                {
                    olddept.Name = dept.Name;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            return View("AddEdit", dept);
        }

        public ActionResult Delete(int id)
        {
            Department result = context.Departments.FirstOrDefault(e => e.id == id);
            if (result != null)
            {
                context.Departments.Remove(result);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}