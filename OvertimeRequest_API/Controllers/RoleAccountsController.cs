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
    public class RoleAccountsController : BaseController<RoleAccount, RoleAccountRepository, string>
    {
        private readonly RoleAccountRepository roleaccountRepository;
        private readonly MyContext myContext;
        public IConfiguration configuration;
        public RoleAccountsController(RoleAccountRepository repository, IConfiguration configuration, MyContext context) : base(repository)
        {
            roleaccountRepository = repository;
            myContext = context;
            this.configuration = configuration;
        }
    }
}
