using StudentManagementSystem.Extensions;
using StudentManagementSystem.Models;
using StudentManagementSystem.Resources;
using StudentManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        #region Properties

        private CoursesService CoursesService;
        private InstructorCourseAssocService InstructorCourseAssocService;
        private StudentCourseAssocService StudentCourseAssocService;

        #endregion

        #region Constructor

        public HomeController()
        {
            // Initialize the services
            CoursesService = new CoursesService();
            InstructorCourseAssocService = new InstructorCourseAssocService();
            StudentCourseAssocService = new StudentCourseAssocService();
        }

        #endregion

        #region Endpoints

        [HttpGet]
        [CustomAuth]
        public ActionResult Index()
        {
            // Step 1 - Get current user
            var currentUser = TempData[TempDataValues.CurrentUser] as UserModel;
            TempData.Keep(TempDataValues.CurrentUser);

            // Step 2 - Get the number of courses registered/teaching/offered
            if (currentUser.Role == "student")
                ViewBag.NumCourses = StudentCourseAssocService.ListAssocs(new StudentCourseAssocModel { IdStudent = currentUser.IdUser ?? 0 }).Count();
            else if (currentUser.Role == "instructor")        
                ViewBag.NumCourses = InstructorCourseAssocService.ListAssocs(new InstructorCourseAssocModel { IdInstructor = currentUser.IdUser ?? 0 }).Count();                            
            else if (currentUser.Role == "admin")
            {
                // Get current semester value from config
                var currentSemester = System.Configuration.ConfigurationManager.AppSettings["Semester"];

                ViewBag.NumCourses = CoursesService.ListCourses().Where(c => c.Semester.Equals(currentSemester, StringComparison.InvariantCultureIgnoreCase)).ToList().Count();
            }

            return View();
        }

        [CustomAuth]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [CustomAuth]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult InvalidRole()
        {
            return View();
        }

        #endregion
    }
}