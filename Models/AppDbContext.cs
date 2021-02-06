using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementMVC.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
                    
        }
        public DbSet<Employee> Employees { get; set; }

        //Inicializar base de datos que datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();//Extensioon Metod
        }
    }
}
