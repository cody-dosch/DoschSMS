using StudentManagementSystem.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    // This model matches the Roles table in the DB
    public class RoleModel : IRoleModel
    {
        public int? IdRole { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}