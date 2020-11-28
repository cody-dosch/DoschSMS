using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Interfaces.ViewModels
{
    public interface IEditCourseModel
    {
        int? IdCourse { get; set; }
        string Department { get; set; }
        int? CourseNumber { get; set; }
        string CourseName { get; set; }
        string CourseDescription { get; set; }
        int? CourseInstructorId { get; set; }
        string CourseInstructorUsername { get; set; }
        string Semester { get; set; }
        int? SeatsMax { get; set; }
        int? SeatsOpen { get; set; }
        string StartTime { get; set; }
        string EndTime { get; set; }
        string DayOfWeek { get; set; }
        string ErrorMessage { get; set; }
    }
}
