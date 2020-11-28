using System;
using StudentManagementSystem.Interfaces.Models;
using StudentManagementSystem.Models;
using StudentManagementSystem.Resources;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using StudentManagementSystem.Models.ViewModels;

namespace StudentManagementSystem.Repositories
{
    public class CoursesRepository
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["StudentManagementSystemDB"].ConnectionString;

        public List<ICourseModel> ListCourses()
        {
            var courses = new List<ICourseModel>();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.Courses_List, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Execute the sproc and store the Courses in an object
                var sqlReader = command.ExecuteReader();

                // Null DateTime for null assignment 
                DateTime? nullDateTime = null;

                while (sqlReader.Read())
                {
                    // Add each course to the list
                    courses.Add(new CourseModel
                    {
                        IdCourse = sqlReader.GetInt32(0),
                        Department = sqlReader.GetString(1),
                        CourseNumber = sqlReader.GetInt32(2),
                        CourseName = sqlReader.GetString(3),
                        CourseDescription = sqlReader.IsDBNull(4) ? "" : sqlReader.GetString(4),
                        CourseInstructorId = sqlReader.IsDBNull(5) ? 0 : sqlReader.GetInt32(5),
                        CourseInstructorUsername = sqlReader.IsDBNull(6) ? "" : sqlReader.GetString(6),
                        Semester = sqlReader.GetString(7),
                        SeatsOpen = sqlReader.GetInt32(8),
                        SeatsMax = sqlReader.GetInt32(9),
                        StartTime = sqlReader.IsDBNull(10) ? nullDateTime : sqlReader.GetDateTime(10),
                        EndTime = sqlReader.IsDBNull(11) ? nullDateTime : sqlReader.GetDateTime(11),
                        DayOfWeek = sqlReader.IsDBNull(12) ? "" : sqlReader.GetString(12)
                    });                  
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return courses;
        }
        public ICourseModel GetCourse(CourseModel courseModel)
        {
            var course = new CourseModel();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.Courses_Get, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameters
                // If passing an Id, assign the Id parameter
                if (courseModel.IdCourse != null)
                    command.Parameters.AddWithValue("@IdCourse", courseModel.IdCourse);
                
                // If searching by Department and CourseNumber, set the parameters
                if (!string.IsNullOrWhiteSpace(courseModel.Department))
                    command.Parameters.AddWithValue("@Department", courseModel.Department);
                if (courseModel.CourseNumber != null)
                    command.Parameters.AddWithValue("@CourseNumber", courseModel.CourseNumber);

                // Step 3 - Execute the sproc and store the Course in an object
                var sqlReader = command.ExecuteReader();

                // Null DateTime for null assignment 
                DateTime? nullDateTime = null;

                while (sqlReader.Read())
                {
                    course.IdCourse = sqlReader.GetInt32(0);
                    course.Department = sqlReader.GetString(1);
                    course.CourseNumber = sqlReader.GetInt32(2);
                    course.CourseName = sqlReader.GetString(3);
                    course.CourseDescription = sqlReader.IsDBNull(4) ? "" : sqlReader.GetString(4);
                    course.CourseInstructorId = sqlReader.IsDBNull(5) ? 0 : sqlReader.GetInt32(5);
                    course.CourseInstructorUsername = sqlReader.IsDBNull(6) ? "" : sqlReader.GetString(6);
                    course.Semester = sqlReader.GetString(7);
                    course.SeatsOpen = sqlReader.GetInt32(8);
                    course.SeatsMax = sqlReader.GetInt32(9);
                    course.StartTime = sqlReader.IsDBNull(10) ? nullDateTime : sqlReader.GetDateTime(10);
                    course.EndTime = sqlReader.IsDBNull(11) ? nullDateTime : sqlReader.GetDateTime(11);
                    course.DayOfWeek = sqlReader.IsDBNull(12) ? "" : sqlReader.GetString(12);
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return course;
        }
        public ICourseModel InsertCourse(CourseModel courseModel)
        {
            var addedCourse = new CourseModel();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.Courses_Insert, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameters
                command.Parameters.AddWithValue("@Department", courseModel.Department);
                command.Parameters.AddWithValue("@CourseNumber", courseModel.CourseNumber);
                command.Parameters.AddWithValue("@CourseName", courseModel.CourseName);
                command.Parameters.AddWithValue("@CourseDescription", courseModel.CourseDescription);
                command.Parameters.AddWithValue("@CourseInstructorId", courseModel.CourseInstructorId);
                command.Parameters.AddWithValue("@CourseInstructorUsername", courseModel.CourseInstructorUsername);
                command.Parameters.AddWithValue("@Semester", courseModel.Semester);
                command.Parameters.AddWithValue("@SeatsOpen", courseModel.SeatsOpen);
                command.Parameters.AddWithValue("@SeatsMax", courseModel.SeatsMax);
                command.Parameters.AddWithValue("@StartTime", courseModel.StartTime);
                command.Parameters.AddWithValue("@EndTime", courseModel.EndTime);
                command.Parameters.AddWithValue("@DayOfWeek", courseModel.DayOfWeek);

                // Step 3 - Execute the sproc and store the new Course in an object
                var sqlReader = command.ExecuteReader();

                // Null DateTime for null assignment 
                DateTime? nullDateTime = null;

                while (sqlReader.Read())
                {
                    addedCourse.IdCourse = sqlReader.GetInt32(0);
                    addedCourse.Department = sqlReader.GetString(1);
                    addedCourse.CourseNumber = sqlReader.GetInt32(2);
                    addedCourse.CourseName = sqlReader.GetString(3);
                    addedCourse.CourseDescription = sqlReader.IsDBNull(4) ? "" : sqlReader.GetString(4);
                    addedCourse.CourseInstructorId = sqlReader.IsDBNull(5) ? 0 : sqlReader.GetInt32(5);
                    addedCourse.CourseInstructorUsername = sqlReader.IsDBNull(6) ? "" : sqlReader.GetString(6);
                    addedCourse.Semester = sqlReader.GetString(7);
                    addedCourse.SeatsOpen = sqlReader.GetInt32(8);
                    addedCourse.SeatsMax = sqlReader.GetInt32(9);
                    addedCourse.StartTime = sqlReader.IsDBNull(10) ? nullDateTime : sqlReader.GetDateTime(10);
                    addedCourse.EndTime = sqlReader.IsDBNull(11) ? nullDateTime : sqlReader.GetDateTime(11);
                    addedCourse.DayOfWeek = sqlReader.IsDBNull(12) ? "" : sqlReader.GetString(12);
                }
                sqlReader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return addedCourse;
        }
        public ICourseModel UpdateCourse(EditCourseModel courseModel)
        {
            var updatedCourse = new CourseModel();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.Courses_Update, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameters
                command.Parameters.AddWithValue("@IdCourse", courseModel.IdCourse);
                command.Parameters.AddWithValue("@CourseName", courseModel.CourseName);
                command.Parameters.AddWithValue("@CourseDescription", string.IsNullOrEmpty(courseModel.CourseDescription) ? "" : courseModel.CourseDescription);
                command.Parameters.AddWithValue("@CourseInstructorId", courseModel.CourseInstructorId == 0 ? null : courseModel.CourseInstructorId);
                command.Parameters.AddWithValue("@CourseInstructorUsername", string.IsNullOrEmpty(courseModel.CourseInstructorUsername) ? null : courseModel.CourseInstructorUsername);
                command.Parameters.AddWithValue("@Semester", courseModel.Semester);
                command.Parameters.AddWithValue("@SeatsMax", courseModel.SeatsMax);
                command.Parameters.AddWithValue("@SeatsOpen", courseModel.SeatsOpen);
                command.Parameters.AddWithValue("@StartTime", string.IsNullOrEmpty(courseModel.StartTime) ? "" : courseModel.StartTime);
                command.Parameters.AddWithValue("@EndTime", string.IsNullOrEmpty(courseModel.EndTime) ? "" : courseModel.EndTime);
                command.Parameters.AddWithValue("@DayOfWeek", string.IsNullOrEmpty(courseModel.DayOfWeek) ? "" : courseModel.DayOfWeek);

                // Step 3 - Execute the sproc and store the new User in an object
                var sqlReader = command.ExecuteReader();

                // Null values for null assignment 
                DateTime? nullDateTime = null;

                while (sqlReader.Read())
                {
                    updatedCourse.IdCourse = sqlReader.GetInt32(0);
                    updatedCourse.Department = sqlReader.GetString(1);
                    updatedCourse.CourseNumber = sqlReader.GetInt32(2);
                    updatedCourse.CourseName = sqlReader.GetString(3);
                    updatedCourse.CourseDescription = sqlReader.IsDBNull(4) ? "" : sqlReader.GetString(4);
                    updatedCourse.CourseInstructorId = sqlReader.IsDBNull(5) ? 0 : sqlReader.GetInt32(5);
                    updatedCourse.CourseInstructorUsername = sqlReader.IsDBNull(6) ? "" : sqlReader.GetString(6);
                    updatedCourse.Semester = sqlReader.GetString(7);
                    updatedCourse.SeatsOpen = sqlReader.GetInt32(8);
                    updatedCourse.SeatsMax = sqlReader.GetInt32(9);
                    updatedCourse.StartTime = sqlReader.IsDBNull(10) ? nullDateTime : sqlReader.GetDateTime(10);
                    updatedCourse.EndTime = sqlReader.IsDBNull(11) ? nullDateTime : sqlReader.GetDateTime(11);
                    updatedCourse.DayOfWeek = sqlReader.IsDBNull(12) ? "" : sqlReader.GetString(12);
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return updatedCourse;
        }
    }
}
