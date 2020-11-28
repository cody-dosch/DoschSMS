using StudentManagementSystem.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    // This model matches the DaysOfWeek table in the DB
    public class DayOfWeekModel : IDayOfWeekModel
    {
        public string Day { get; set; }
    }
}