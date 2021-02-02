using EmployeeManagementMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementMVC.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Employee Employee { get; set; }
        public String PageTitle { get; set; }
    }
}
