﻿using Castle.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using OvertimeRequest_API.Base;
using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;
using OvertimeRequest_API.Repository.Data;

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
    }
}