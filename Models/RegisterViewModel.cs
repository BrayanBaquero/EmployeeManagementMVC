﻿using EmployeeManagementMVC.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementMVC.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action:"IsEmailInUse",controller:"Account")]
        [ValidEmailDomain(allowedDomain:"gmail.com",ErrorMessage ="Email Domain must be gmail.com")]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name="Confirm password")]
        [Compare("Password",ErrorMessage="Password and conformation password do not match.")]
        public String ConfirmPassword { get; set; }
        public string City { get; set; }
    }
}
