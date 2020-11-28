using System;
using StudentManagementSystem.Interfaces.Models;
using StudentManagementSystem.Models;
using StudentManagementSystem.Resources;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentManagementSystem.Repositories
{
    public class SemestersRepository
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["StudentManagementSystemDB"].ConnectionString;

        public List<ISemesterModel> ListSemesters()
        {
            var semesters = new List<ISemesterModel>();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.Semesters_List, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Execute the sproc and store the list in an object
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    semesters.Add(new SemesterModel
                    {
                        IdSemester = sqlReader.GetInt32(0),
                        SemesterName = sqlReader.GetString(1),
                        SemesterValue = sqlReader.GetString(2)
                    });
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return semesters;
        }
    }
}
