﻿using Client.Repositories;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OvertimeRequest_API.Models;
using OvertimeRequest_API.VirtualModels;
using OvertimeRequest_Client.Base;
using OvertimeRequest_Client.VirtualModels;
using System;
using System.Net.Http;
using System.Text;

namespace OvertimeRequest_Client.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;

        public EmployeeRepository(Address address, string request = "Employees/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

       
    }
}
