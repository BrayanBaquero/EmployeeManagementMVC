using EmployeeManagementMVC.Models;
using EmployeeManagementMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementMVC.controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }

        
        
        [Route("~/Home")]
        [Route("~/")]
        public ViewResult index() {
            //return Json(new {id=1,name="Prub" }); ;
            var model= _employeeRepository.GetAllEmployee();
            return View(model);
        }
        [Route("{id?}")]
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee=_employeeRepository.GetEmployee(id??1),
                PageTitle="Employee Details"
            };
            
            return View(homeDetailsViewModel);
        }
    }
}
 