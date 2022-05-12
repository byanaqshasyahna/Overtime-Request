using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OvertimeRequest_API.Models
{
    [Table("Activity")]
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string Description { get; set; }
        

        [Required]
        public int OvertimeId { get; set; }

        [JsonIgnore]
        public virtual Overtime Overtime { get; set; }

    }
}
