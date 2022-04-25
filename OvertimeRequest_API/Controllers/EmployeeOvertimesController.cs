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
    public class EmployeeOvertimesController : BaseController<EmployeeOvertime, EmployeeOvertimeRepository, string>
    {
        private readonly EmployeeOvertimeRepository employeeovertimeRepository;
        private readonly MyContext myContext;
        public IConfiguration configuration;
        public EmployeeOvertimesController(EmployeeOvertimeRepository repository, IConfiguration configuration, MyContext context) : base(repository)
        {
            employeeovertimeRepository = repository;
            myContext = context;
            this.configuration = configuration;
        }
    }
}
