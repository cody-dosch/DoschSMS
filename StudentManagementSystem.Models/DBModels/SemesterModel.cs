using StudentManagementSystem.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    // This model matches the Semesters table in the DB
    public class SemesterModel : ISemesterModel
    {
        public int? IdSemester { get; set; }
        public string SemesterName { get; set; }
        public string SemesterValue { get; set; }
    }
}