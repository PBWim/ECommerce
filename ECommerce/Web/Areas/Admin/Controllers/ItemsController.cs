// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "ItemsController.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Web.Controllers;

    [Area("Admin")]
    public class ItemsController : BaseController
    {
        [Route("items")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("items/main")]
        public IActionResult Main()
        {
            return View();
        }

        [Route("items/sub")]
        public IActionResult Sub()
        {
            return View();
        }

        [Route("items/items")]
        public IActionResult Items()
        {
            return View();
        }
    }
}