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
                new Employee(){Id=1,Name="Jessica",Deparment="HR", Email="jessica@gmail.com" },
                new Employee(){Id=1,Name="Brayan",Deparment="Boss", Email="Brayan@gmail.com" },
                new Employee(){Id=1,Name="Cristina",Deparment="HB", Email="Cristina@gmail.com" },
            };
        }
        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
