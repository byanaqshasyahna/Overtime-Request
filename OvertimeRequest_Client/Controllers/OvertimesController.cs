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
    public class OvertimesController : BaseController<Overtime, OvertimeRepository, int >
    {
        private readonly OvertimeRepository overtimeRepository;
        public OvertimesController(OvertimeRepository repository) : base(repository)
        {
            overtimeRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}

