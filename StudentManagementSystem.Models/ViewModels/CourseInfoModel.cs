using StudentManagementSystem.Interfaces.Models;
using StudentManagementSystem.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.ViewModels
{
    // This model has the properties required for the CourseDetails and Course Home pages
    public class CourseInfoModel : ICourseInfoModel
    {
        public ICourseModel Course { get; set; }
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set; }
        public List<IUserModel> Participants { get; set; }
    }
}