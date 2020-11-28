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
    public class ErrorsController : Controller
    {
        #region Properties



        #endregion

        #region Constructor

        public ErrorsController()
        {

        }

        #endregion

        #region Endpoints

        [HttpGet]
        public ActionResult Error404()
        {
            var viewString = ViewStrings.Error_404;           

            return View(viewString);
        }

        [HttpGet]
        public ActionResult InvalidRole()
        {
            var viewString = ViewStrings.Error_InvalidRole;

            return View(viewString);
        }

        #endregion

        #region Private Methods

        #endregion
    }
}