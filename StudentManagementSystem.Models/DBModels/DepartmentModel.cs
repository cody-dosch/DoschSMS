using StudentManagementSystem.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    // This model matches the Departments table in the DB
    public class DepartmentModel : IDepartmentModel
    {
        public int? IdDepartment { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentValue { get; set; }
    }
}