using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Interfaces.ViewModels
{
    public interface IEditUserModel
    {
        int? IdUser { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string ZipCode { get; set; }
        string ErrorMessage { get; set; }
    }
}
