﻿using BantuLite.Models;
using BantuLite.Service;
using BantuLite.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace BantuLite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISecurityService securityService;

        public HomeController(ILogger<HomeController> logger, ISecurityService securityService)
        {
            _logger = logger;
            this.securityService = securityService;
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Bantu Lite";
            var branchDetails = ByteConvertHelper.Bytes2Object<SystemBranchDetails>(HttpContext.Session.Get("BRANCHDETAILS"));
            ViewData["Branch"] = branchDetails.Branch;
            ViewData["SystemDate"] = Convert.ToDateTime(branchDetails.SystemDate).ToLongDateString();           
            ViewData["Operator"] = branchDetails.Operator;
            ViewData["BankName"] = securityService.GetBankName();

            var menus = securityService.GetSystemMenusJson("12", "00", branchDetails.Operator);
            ViewData["SystemMenus"] = menus;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetClientsDataJson()
        {
            var systemBranchDetails = JsonConvert.DeserializeObject<SystemBranchDetails>((string)TempData["BranchDetails"]);

            var data = new
            {
                authorizeMenu = this.securityService.GetSystemMenusJson("12", "00", systemBranchDetails.Operator)
            };

            return Content(data.ToJson());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
