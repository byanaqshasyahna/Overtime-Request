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

namespace OvertimeRequest_Client.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account, string>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;

        public AccountRepository(Address address, string request = "Accounts/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public LoginResponseVM Login(LoginVM loginVM)
        {
            LoginResponseVM result;
            StringContent content = new StringContent(JsonConvert.SerializeObject(loginVM), Encoding.UTF8, "application/json");

            using (var response = httpClient.PostAsync(request + "Login", content).Result)
            {
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<LoginResponseVM>(apiResponse);
            }

            return result;
        }

        public HttpStatusCode Register(RegisterVM registerVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(request + "Register/", content).Result;

            return response.StatusCode;
        }
    }
}
