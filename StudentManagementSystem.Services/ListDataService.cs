using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StudentManagementSystem.Services
{
    public class ListDataService
    {
        #region Properties

        private RolesRepository RolesRepository;
        private DepartmentsRepository DepartmentsRepository;
        private UsersRepository UsersRepository;
        private SemestersRepository SemestersRepository;
        private DaysOfWeekRepository DaysOfWeekRepository;

        #endregion

        #region Constructor

        public ListDataService()
        {
            // Initialize the repositories
            RolesRepository = new RolesRepository();
            DepartmentsRepository = new DepartmentsRepository();
            UsersRepository = new UsersRepository();
            SemestersRepository = new SemestersRepository();
            DaysOfWeekRepository = new DaysOfWeekRepository();
        }

        #endregion

        #region Public Methods

        public List<SelectListItem> Roles()
        {
            var roles = new List<SelectListItem>();

            try
            {
                // Convert each Role in the DB to a SelectListItem and add to a list
                foreach (var role in RolesRepository.ListRoles())
                {
                    roles.Add(new SelectListItem
                    {
                        Text = role.Key,
                        Value = role.Value
                    });
                }                
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }

            return roles;
        }

        public List<SelectListItem> Departments()
        {
            var departments = new List<SelectListItem>();

            try
            {
                // Convert each Department in the DB to a SelectListItem and add to a list
                foreach (var department in DepartmentsRepository.ListDepartments())
                {
                    departments.Add(new SelectListItem
                    {
                        Text = department.DepartmentName,
                        Value = department.DepartmentValue
                    });
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return departments;
        }

        public List<SelectListItem> Instructors()
        {
            var instructors = new List<SelectListItem>();

            try
            {
                // Add empty option for default
                instructors.Add(new SelectListItem { Text = "Unassigned", Value = "" });

                // Convert each Instructor in the DB to a SelectListItem and add to a list
                foreach (var instructor in UsersRepository.ListUsers().Where(u => u.Role == "instructor"))
                {
                    instructors.Add(new SelectListItem
                    {
                        Text = instructor.FirstName + ' ' + instructor.LastName,
                        Value = instructor.IdUser.ToString()
                    });
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return instructors;
        }

        public List<SelectListItem> Semesters()
        {
            var semesters = new List<SelectListItem>();

            try
            {
                // Convert each Semester in the DB to a SelectListItem and add to a list
                foreach (var semester in SemestersRepository.ListSemesters())
                {
                    semesters.Add(new SelectListItem
                    {
                        Text = semester.SemesterName,
                        Value = semester.SemesterValue
                    });
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return semesters;
        }

        public List<SelectListItem> DaysOfWeek()
        {
            var daysOfWeek = new List<SelectListItem>();

            // Add empty option for default
            daysOfWeek.Add(new SelectListItem { Text = "", Value = "" });

            try
            {
                // Convert each DayOfWeek in the DB to a SelectListItem and add to a list
                foreach (var day in DaysOfWeekRepository.ListDaysOfWeek())
                {
                    daysOfWeek.Add(new SelectListItem
                    {
                        Text = day.Day,
                        Value = day.Day
                    });
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return daysOfWeek;
        }

        #endregion
    }
}
