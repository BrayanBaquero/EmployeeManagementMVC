using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementMVC.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id=1,Name="Jessica",Department="HR", Email="jessica@gmail.com" },
                new Employee(){Id=1,Name="Brayan",Department="Boss", Email="Brayan@gmail.com" },
                new Employee(){Id=1,Name="Cristina",Department="HB", Email="Cristina@gmail.com" },
            };
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
