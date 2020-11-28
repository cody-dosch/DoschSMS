using StudentManagementSystem.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    // This model matches the InstructorCourseAssoc table in the DB
    public class InstructorCourseAssocModel : IInstructorCourseAssocModel, IAssociationModel
    {
        public int IdCourse { get; set; }
        public int IdInstructor { get; set; }
    }
}