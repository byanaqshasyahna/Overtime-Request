using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;


namespace OvertimeRequest_API.Models
{
    [Table("RoleAccount")]
    public class RoleAccount
    {
        public string NIP { get; set; }
        public int RoleId { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }

        [JsonIgnore]
        public virtual Role Role { get; set; }
    }
}