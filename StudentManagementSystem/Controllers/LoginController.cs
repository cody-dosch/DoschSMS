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
    public class LoginController : Controller
    {
        #region Properties

        private UsersService UsersService;

        #endregion

        #region Constructor

        public LoginController()
        {
            // Initialize the services
            UsersService = new UsersService();
        }

        #endregion

        #region Endpoints

        [HttpGet]
        public ActionResult Login()
        {
            var viewString = ViewStrings.Login;           

            return View(viewString);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var viewString = ViewStrings.Login;

            try
            {
                // Step 1 - Get the requested user's information
                var requestedUser = UsersService.GetUser(model.Username, "@Username");

                // If there is no user with the requested username, display an error
                if (requestedUser.Username == null)
                {
                    model.ErrorMessage = "Invalid Username or Password";
                    return View(viewString, model);
                }

                // Step 2 - Authenticate the user
                var saltBytes = Convert.FromBase64String(requestedUser.PasswordSalt);
                var hash = new Rfc2898DeriveBytes(model.Password, saltBytes);
                var submittedPassword = Convert.ToBase64String(hash.GetBytes(64));

                if (submittedPassword.Equals(requestedUser.Password))
                {
                    // Store the authenticated user in TempData and Session and navigate to Home Page
                    TempData[TempDataValues.CurrentUser] = requestedUser;
                    Session["User"] = requestedUser;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    model.ErrorMessage = "Invalid Username or Password";
                    return View(viewString, model);
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return View(viewString);
        }

        public ActionResult Logout()
        {
            var viewString = ViewStrings.Login;

            try
            {
                // Step 1 - Clear Current User from TempData and Session
                TempData.Remove(TempDataValues.CurrentUser);
                Session.Remove("User");

                // Step 2 - Redirect to Login Page
                return RedirectToAction("Login", "Login");
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return View(viewString);
        }

        #endregion

        #region Private Methods

        #endregion
    }
}