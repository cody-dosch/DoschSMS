using StudentManagementSystem.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.ViewModels
{
    // This model has the properties required to login to the application
    public class LoginModel : ILoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
    }
}