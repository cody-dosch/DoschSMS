using StudentManagementSystem.Models;
using StudentManagementSystem.Models.ViewModels;
using StudentManagementSystem.Repositories;
using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Services
{
    public class CoursesService
    {
        #region Properties

        private CoursesRepository CoursesRepository;

        #endregion

        #region Constructor

        public CoursesService()
        {
            // Initialize the repositories
            CoursesRepository = new CoursesRepository();
        }

        #endregion

        #region Public Methods

        public CourseModel InsertCourse(CourseModel courseModel)
        {
            var addedCourse = new CourseModel();

            try
            {
                // Null check the model, then insert the course
                if (courseModel != null && courseModel.CourseNumber != null && !string.IsNullOrWhiteSpace(courseModel.Semester))
                {
                    addedCourse = CoursesRepository.InsertCourse(courseModel) as CourseModel;
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }

            return addedCourse;
        }

        public CourseModel UpdateCourse(EditCourseModel courseModel)
        {
            var updatedCourse = new CourseModel();

            try
            {
                // Null check the model, then update the user
                if (courseModel != null && courseModel.IdCourse != null)
                {
                    updatedCourse = CoursesRepository.UpdateCourse(courseModel) as CourseModel;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return updatedCourse;
        }

        public CourseModel GetCourse(CourseModel courseModel)
        {
            var course = new CourseModel();

            try
            {
                // Null check the parameters, then get the course
                if (courseModel != null)
                {
                    course = CoursesRepository.GetCourse(courseModel) as CourseModel;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return course;
        }

        public List<CourseModel> ListCourses()
        {
            var courses = new List<CourseModel>();

            try
            {
                // Get list of all courses
                courses = CoursesRepository.ListCourses().ConvertAll(c => (CourseModel)c);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return courses;
        }

        #endregion
    }
}
