namespace ITI.UI.MVC.ITI.UI.MVC.Day3.Lab.Models
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext
    {
        
        public ModelContext()
            : base("name=ModelContext")
        {
        }

       public DbSet<Employee> Employees { get; set; }
       public DbSet<Department> Departments { get; set; }


    }


}