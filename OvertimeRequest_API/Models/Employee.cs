using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OvertimeRequest_API.Models
{

    [Table("Employee")]
    public class Employee
    {
        [Key]
        public string NIP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }
        public DateTime BirthDate { get; set; }
        
        public Gender Gender { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual ICollection<EmployeeOvertime> EmployeeOvertime { get; set; }
    }
    public enum Gender
    {
        Female,
        Male
    }
}
