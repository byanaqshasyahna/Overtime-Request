using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace OvertimeRequest_API.Models
{
    [Table("EmployeeOvertime")]
    public class EmployeeOvertime
    {
        public string NIP { get; set; }
        public int OvertimeId { get; set; }
       

        [JsonIgnore]
        public virtual Overtime Overtime { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }


    }
}
