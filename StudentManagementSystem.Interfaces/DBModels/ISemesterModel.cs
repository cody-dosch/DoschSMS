using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Interfaces.Models
{
    public interface ISemesterModel
    {
        int? IdSemester { get; set; }
        string SemesterName { get; set; }
        string SemesterValue { get; set; }
    }
}
