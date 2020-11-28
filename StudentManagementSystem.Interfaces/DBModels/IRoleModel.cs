using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Interfaces.Models
{
    public interface IRoleModel
    {
        int? IdRole { get; set; }
        string Key { get; set; }
        string Value { get; set; }
    }
}
