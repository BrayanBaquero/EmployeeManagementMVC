using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementMVC.ViewModels
{
    public class EmployeeEditViewModel:EmployeeCreateViewModel
    {
        public int Id { get; set; }
        public String ExistingPhotoPath { get; set; }
    }
}
