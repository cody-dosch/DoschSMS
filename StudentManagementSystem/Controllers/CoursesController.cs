using StudentManagementSystem.Extensions;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.ViewModels;
using StudentManagementSystem.Resources;
using StudentManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class CoursesController : Controller
    {
        #region Properties

        private CoursesService CoursesService;
        private ListDataService ListDataService;
        private UsersService UsersService;
        private InstructorCourseAssocService InstructorCourseAssocService;
        private StudentCourseAssocService StudentCourseAssocService;

        #endregion

        #region Constructor

        public CoursesController()
        {
            // Initialize the services
            CoursesService = new CoursesService();
            ListDataService = new ListDataService();
            UsersService = new UsersService();
            InstructorCourseAssocService = new InstructorCourseAssocService();
            StudentCourseAssocService = new StudentCourseAssocService();
        }

        #endregion

        #region Endpoints

        [HttpGet]
        [CustomAuth(Roles = "admin")]
        public ActionResult AddCourse()
        {
            var viewString = ViewStrings.AddCourse;

            // Populate TempData with necessary list data
            GetListData();

            return View(viewString);
        }

        [HttpPost]
        [CustomAuth(Roles = "admin")]
        public ActionResult AddCourse(AddCourseModel model)
        {
            var viewString = ViewStrings.AddCourse;

            // Populate TempData with necessary list data
            GetListData();

            try
            {
                // If model is invalid, show errors
                if (!ModelState.IsValid)
                {
                    return View(viewString, model);
                }

                // If course already exists, display an error
                if (CoursesService.GetCourse(new CourseModel { Department = model.Department, CourseNumber = Int32.Parse(model.CourseNumber) }).IdCourse != null)
                {
                    // Set the error message
                    model.ErrorMessage = "Course already exists";
                    return View(viewString, model);
                }

                // Step 1 - Add submitted data to new CourseModel
                var courseModel = new CourseModel();
                courseModel.Department = model.Department;
                courseModel.CourseNumber = Int32.Parse(model.CourseNumber);
                courseModel.CourseName = model.CourseName;
                courseModel.CourseDescription = model.CourseDescription;
                courseModel.CourseInstructorId = model.CourseInstructorId;
                courseModel.CourseInstructorUsername = UsersService.GetUser(model.CourseInstructorId.ToString()).Username;
                courseModel.Semester = model.Semester;
                courseModel.SeatsOpen = model.SeatsMax.Value;     // On initial course add, SeatsOpen = SeatsMax
                courseModel.SeatsMax = model.SeatsMax.Value;
                courseModel.StartTime = Convert.ToDateTime(model.StartTime);
                courseModel.EndTime = Convert.ToDateTime(model.EndTime);
                courseModel.DayOfWeek = model.DayOfWeek;

                // Step 2 - Add Course to DB
                var addedCourse = CoursesService.InsertCourse(courseModel);

                // Step 3 - If Instructor is assigned, add Instructor Course Association to DB
                if (addedCourse?.IdCourse != null && addedCourse?.CourseInstructorId != null)
                {
                    var addedAssoc = InstructorCourseAssocService.InsertAssoc(new InstructorCourseAssocModel
                    {
                        IdCourse = addedCourse.IdCourse.Value,
                        IdInstructor = addedCourse.CourseInstructorId.Value
                    });
                }

                // Step 4 - Redirect to Success Page if no errors
                if (addedCourse != null)
                {
                    viewString = ViewStrings.AddCourse_Success;
                    return View(viewString);
                }
                else
                {
                    ModelState.AddModelError("AddFailed", "Add Failed");
                    model.ErrorMessage = "Course Not Added";
                    return View(viewString, model);
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return View(viewString, model);
            }
        }

        [HttpGet]
        [CustomAuth(Roles = "admin")]
        public ActionResult EditCourse(int courseId)
        {
            var viewString = ViewStrings.EditCourse;

            // Populate TempData with necessary list data
            GetListData();

            try
            {
                // Step 1 - Get the course by the courseId passed
                var course = CoursesService.GetCourse(new CourseModel { IdCourse = courseId });

                // Step 2 - Set up an EditCourseModel based on the current Course
                var editCourse = new EditCourseModel
                {
                    IdCourse = course.IdCourse,
                    Department = course.Department,
                    CourseNumber = course.CourseNumber,
                    CourseName = course.CourseName,
                    CourseDescription = course.CourseDescription,
                    CourseInstructorId = course.CourseInstructorId,
                    CourseInstructorUsername = course.CourseInstructorUsername,
                    Semester = course.Semester,
                    SeatsMax = course.SeatsMax,
                    SeatsOpen = course.SeatsOpen,
                    StartTime = course.StartTime?.ToShortTimeString(),
                    EndTime = course.EndTime?.ToShortTimeString(),
                    DayOfWeek = course.DayOfWeek
                };

                // Load the page with the Current Course's Info
                return View(viewString, editCourse);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return View(viewString, new EditCourseModel());
            }
        }

        [HttpPost]
        [CustomAuth(Roles = "admin")]
        public ActionResult EditCourse(EditCourseModel model)
        {
            var viewString = ViewStrings.EditCourse;

            try
            {
                // If model is invalid, show errors
                if (!ModelState.IsValid)
                {
                    return View(viewString, model);
                }

                // Step 1 - Calculate SeatsOpen if SeatsMax field is updated
                var existingCourse = CoursesService.GetCourse(new CourseModel { IdCourse = model.IdCourse });
                if (!model.SeatsMax.Equals(existingCourse.SeatsMax))
                {
                    // Updated SeatsMax must be greater than or equal to the number of students currently registered
                    if (!(model.SeatsMax >= existingCourse.SeatsMax - existingCourse.SeatsOpen))
                    {
                        ModelState.AddModelError("UpdateFailed", "Update Failed");
                        model.ErrorMessage = "Seats Available must be greater than " + (existingCourse.SeatsMax - existingCourse.SeatsOpen).ToString();
                        return View(viewString, model);
                    }

                    // Update SeatsOpen: Add or subtract the number of seats added/removed
                    model.SeatsOpen += model.SeatsMax - existingCourse.SeatsMax;
                }

                // Step 2 - Update the CourseInstructorAssoc record if changed
                if (!model.CourseInstructorId.Equals(existingCourse.CourseInstructorId))
                {
                    // If instructor was removed, remove the record
                    if (model.CourseInstructorId == null)
                    {
                        InstructorCourseAssocService.DeleteAssoc(model.IdCourse ?? 0);
                        model.CourseInstructorUsername = null;
                    }
                    else
                    {
                        // If instructor is changed, update or add the record
                        if (InstructorCourseAssocService.GetAssoc(model.IdCourse ?? 0).IdCourse > 0)
                            InstructorCourseAssocService.UpdateAssoc(new InstructorCourseAssocModel { IdCourse = model.IdCourse ?? 0, IdInstructor = model.CourseInstructorId ?? 0 });
                        else
                            InstructorCourseAssocService.InsertAssoc(new InstructorCourseAssocModel { IdCourse = model.IdCourse ?? 0, IdInstructor = model.CourseInstructorId ?? 0 });

                        model.CourseInstructorUsername = UsersService.GetUser(model.CourseInstructorId.ToString()).Username;
                    }
                }

                // Step 3 - Update the User record in the Database and store in TempData for Current User
                CoursesService.UpdateCourse(model);

                // Step 4 - Bring the user to the success page
                viewString = ViewStrings.EditCourse_Success;
                return View(viewString);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return View(viewString, model);
            }
        }

        [HttpGet]
        [CustomAuth]
        public ActionResult Catalogue()
        {
            var viewString = ViewStrings.Course_Catalogue;

            // Populate TempData with necessary list data
            GetListData();

            try
            {
                // Step 1 - Get list of all courses
                var courses = CoursesService.ListCourses();

                // Step 2 - Go to Catalogue view with list
                return View(viewString, courses);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return View(viewString);
            }
        }

        [HttpPost]
        [CustomAuth]
        public ActionResult Catalogue(string department = null, string semester = null)
        {
            var viewString = ViewStrings.Course_Catalogue;

            // Populate TempData with necessary list data
            GetListData();

            try
            {
                // Step 1 - Get list of all courses
                var courses = CoursesService.ListCourses();

                // Step 2 - If filter parameters are passed, filter by given parameters
                if (department != null)
                    courses = courses.Where(c => c.Department.Equals(department, StringComparison.InvariantCultureIgnoreCase)).ToList();
                if (semester != null)
                    courses = courses.Where(c => c.Semester.Equals(semester, StringComparison.InvariantCultureIgnoreCase)).ToList();

                // Step 3 - Go to Catalogue view with list
                return View(viewString, courses);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return View(viewString);
            }
        }

        [HttpGet]
        [CustomAuth]
        public ActionResult CourseDetails(int courseId)
        {
            var viewString = ViewStrings.Course_Details;

            // Populate TempData with necessary list data
            GetListData();

            try
            {
                // Step 1 - Get the course and instructor by the passed Id
                var course = CoursesService.GetCourse(new CourseModel { IdCourse = courseId });
                var instructor = UsersService.GetUser(course.CourseInstructorId.ToString());

                // Step 2 - Create CourseInfoModel for course
                var courseInfoModel = new CourseInfoModel
                {
                    Course = course,
                    InstructorFirstName = instructor.FirstName ?? "",
                    InstructorLastName = instructor.LastName ?? ""
                };

                // Step 3 - Go to CourseDetails view with CourseInfoModel
                return View(viewString, courseInfoModel);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return View(viewString, new CourseInfoModel());
            }
        }

        [CustomAuth(Roles = "student")]
        public ActionResult Register(int courseId)
        {
            var viewString = ViewStrings.Course_Catalogue;

            try
            {               
                // Step 1 - Get current user ID
                var currentUser = TempData[TempDataValues.CurrentUser] as UserModel;
                TempData.Keep(TempDataValues.CurrentUser);
                var studentId = currentUser.IdUser;

                // Step 2 - Add a Student Course Association for the studentId with the passed courseId
                var addedAssoc = StudentCourseAssocService.InsertAssoc(new StudentCourseAssocModel
                {
                    IdCourse = courseId,
                    IdStudent = studentId ?? 0
                });

                // Step 3 - Get course registered for
                var course = CoursesService.GetCourse(new CourseModel { IdCourse = courseId });

                // Step 4 - Update SeatsOpen for the course
                course.SeatsOpen--;
                CoursesService.UpdateCourse(new EditCourseModel 
                {
                    IdCourse = course.IdCourse,
                    CourseName = course.CourseName,
                    CourseDescription = course.CourseDescription,
                    CourseInstructorId = course.CourseInstructorId,
                    CourseInstructorUsername = course.CourseInstructorUsername,
                    Semester = course.Semester,
                    SeatsMax = course.SeatsMax,
                    SeatsOpen = course.SeatsOpen,
                    StartTime = course.StartTime?.ToString(),
                    EndTime = course.EndTime?.ToString(),
                    DayOfWeek = course.DayOfWeek
                });

                // Step 5 - Bring user to success page
                viewString = ViewStrings.Register_Success;
                return View(viewString, course);                  
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return View(viewString);
            }
        }

        [CustomAuth(Roles = "student")]
        public ActionResult Drop(int courseId)
        {
            var viewString = ViewStrings.My_Courses;

            try
            {
                // Step 1 - Get current user ID
                var currentUser = TempData[TempDataValues.CurrentUser] as UserModel;
                TempData.Keep(TempDataValues.CurrentUser);
                var studentId = currentUser.IdUser;

                // Step 2 - Remove the Student Course Association for the studentId with the passed courseId
                var deleted = StudentCourseAssocService.DeleteAssoc(new StudentCourseAssocModel
                {
                    IdCourse = courseId,
                    IdStudent = studentId ?? 0
                });

                // Step 3 - Get course dropping
                var course = CoursesService.GetCourse(new CourseModel { IdCourse = courseId });

                // Step 4 - Update SeatsOpen for the course
                course.SeatsOpen++;
                CoursesService.UpdateCourse(new EditCourseModel
                {
                    IdCourse = course.IdCourse,
                    CourseName = course.CourseName,
                    CourseDescription = course.CourseDescription,
                    CourseInstructorId = course.CourseInstructorId,
                    CourseInstructorUsername = course.CourseInstructorUsername,
                    Semester = course.Semester,
                    SeatsMax = course.SeatsMax,
                    SeatsOpen = course.SeatsOpen,
                    StartTime = course.StartTime?.ToString(),
                    EndTime = course.EndTime?.ToString(),
                    DayOfWeek = course.DayOfWeek
                });

                // Step 5 - Bring user to success page
                viewString = ViewStrings.Drop_Success;
                return View(viewString, course);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return View(viewString);
            }
        }

        [CustomAuth]
        [HttpGet]
        public ActionResult MyCourses()
        {
            var viewString = ViewStrings.My_Courses;

            // List to store courses
            var courses = new List<CourseInfoModel>();

            // Get current semester value from config
            var currentSemester = System.Configuration.ConfigurationManager.AppSettings["Semester"];

            try
            {
                // Step 1 - Get current user
                var currentUser = TempData[TempDataValues.CurrentUser] as UserModel;
                TempData.Keep(TempDataValues.CurrentUser);

                // Step 2 - Get list of all courses registered/teaching
                if (currentUser.Role == "student")
                {
                    // For each registration record, pull in the course info and add it to the list
                    foreach(var course in StudentCourseAssocService.ListAssocs(new StudentCourseAssocModel { IdStudent = currentUser.IdUser ?? 0 }))
                    {
                        var courseInfo = CoursesService.GetCourse(new CourseModel { IdCourse = course.IdCourse });
                        var instructorInfo = UsersService.GetUser(courseInfo.CourseInstructorId.ToString());

                        courses.Add(new CourseInfoModel 
                        { 
                            Course = courseInfo,
                            InstructorFirstName = instructorInfo.FirstName,
                            InstructorLastName = instructorInfo.LastName
                        });
                    }
                }
                else if (currentUser.Role == "instructor")
                {
                    // For each instructor record, pull in the course info and add it to the list
                    foreach (var course in InstructorCourseAssocService.ListAssocs(new InstructorCourseAssocModel { IdInstructor = currentUser.IdUser ?? 0 }))
                    {
                        var courseInfo = CoursesService.GetCourse(new CourseModel { IdCourse = course.IdCourse });
                        var instructorInfo = UsersService.GetUser(courseInfo.CourseInstructorId.ToString());

                        courses.Add(new CourseInfoModel
                        {
                            Course = courseInfo,
                            InstructorFirstName = instructorInfo.FirstName,
                            InstructorLastName = instructorInfo.LastName
                        });
                    }
                }

                // Step 3 - Filter courses by current semester
                courses = courses.Where(c => c.Course.Semester.Equals(currentSemester, StringComparison.InvariantCultureIgnoreCase)).ToList();

                // Step 4 - Go to Catalogue view with list
                return View(viewString, courses);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return View(viewString);
            }
        }

        [CustomAuth(Roles = "student")]
        [HttpGet]
        public ActionResult StudentHome(int courseId)
        {
            var viewString = ViewStrings.Course_StudentHome;

            try
            {
                // If student isn't registered for the course, redirect to an error page
                var currentUser = TempData[TempDataValues.CurrentUser] as UserModel;
                TempData.Keep(TempDataValues.CurrentUser);
                if (!(StudentCourseAssocService.GetAssoc(new StudentCourseAssocModel { IdCourse = courseId, IdStudent = currentUser.IdUser ?? 0 }).IdStudent > 0))
                {
                    return RedirectToAction("InvalidRole", "Errors");
                }

                // Step 1 - Get the course and instructor by the passed Id
                var course = CoursesService.GetCourse(new CourseModel { IdCourse = courseId });
                var instructor = UsersService.GetUser(course.CourseInstructorId.ToString());

                // Step 2 - Create CourseInfoModel for course
                var courseInfoModel = new CourseInfoModel
                {
                    Course = course,
                    InstructorFirstName = instructor.FirstName ?? "",
                    InstructorLastName = instructor.LastName ?? ""
                };

                // Step 3 - Get participants list
                courseInfoModel.Participants = new List<Interfaces.Models.IUserModel>();
                foreach (var student in StudentCourseAssocService.ListAssocs(new StudentCourseAssocModel { IdCourse = courseId }))
                {
                    // Add each student registered for the course to the participants list
                    courseInfoModel.Participants.Add(UsersService.GetUser(student.IdStudent.ToString()));
                }

                // TODO: Step 4- Get Assignments by courseId (Add to CourseInfoModel)

                // Step 4 - Go to StudentHome view with CourseInfoModel
                return View(viewString, courseInfoModel);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return View(viewString, new CourseInfoModel());
            }
        }

        [CustomAuth(Roles = "instructor")]
        [HttpGet]
        public ActionResult InstructorHome(int courseId)
        {
            var viewString = ViewStrings.Course_InstructorHome;

            try
            {
                // If student isn't registered for the course, redirect to an error page
                var currentUser = TempData[TempDataValues.CurrentUser] as UserModel;
                TempData.Keep(TempDataValues.CurrentUser);
                if (!(InstructorCourseAssocService.GetAssoc(courseId).IdInstructor > 0))
                {
                    return RedirectToAction("InvalidRole", "Errors");
                }

                // Step 1 - Get the course and instructor by the passed Id
                var course = CoursesService.GetCourse(new CourseModel { IdCourse = courseId });
                var instructor = UsersService.GetUser(course.CourseInstructorId.ToString());

                // Step 2 - Create CourseInfoModel for course
                var courseInfoModel = new CourseInfoModel
                {
                    Course = course,
                    InstructorFirstName = instructor.FirstName ?? "",
                    InstructorLastName = instructor.LastName ?? ""
                };

                // Step 3 - Get participants list
                courseInfoModel.Participants = new List<Interfaces.Models.IUserModel>();
                foreach (var student in StudentCourseAssocService.ListAssocs(new StudentCourseAssocModel { IdCourse = courseId }))
                {
                    // Add each student registered for the course to the participants list
                    courseInfoModel.Participants.Add(UsersService.GetUser(student.IdStudent.ToString()));
                }

                // TODO: Step 4- Get Assignments by courseId (Add to CourseInfoModel)

                // Step 4 - Go to StudentHome view with CourseInfoModel
                return View(viewString, courseInfoModel);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return View(viewString, new CourseInfoModel());
            }
        }

        #endregion

        #region Private Methods

        private void GetListData()
        {
            // Get data for dropdown lists
            TempData[TempDataValues.Departments] = ListDataService.Departments();
            TempData[TempDataValues.Instructors] = ListDataService.Instructors();
            TempData[TempDataValues.Semesters] = ListDataService.Semesters();
            TempData[TempDataValues.DaysOfWeek] = ListDataService.DaysOfWeek();

            // Get information based on current user
            var currentUser = TempData[TempDataValues.CurrentUser] as UserModel;
            TempData.Keep(TempDataValues.CurrentUser);
            if (currentUser.Role == "student")
                TempData[TempDataValues.StudentCoursesAccessible] = StudentCourseAssocService.ListAssocs(new StudentCourseAssocModel { IdStudent = currentUser.IdUser ?? 0 });
            else if (currentUser.Role == "instructor")
                TempData[TempDataValues.InstructorCoursesAccessible] = InstructorCourseAssocService.ListAssocs(new InstructorCourseAssocModel { IdInstructor = currentUser.IdUser ?? 0 });
        }

        #endregion
    }
}