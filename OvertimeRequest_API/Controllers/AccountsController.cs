using Castle.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using OvertimeRequest_API.Base;
using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;
using OvertimeRequest_API.Repository.Data;

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
    }
}
