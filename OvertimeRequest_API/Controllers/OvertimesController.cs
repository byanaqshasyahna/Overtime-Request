using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using OvertimeRequest_API.Base;
using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;
using OvertimeRequest_API.Repository.Data;

namespace OvertimeRequest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OvertimesController : BaseController<Overtime, OvertimeRepository, int>
    {
        private readonly OvertimeRepository overtimeRepository;
        private readonly MyContext myContext;
        public IConfiguration configuration;
        public OvertimesController(OvertimeRepository repository, IConfiguration configuration, MyContext context) : base(repository)
        {
            overtimeRepository = repository;
            myContext = context;
            this.configuration = configuration;
        }
    }
}
