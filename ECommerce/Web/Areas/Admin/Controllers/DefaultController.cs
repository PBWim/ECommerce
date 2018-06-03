// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "DefaultController.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Web.Controllers;

    [Area("Admin")]
    public class DefaultController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("adminsetup")]
        public IActionResult AdminSetup()
        {
            return View();
        }

        [Route("/adminlogin")]
        public IActionResult AdminLogin(string email, string password)
        {
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                return View("AdminSetup");
                // return RedirectToAction("Index", "Items");
            }
            return BadRequest();
        }
    }
}