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
    public class DepartmentsRepository
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["StudentManagementSystemDB"].ConnectionString;

        public List<IDepartmentModel> ListDepartments()
        {
            var departments = new List<IDepartmentModel>();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.Departments_List, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Execute the sproc and store the list in an object
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    departments.Add(new DepartmentModel
                    {
                        IdDepartment = sqlReader.GetInt32(0),
                        DepartmentName = sqlReader.GetString(1),
                        DepartmentValue = sqlReader.GetString(2)
                    });
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return departments;
        }
    }
}
