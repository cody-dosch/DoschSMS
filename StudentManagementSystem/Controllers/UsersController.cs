using StudentManagementSystem.Extensions;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.ViewModels;
using StudentManagementSystem.Resources;
using StudentManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class UsersController : Controller
    {
        #region Properties

        private UsersService UsersService;
        private ListDataService ListDataService;

        #endregion

        #region Constructor

        public UsersController()
        {
            // Initialize the services
            UsersService = new UsersService();
            ListDataService = new ListDataService();
        }

        #endregion

        #region Endpoints

        [HttpGet]
        [CustomAuth(Roles = "admin")]
        public ActionResult AddUser()
        {
            var viewString = ViewStrings.AddUser;

            // Populate TempData with necessary list data
            GetListData();

            return View(viewString);
        }

        [HttpPost]
        [CustomAuth(Roles = "admin")]
        public ActionResult AddUser(AddUserModel model)
        {
            var viewString = ViewStrings.AddUser;

            // Populate TempData with necessary list data
            GetListData();
            
            try
            {
                // If model is invalid, show errors
                if (!ModelState.IsValid)
                {
                    return View(viewString, model);
                }

                // If user already exists, display an error
                if (UsersService.GetUser(model.Username, "@Username").Username != null)
                {
                    // Set the error message
                    model.ErrorMessage = "User already exists";
                    return View(viewString, model);
                }

                // Step 1 - Add submitted data to new UserModel
                var userModel = new UserModel();
                userModel.Username = model.Username;
                userModel.Password = model.Password;
                userModel.Role = model.Role;
                userModel.FirstName = model.FirstName;
                userModel.LastName = model.LastName;
                userModel.Address = model.Address;
                userModel.City = model.City;
                userModel.State = model.State;
                userModel.ZipCode = model.ZipCode;

                // Step 2 - Generate Password Salt
                var crypto = new RNGCryptoServiceProvider();
                var salt = new byte[32];
                crypto.GetBytes(salt);
                userModel.PasswordSalt = Convert.ToBase64String(salt);

                // Step 3 - Add Salt to Password and Hash
                var hashAlgorithm = new Rfc2898DeriveBytes(model.Password, salt);
                userModel.Password = Convert.ToBase64String(hashAlgorithm.GetBytes(64));

                // Step 4 - Add User to DB
                var addedUser = UsersService.InsertUser(userModel);

                // Step 5 - Redirect to Success Page if no errors
                if (addedUser != null)
                {
                    viewString = ViewStrings.AddUser_Success;
                    return View(viewString);
                }
                else
                {
                    ModelState.AddModelError("AddFailed", "Add Failed");
                    model.ErrorMessage = "User Not Added";
                    return View(viewString, model);
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
                return View(viewString);
            }           
        }

        [HttpGet]
        [CustomAuth]
        public ActionResult EditUser()
        {
            var viewString = ViewStrings.EditUser;

            try
            {               
                // Get the Current User from TempData, and keep it stored
                var currentUser = TempData[TempDataValues.CurrentUser] as UserModel;
                TempData.Keep(TempDataValues.CurrentUser);

                // Set up an EditUserModel based on the Current User
                var editCurrentUser = new EditUserModel
                {
                    IdUser = currentUser.IdUser,
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    Address = currentUser.Address,
                    City = currentUser.City,
                    State = currentUser.State,
                    ZipCode = currentUser.ZipCode
                };

                // Load the page with the Current User's Info
                return View(viewString, editCurrentUser);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return View(viewString);
            }            
        }

        [HttpPost]
        [CustomAuth]
        public ActionResult EditUser(EditUserModel model)
        {
            var viewString = ViewStrings.EditUser;

            try
            {
                // If model is invalid, show errors
                if (!ModelState.IsValid)
                {
                    return View(viewString, model);
                }

                // Step 1 - Update the User record in the Database and store in TempData for Current User
                var updatedUser = UsersService.UpdateUser(model);
                if (updatedUser != null)
                    TempData[TempDataValues.CurrentUser] = updatedUser;

                // Step 2 - Bring the user to the success page if no errors
                if (updatedUser != null)
                {
                    viewString = ViewStrings.EditUser_Success;
                    return View(viewString);
                }
                else
                {
                    ModelState.AddModelError("UpdateFailed", "Update Failed");
                    model.ErrorMessage = "User Not Updated";
                    return View(viewString, model);
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
                return View(viewString);
            }                      
        }

        [HttpGet]
        [CustomAuth]
        public ActionResult Profile()
        {
            var viewString = ViewStrings.Profile;

            try
            {
                // Step 1 - Get the Current User from TempData, and keep it stored
                var currentUser = TempData[TempDataValues.CurrentUser] as UserModel;
                TempData.Keep(TempDataValues.CurrentUser);

                // Step 2 - Load the page with the Current User's Info
                return View(viewString, currentUser);
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
                return View(viewString);
            }           
        }

        #endregion

        #region Private Methods

        private void GetListData()
        {
            TempData[TempDataValues.Roles] = ListDataService.Roles();
        }

        #endregion
    }
}