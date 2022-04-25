using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace OvertimeRequest_API.Models
{
    [Table("EmployeeOvertime")]
    public class EmployeeOvertime
    {
        public int NIP { get; set; }
        public int OvertimeId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public string Describe { get; set; }

        [JsonIgnore]
        public virtual Overtime Overtime { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }


    }
}
