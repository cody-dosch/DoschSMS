﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Interfaces.Models
{
    public interface IInstructorCourseAssocModel
    {
        int IdCourse { get; set; }
        int IdInstructor { get; set; }

    }
}
