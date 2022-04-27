using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OvertimeRequest_Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest_Client.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Overtime()
        {
            return View();
        }
        public IActionResult ApprovalFinance()
        {
            return View();
        }

        public IActionResult ApprovalManager()
        {
            return View();
        }

        public IActionResult OvertimeList()
        {
            return View();
        }
    }
}
