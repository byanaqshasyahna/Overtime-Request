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
        [Key]
        public int Id { get; set; }
        public DateTime OvertimeDate { get; set; }
        public DateTime CreateDate { get; set; }
        public Approval FinanceApprove {get; set;}
        public Approval ManagerApprove { get; set; }

        [JsonIgnore]
        public virtual ICollection<EmployeeOvertime> EmployeeOvertime { get; set; }

        [JsonIgnore]
        public virtual ICollection<Activity> Activities { get; set; }


    }
    public enum Approval
    {
        Declined,
        Approved,
        DeclinedManagerAndFinance
    }
}
