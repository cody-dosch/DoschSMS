using StudentManagementSystem.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    // This model matches the Users table in the DB
    public class UserModel : IUserModel
    {
        public int? IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        [NotMapped]
        public bool? Submitted { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }
    }
}