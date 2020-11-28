using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Interfaces.ViewModels
{
    public interface ILoginModel
    {
        string Username { get; set; }
        string Password { get; set; }
        string ErrorMessage { get; set; }
    }
}
