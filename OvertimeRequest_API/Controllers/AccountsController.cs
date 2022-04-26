using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OvertimeRequest_API.Base;
using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;
using OvertimeRequest_API.Repository.Data;
using OvertimeRequest_API.VirtualModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;

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

        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginvm)
        {
            var result = accountRepository.Login(loginvm);


            if (result == 2)
            {
                var dataEmp = myContext.Employees.Where(emp => emp.Email == loginvm.Email).SingleOrDefault();
                var NIP = dataEmp.NIP;
                var cekRole = getRole(NIP);


                var claims = new List<Claim>();
                claims.Add(new Claim("Email", loginvm.Email));

                foreach (var item in cekRole)
                {
                    claims.Add(new Claim("roles", item));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    configuration["Jwt:Issuer"],
                    configuration["Jwr:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn
                    );
                var idToken = new JwtSecurityTokenHandler().WriteToken(token);
                claims.Add(new Claim("TokenSecurity", idToken.ToString()));

                return Ok(new { status = HttpStatusCode.OK, TokenJWT = idToken, message = "Login Success" });

            }
            else if (result == 0)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Akun Tidak Ada" });
            }
            else
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Password Salah" });

        }
        public List<string> getRole(string NIP)
        {
            var result = (from a in myContext.Roles
                          join c in myContext.RoleAccounts on a.Id equals c.RoleId
                          where c.NIP == NIP
                          select a.RoleName).ToList();


            return result;
        }
    }
}
