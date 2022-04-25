using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OvertimeRequest_API.Models
{
    [Table("Role")]
    public class Role
    {
        [Key, Required]
        public int Id { get; set; }
        public string RoleName { get; set; }

        [JsonIgnore]
        public virtual ICollection<RoleAccount> RoleAccounts { get; set; }
    }
}