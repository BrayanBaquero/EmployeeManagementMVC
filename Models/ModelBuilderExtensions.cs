using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementMVC.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 1,
                   Name = "Jaskier",
                   Department = Dept.IT,
                   Email = "bra@gmail.com"
               },
               new Employee
               {
                   Id = 2,
                   Name = "Gerand",
                   Department = Dept.HR,
                   Email = "geranr@gmail.com"
               }
               );
        }
    }
}
