using StudentManagementSystem.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.ViewModels
{
    // This model has the properties required to add a new course to the DB
    public class AddCourseModel : IAddCourseModel
    {
        [Required(ErrorMessage = "Required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression("[0-9]*", ErrorMessage = "Must be a number")]
        public string CourseNumber { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression("[a-zA-Z0-9\\s+-]*", ErrorMessage = "Cannot contain special characters")]
        public string CourseName { get; set; }

        [RegularExpression("[a-zA-Z0-9.,'!?\\s+-]*", ErrorMessage = "Cannot contain special characters")]
        public string CourseDescription { get; set; }

        public int? CourseInstructorId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Semester { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression("[0-9]*", ErrorMessage = "Must be a number")]
        public int? SeatsMax { get; set; }

        [RegularExpression("(([1-9])|(1[0-2])):[0-5][0-9][\\s]*[aApP][mM]", ErrorMessage = "Format: hh:mm AM/PM")]
        public string StartTime { get; set; }

        [RegularExpression("(([1-9])|(1[0-2])):[0-5][0-9][\\s]*[aApP][mM]", ErrorMessage = "Format: hh:mm AM/PM")]
        public string EndTime { get; set; }

        public string DayOfWeek { get; set; }

        public string ErrorMessage { get; set; }
    }
}