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
    public class StudentCourseAssocRepository
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["StudentManagementSystemDB"].ConnectionString;

        public List<IStudentCourseAssocModel> ListAssocs(StudentCourseAssocModel assocModel)
        {
            var associations = new List<IStudentCourseAssocModel>();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.StudentCourseAssoc_List, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameters

                // Null int for parameter assignment
                int? nullInt = null;

                command.Parameters.AddWithValue("@IdCourse", assocModel.IdCourse == 0 ? nullInt : assocModel.IdCourse);
                command.Parameters.AddWithValue("@IdStudent", assocModel.IdStudent == 0 ? nullInt : assocModel.IdStudent);

                // Step 3 - Execute the sproc and store the Courses in an object
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    // Add each association to the list
                    associations.Add(new StudentCourseAssocModel
                    {
                        IdCourse = sqlReader.GetInt32(0),
                        IdStudent = sqlReader.GetInt32(1)
                    });                  
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return associations;
        }
        public IStudentCourseAssocModel GetAssoc(StudentCourseAssocModel assocModel)
        {
            var association = new StudentCourseAssocModel();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.StudentCourseAssoc_Get, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameters
                command.Parameters.AddWithValue("@IdCourse", assocModel.IdCourse);              
                command.Parameters.AddWithValue("@IdStudent", assocModel.IdStudent);              

                // Step 3 - Execute the sproc and store the Association in an object
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    association.IdCourse = sqlReader.GetInt32(0);
                    association.IdStudent = sqlReader.GetInt32(1);
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return association;
        }
        public IStudentCourseAssocModel InsertAssoc(StudentCourseAssocModel assocModel)
        {
            var addedAssoc = new StudentCourseAssocModel();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.StudentCourseAssoc_Insert, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameters
                command.Parameters.AddWithValue("@IdCourse", assocModel.IdCourse);
                command.Parameters.AddWithValue("@IdStudent", assocModel.IdStudent);
                
                // Step 3 - Execute the sproc and store the new Association in an object
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    addedAssoc.IdCourse = sqlReader.GetInt32(0);
                    addedAssoc.IdStudent = sqlReader.GetInt32(1);                   
                }
                sqlReader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return addedAssoc;
        }
        public bool DeleteAssoc(StudentCourseAssocModel assocModel)
        {
            var deleted = false;

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.StudentCourseAssoc_Delete, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameters
                command.Parameters.AddWithValue("@IdCourse", assocModel.IdCourse);
                command.Parameters.AddWithValue("@IdStudent", assocModel.IdStudent);

                // Step 3 - Execute the sproc and set deleted to true
                var sqlReader = command.ExecuteReader();
                deleted = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                deleted = false;
            }

            return deleted;
        }
    }
}
