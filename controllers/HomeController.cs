using EmployeeManagementMVC.Models;
using EmployeeManagementMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementMVC.controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }
        public string index() {
            //return Json(new {id=1,name="Prub" }); ;
            return _employeeRepository.GetEmployee(1).Name;
        }
        public ViewResult Details()
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee=_employeeRepository.GetEmployee(1),
                PageTitle="Employee Details"
            };
            
            return View(homeDetailsViewModel);
        }
    }
}
