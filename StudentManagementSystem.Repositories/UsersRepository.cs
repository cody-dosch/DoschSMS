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
    public class UsersRepository
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["StudentManagementSystemDB"].ConnectionString;

        public List<IUserModel> ListUsers()
        {
            var users = new List<IUserModel>();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.Users_List, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();               

                // Step 2 - Execute the sproc and store the Users in a list
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    // Add a new UserModel for each user in the DB
                    users.Add(new UserModel
                    {
                        IdUser = sqlReader.GetInt32(0),
                        Username = sqlReader.GetString(1),
                        Password = sqlReader.GetString(2),
                        PasswordSalt = sqlReader.GetString(3),
                        Role = sqlReader.GetString(4),
                        FirstName = sqlReader.GetString(5),
                        LastName = sqlReader.GetString(6),
                        Address = sqlReader.GetString(7),
                        City = sqlReader.GetString(8),
                        State = sqlReader.GetString(9),
                        ZipCode = sqlReader.GetString(10),
                    });                   
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return users;
        }
        public IUserModel GetUser(string parameterValue, string parameterName = "@IdUser")
        {
            var user = new UserModel();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.Users_Get, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameter
                // If getting by Id, parse the Id, otherwise get by the specified parameter
                var userId = 0;
                if (parameterName == "@IdUser")
                {
                    userId = Int32.Parse(parameterValue);
                    command.Parameters.AddWithValue(parameterName, userId);
                }
                else
                    command.Parameters.AddWithValue(parameterName, parameterValue);                

                // Step 3 - Execute the sproc and store the User in an object
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    user.IdUser = sqlReader.GetInt32(0);
                    user.Username = sqlReader.GetString(1);
                    user.Password = sqlReader.GetString(2);
                    user.PasswordSalt = sqlReader.GetString(3);
                    user.Role = sqlReader.GetString(4);
                    user.FirstName = sqlReader.GetString(5);
                    user.LastName = sqlReader.GetString(6);
                    user.Address = sqlReader.GetString(7);
                    user.City = sqlReader.GetString(8);
                    user.State = sqlReader.GetString(9);
                    user.ZipCode = sqlReader.GetString(10);
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return user;
        }
        public IUserModel InsertUser(UserModel userModel)
        {
            var addedUser = new UserModel();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.Users_Insert, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameters
                command.Parameters.AddWithValue("@Username", userModel.Username);
                command.Parameters.AddWithValue("@Password", userModel.Password);
                command.Parameters.AddWithValue("@PasswordSalt", userModel.PasswordSalt);
                command.Parameters.AddWithValue("@Role", userModel.Role);
                command.Parameters.AddWithValue("@FirstName", userModel.FirstName);
                command.Parameters.AddWithValue("@LastName", userModel.LastName);
                command.Parameters.AddWithValue("@Address", userModel.Address);
                command.Parameters.AddWithValue("@City", userModel.City);
                command.Parameters.AddWithValue("@State", userModel.State);
                command.Parameters.AddWithValue("@ZipCode", userModel.ZipCode);

                // Step 3 - Execute the sproc and store the new User in an object
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    addedUser.IdUser = sqlReader.GetInt32(0);
                    addedUser.Username = sqlReader.GetString(1);
                    addedUser.Password = sqlReader.GetString(2);
                    addedUser.PasswordSalt = sqlReader.GetString(3);
                    addedUser.Role = sqlReader.GetString(4);
                    addedUser.FirstName = sqlReader.GetString(5);
                    addedUser.LastName = sqlReader.GetString(6);
                    addedUser.Address = sqlReader.GetString(7);
                    addedUser.City = sqlReader.GetString(8);
                    addedUser.State = sqlReader.GetString(9);
                    addedUser.ZipCode = sqlReader.GetString(10);
                }
                sqlReader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return addedUser;
        }
        public IUserModel UpdateUser(EditUserModel userModel)
        {
            var updatedUser = new UserModel();

            try
            {
                // Step 1 - Initialize the connection and set the sproc
                var conn = new SqlConnection(connStr);
                var command = new SqlCommand(StoredProcedures.Users_Update, conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();

                // Step 2 - Set the Parameters
                command.Parameters.AddWithValue("@IdUser", userModel.IdUser);
                command.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(userModel.FirstName) ? "" : userModel.FirstName);
                command.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(userModel.LastName) ? "" : userModel.LastName);
                command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(userModel.Address) ? "" : userModel.Address);
                command.Parameters.AddWithValue("@City", string.IsNullOrEmpty(userModel.City) ? "" : userModel.City);
                command.Parameters.AddWithValue("@State", string.IsNullOrEmpty(userModel.State) ? "" : userModel.State);
                command.Parameters.AddWithValue("@ZipCode", string.IsNullOrEmpty(userModel.ZipCode) ? "" : userModel.ZipCode);

                // Step 3 - Execute the sproc and store the new User in an object
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    updatedUser.IdUser = sqlReader.GetInt32(0);
                    updatedUser.Username = sqlReader.GetString(1);
                    updatedUser.Password = sqlReader.GetString(2);
                    updatedUser.PasswordSalt = sqlReader.GetString(3);
                    updatedUser.Role = sqlReader.GetString(4);
                    updatedUser.FirstName = sqlReader.GetString(5);
                    updatedUser.LastName = sqlReader.GetString(6);
                    updatedUser.Address = sqlReader.GetString(7);
                    updatedUser.City = sqlReader.GetString(8);
                    updatedUser.State = sqlReader.GetString(9);
                    updatedUser.ZipCode = sqlReader.GetString(10);
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return updatedUser;
        }
    }
}
