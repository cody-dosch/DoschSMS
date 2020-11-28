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
    public class RolesRepository
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["StudentManagementSystemDB"].ConnectionString;

        public List<IRoleModel> ListRoles()
        {
            var roles = new List<IRoleModel>();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.Roles_List, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Execute the sproc and store the list in an object
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    roles.Add(new RoleModel
                    {
                        IdRole = sqlReader.GetInt32(0),
                        Key = sqlReader.GetString(1),
                        Value = sqlReader.GetString(2)
                    });
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return roles;
        }
    }
}
