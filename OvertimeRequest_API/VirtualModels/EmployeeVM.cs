using OvertimeRequest_API.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OvertimeRequest_API.VirtualModels
{
    public class EmployeeVM
    {
        public string NIP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public int PaidOvertime { get; set; }
        public Gender Gender { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual ICollection<EmployeeOvertime> EmployeeOvertime { get; set; }


    }
}
