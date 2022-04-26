using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OvertimeRequest_API.Base;
using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;
using OvertimeRequest_API.Repository.Data;

namespace OvertimeRequest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController<Role, RoleRepository, string>
    {
        private readonly RoleRepository roleRepository;
        private readonly MyContext myContext;
        public IConfiguration configuration;
        public RolesController(RoleRepository repository, IConfiguration configuration, MyContext context) : base(repository)
        {
            roleRepository = repository;
            myContext = context;
            this.configuration = configuration;
        }
    }
}
