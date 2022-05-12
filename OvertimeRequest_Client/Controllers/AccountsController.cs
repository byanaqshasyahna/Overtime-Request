using Client.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OvertimeRequest_API.Models;
using OvertimeRequest_API.VirtualModels;
using OvertimeRequest_Client.Models;
using OvertimeRequest_Client.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest_Client.Controllers
{
    public class AccountsController : BaseController<Account, AccountRepository, string >
    {
        private readonly AccountRepository accountRepository;
        public AccountsController(AccountRepository repository) : base(repository)
        {
            accountRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(LoginVM loginVM)
        {
            var result = accountRepository.Login(loginVM);

            if (result.TokenJWT != null)
            {
                HttpContext.Session.SetString("JWToken", result.TokenJWT);
                HttpContext.Session.SetString("Email", result.Email);
                HttpContext.Session.SetString("NIP", result.NIP);
                HttpContext.Session.SetString("Salary", result.Salary);
               
                //HttpContext.Session.SetString("Name", jwtHandler.GetName(token));
                //HttpContext.Session.SetString("ProfilePicture", "assets/img/theme/user.png");
            }

            return Json(result);

        }

        [HttpPost]
        public JsonResult Register(RegisterVM registerVM)
        {
            var result = accountRepository.Register(registerVM);
            return Json(result);
        }
    }
}

