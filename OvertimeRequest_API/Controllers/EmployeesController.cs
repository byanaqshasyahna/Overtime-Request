
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OvertimeRequest_API.Base;
using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;
using OvertimeRequest_API.Repository.Data;
using OvertimeRequest_API.VirtualModels;
using System.Collections.Generic;
using System.Net;

namespace OvertimeRequest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly MyContext myContext;
        public IConfiguration configuration;
        public EmployeesController(EmployeeRepository repository, IConfiguration configuration, MyContext context) : base(repository)
        {
            employeeRepository = repository;
            myContext = context;
            this.configuration = configuration;
        }

        [HttpPost("OvertimeRequest")]
        public ActionResult OvertimeRequest(List<OvertimeRequestVM> overtimeReqeustVM)
        {
            var result = 0;
            for(int i = 0; i< overtimeReqeustVM.Count; i++)
            {
                result = employeeRepository.OvertimeRequest(overtimeReqeustVM[i]);
            }
            
            if(result > overtimeReqeustVM.Count)
            {
                return StatusCode( 200, new {status = HttpStatusCode.OK, result, message = "sukses"} );
            }
                return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Gagal" });

        }

        [HttpGet("EmployeeByEmail/{Email}")]
        public ActionResult getByEmail(string Email)
        {
            var result = employeeRepository.getEmployeeByEmail(Email);
            return Ok(result);
        }

        [HttpGet("DataManager")]
        public ActionResult DataManager()
        {
            var result = employeeRepository.RequestData();
            return Ok(result);
        }

        [HttpGet("DataFinance")]
        public ActionResult DataFinance()
        {
            var result = employeeRepository.RequestDataFinance();
            return Ok(result);
        }

        [HttpGet("ActivityByOvertimeID/{overtimeId}")]
        public ActionResult ActivityList(int overtimeId)
        {
            var result = employeeRepository.getActivityList(overtimeId);

                return Ok(result);
        }

    }
}
