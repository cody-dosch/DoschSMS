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
    public class InstructorCourseAssocRepository
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["StudentManagementSystemDB"].ConnectionString;

        public List<IInstructorCourseAssocModel> ListAssocs(InstructorCourseAssocModel assocModel)
        {
            var associations = new List<IInstructorCourseAssocModel>();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.InstructorCourseAssoc_List, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameters

                // Null int for parameter assignment
                int? nullInt = null;

                command.Parameters.AddWithValue("@IdCourse", assocModel.IdCourse == 0 ? nullInt : assocModel.IdCourse);
                command.Parameters.AddWithValue("@IdInstructor", assocModel.IdInstructor == 0 ? nullInt : assocModel.IdInstructor);

                // Step 3 - Execute the sproc and store the Courses in an object
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    // Add each association to the list
                    associations.Add(new InstructorCourseAssocModel
                    {
                        IdCourse = sqlReader.GetInt32(0),
                        IdInstructor = sqlReader.GetInt32(1)
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
        public IInstructorCourseAssocModel GetAssoc(int courseId)
        {
            var association = new InstructorCourseAssocModel();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.InstructorCourseAssoc_Get, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameters
                command.Parameters.AddWithValue("@IdCourse", courseId);              

                // Step 3 - Execute the sproc and store the Association in an object
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    association.IdCourse = sqlReader.GetInt32(0);
                    association.IdInstructor = sqlReader.GetInt32(1);
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return association;
        }
        public IInstructorCourseAssocModel InsertAssoc(InstructorCourseAssocModel assocModel)
        {
            var addedAssoc = new InstructorCourseAssocModel();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.InstructorCourseAssoc_Insert, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameters
                command.Parameters.AddWithValue("@IdCourse", assocModel.IdCourse);
                command.Parameters.AddWithValue("@IdInstructor", assocModel.IdInstructor);
                
                // Step 3 - Execute the sproc and store the new Association in an object
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    addedAssoc.IdCourse = sqlReader.GetInt32(0);
                    addedAssoc.IdInstructor = sqlReader.GetInt32(1);                   
                }
                sqlReader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return addedAssoc;
        }
        public IInstructorCourseAssocModel UpdateAssoc(InstructorCourseAssocModel assocModel)
        {
            var updatedAssoc = new InstructorCourseAssocModel();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.InstructorCourseAssoc_Update, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameters
                command.Parameters.AddWithValue("@IdCourse", assocModel.IdCourse);
                command.Parameters.AddWithValue("@IdInstructor", assocModel.IdInstructor);

                // Step 3 - Execute the sproc and store the updated Association in an object
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    updatedAssoc.IdCourse = sqlReader.GetInt32(0);
                    updatedAssoc.IdInstructor = sqlReader.GetInt32(1);
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return updatedAssoc;
        }
        public bool DeleteAssoc(int courseId)
        {
            var deleted = false;

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.InstructorCourseAssoc_Delete, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameters
                command.Parameters.AddWithValue("@IdCourse", courseId);

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
