using StudentManagementSystem.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    // This model matches the Courses table in the DB
    public class CourseModel : ICourseModel
    {
        public int? IdCourse { get; set; }
        public string Department { get; set; }
        public int? CourseNumber { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int? CourseInstructorId { get; set; }
        public string CourseInstructorUsername { get; set; }
        public string Semester { get; set; }
        public int SeatsOpen { get; set; }
        public int SeatsMax { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string DayOfWeek { get; set; }
    }
}