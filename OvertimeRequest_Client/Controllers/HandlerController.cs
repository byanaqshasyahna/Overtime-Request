using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OvertimeRequest_API.VirtualModels;
using OvertimeRequest_Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest_Client.Controllers
{
    public class HandlerController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HandlerController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        public new IActionResult Unauthorized()
        {
            return View();
        }

        public IActionResult Notfound()
        {
            return View();
        }

    }
}

