using StudentManagementSystem.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.ViewModels
{
    // This model has the properties required to edit a user in the DB
    public class EditUserModel : IEditUserModel
    {
        public int? IdUser { get; set; }

        [RegularExpression("[a-zA-Z0-9\\s-']*", ErrorMessage = "Cannot contain special characters")]
        public string FirstName { get; set; }

        [RegularExpression("[a-zA-Z0-9\\s-']*", ErrorMessage = "Cannot contain special characters")]
        public string LastName { get; set; }

        [RegularExpression("[a-zA-Z0-9\\s-']*", ErrorMessage = "Cannot contain special characters")]
        public string Address { get; set; }

        [RegularExpression("[a-zA-Z0-9\\s-']*", ErrorMessage = "Cannot contain special characters")]
        public string City { get; set; }

        [RegularExpression("[a-zA-Z0-9\\s]*", ErrorMessage = "Cannot contain special characters")]
        public string State { get; set; }

        [RegularExpression("[a-zA-Z0-9\\s-]*", ErrorMessage = "Cannot contain special characters")]
        public string ZipCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}