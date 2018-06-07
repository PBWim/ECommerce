// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "DefaultController.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Web.Areas.Admin.Controllers
{
    using BusinessService.Service.Contract.Admin;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Web.Areas.Admin.Mappers.Contracts.Admin;
    using Web.Controllers;

    [Area("Admin")]
    public class DefaultController : BaseController
    {
        private IAdminService adminService;
        private IAdminModelMapper adminModelMapper;
        private ILogger logger;

        public DefaultController(IAdminService adminService, IAdminModelMapper adminModelMapper, ILogger<DefaultController> logger)
        {
            this.adminService = adminService;
            this.adminModelMapper = adminModelMapper;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            logger.LogInformation("Admin Index");
            return View();
        }

        [Route("adminsetup")]
        public IActionResult AdminSetup()
        {
            logger.LogInformation("Admin SetUp");
            return View();
        }

        [HttpPost]
        [Route("/adminlogin")]
        public IActionResult AdminLogin(string email, string password)
        {
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                logger.LogInformation($"Admin login of {email}");
                return View("AdminSetup");
                // return RedirectToAction("Index", "Items");
            }
            logger.LogError("Invalid admin login");
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

                logger.LogInformation($"Create Admin for {userName}");
                var result = adminService.CreateAdminUser(adminModelMapper.Map(adminModel));
                if (result)
                {
                    return View("AdminSetup");
                }
                logger.LogError($"Invalid admin user create {userName}");
                return BadRequest();
            }
            logger.LogError("Invalid admin user create");
            return BadRequest();
        }
    }
}