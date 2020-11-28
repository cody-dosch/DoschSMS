using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Interfaces.Models
{
    public interface IDepartmentModel
    {
        int? IdDepartment { get; set; }
        string DepartmentName { get; set; }
        string DepartmentValue { get; set; }
    }
}
