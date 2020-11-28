using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Interfaces.Models
{
    public interface IUserModel
    {
        int? IdUser { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string PasswordSalt { get; set; }
        string Role { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string ZipCode { get; set; }
    }
}
