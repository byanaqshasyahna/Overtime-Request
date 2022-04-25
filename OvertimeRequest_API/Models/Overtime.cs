using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OvertimeRequest_API.Models
{
    [Table("Overtime")]
    public class Overtime
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Create_date { get; set; }
        public Approval Approve_Finance {get; set;}
        public Approval Approve_Manager { get; set; }

        [JsonIgnore]
        public virtual ICollection<EmployeeOvertime> EmployeeOvertime { get; set; }


    }
    public enum Approval
    {
        Declined,
        Approved
    }
}
