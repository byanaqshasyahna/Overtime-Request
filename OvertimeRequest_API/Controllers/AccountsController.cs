﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OvertimeRequest_API.Base;
using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;
using OvertimeRequest_API.Repository.Data;
using OvertimeRequest_API.VirtualModels;

namespace OvertimeRequest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        private readonly MyContext myContext;
        public IConfiguration configuration;
        public AccountsController(AccountRepository repository, IConfiguration configuration, MyContext context) : base(repository)
        {
            accountRepository = repository;
            myContext = context;
            this.configuration = configuration;
        }

        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            var result = accountRepository.Register(registerVM);

            if (result == 2)
            {
                return BadRequest("Email Sudah Digunakan");
            }
            else
            {
                return Ok("Registerasi berhasil");
            }
            /*if (result == 2)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }*/
            /*return Ok(result);*/

        }
    }
}
