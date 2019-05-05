using ITI.UI.MVC.ITI.UI.MVC.Day3.Lab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.UI.MVC.ITI.UI.MVC.Day3.Lab.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public List<Department> Departments { get; set; }

        public List<Employee> Employees { get; set; }

     
    }
}