// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "DefaultController.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Web.Areas.Admin.Controllers
{
    using BusinessService.Service.Contract.Admin;
    using Microsoft.AspNetCore.Mvc;
    using Web.Areas.Admin.Mappers.Contracts.Admin;
    using Web.Controllers;

    [Area("Admin")]
    public class DefaultController : BaseController
    {
        private IAdminService adminService;
        private IAdminModelMapper adminModelMapper;

        public DefaultController(IAdminService adminService, IAdminModelMapper adminModelMapper)
        {
            this.adminService = adminService;
            this.adminModelMapper = adminModelMapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("adminsetup")]
        public IActionResult AdminSetup()
        {
            return View();
        }

        [HttpPost]
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

        [HttpPost]
        [Route("/createAdmin")]
        public IActionResult CreateAdmin(string userName, string email, string password, string phoneNumber)
        {
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(email) &&
                !string.IsNullOrWhiteSpace(password))
            {
                var adminModel = new Models.AdminUser
                {
                    UserName = userName,
                    Email = email,
                    Password = password,
                    Telephone = phoneNumber
                };

                var result = adminService.CreateAdminUser(adminModelMapper.Map(adminModel));
                if (result)
                {
                    return View("AdminSetup");
                }
                return BadRequest();
            }
            return BadRequest();
        }
    }
}