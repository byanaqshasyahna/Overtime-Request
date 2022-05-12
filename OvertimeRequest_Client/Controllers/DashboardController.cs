using Microsoft.AspNetCore.Authorization;
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
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Admin, Employee, Manager, Finance")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult RequestOvertime()
        {
            return View();
        }

        [Authorize(Roles = "Finance")]
        public IActionResult ApprovalFinance()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        public IActionResult ApprovalManager()
        {
            return View();
        }

        public IActionResult OvertimeList()
        {
            return View();
        }

        public ActionResult AddMorePartialView()
        {
            //this  action page is support cal the partial page.
            //We will call this action by view page.This Action is return partial page
            OvertimeRequestVM model = new OvertimeRequestVM();
            return PartialView("AddMorePartialView", model);
            //^this is actual partical page we have 
            //create on this page in Home Controller as given below image
        }

        public ActionResult PostAddMoreActivity(OvertimeRequestVM overtimeRequestVM)
        {
            //Here,Post addmore value from view page and get multiple values from view page
            
            return View();
        }

    }
}
