using Client.Repositories;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OvertimeRequest_API.Models;
using OvertimeRequest_API.VirtualModels;
using OvertimeRequest_Client.Base;
using OvertimeRequest_Client.VirtualModels;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        public HttpStatusCode RequestOvertime(OvertimeRequestVM overtimeRequestVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(overtimeRequestVM), Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(request + "OvertimeRequest/", content).Result;

            return response.StatusCode;
        }

        public async Task<EmployeeVM> GetEmployeeByEmail(string email)
        {
            /// isi codingan kalian disini
            /// 
            EmployeeVM entities = new EmployeeVM();

            using (var response = await httpClient.GetAsync(request + "EmployeeByEmail/" + email))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<EmployeeVM>(apiResponse);
            }
            return entities;

        }
    }
}
