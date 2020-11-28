using StudentManagementSystem.Models;
using StudentManagementSystem.Models.ViewModels;
using StudentManagementSystem.Repositories;
using System;

namespace StudentManagementSystem.Services
{
    public class UsersService
    {
        #region Properties

        private UsersRepository UsersRepository;

        #endregion

        #region Constructor

        public UsersService()
        {
            // Initialize the repositories
            UsersRepository = new UsersRepository();
        }

        #endregion

        #region Public Methods

        public UserModel InsertUser(UserModel userModel)
        {
            var addedUser = new UserModel();

            try
            {
                // Null check the model, then insert the user
                if (userModel != null && !string.IsNullOrWhiteSpace(userModel.Username) && !string.IsNullOrWhiteSpace(userModel.Password))
                {
                    addedUser = UsersRepository.InsertUser(userModel) as UserModel;
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }

            return addedUser;
        }

        public UserModel UpdateUser(EditUserModel userModel)
        {
            var updatedUser = new UserModel();

            try
            {
                // Null check the model, then update the user
                if (userModel != null && userModel.IdUser != null)
                {
                    updatedUser = UsersRepository.UpdateUser(userModel) as UserModel;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return updatedUser;
        }

        public UserModel GetUser(string parameterValue, string parameterName = "@IdUser")
        {
            var user = new UserModel();

            try
            {
                // Null check the parameter, then get the user
                if (!string.IsNullOrWhiteSpace(parameterValue))
                {
                    user = UsersRepository.GetUser(parameterValue, parameterName) as UserModel;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return user;
        }

        #endregion
    }
}
