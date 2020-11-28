using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Interfaces.Models
{
    public interface ICourseModel
    {
        int? IdCourse { get; set; }
        string Department { get; set; }
        int? CourseNumber { get; set; }
        string CourseName { get; set; }
        string CourseDescription { get; set; }
        int? CourseInstructorId { get; set; }
        string CourseInstructorUsername { get; set; }
        string Semester { get; set; }
        int SeatsOpen { get; set; }
        int SeatsMax { get; set; }
        DateTime? StartTime { get; set; }
        DateTime? EndTime { get; set; }
        string DayOfWeek { get; set; }

    }
}
