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
    public class DaysOfWeekRepository
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["StudentManagementSystemDB"].ConnectionString;

        public List<IDayOfWeekModel> ListDaysOfWeek()
        {
            var daysOfWeek = new List<IDayOfWeekModel>();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.DaysOfWeek_List, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Execute the sproc and store the list in an object
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    daysOfWeek.Add(new DayOfWeekModel
                    {
                        Day = sqlReader.GetString(0)
                    });
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return daysOfWeek;
        }
    }
}
