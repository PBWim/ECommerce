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
    }
}