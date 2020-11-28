using StudentManagementSystem.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Interfaces.ViewModels
{
    public interface ICourseInfoModel
    {
        ICourseModel Course { get; set; }
        string InstructorFirstName { get; set; }
        string InstructorLastName { get; set; }
        List<IUserModel> Participants { get; set; }
    }
}
