﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpyStore.Mvc.Models;
using Microsoft.Extensions.Configuration;
using SpyStore.Mvc.Controllers.Base;


namespace SpyStore.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : BaseController
    {

        public HomeController(IConfiguration configuration) : base(configuration)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
