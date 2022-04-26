using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OvertimeRequest_API.Models
{
	[Table("Account")]
	public class Account
    {
		[Key, Required]
		public string NIP { get; set; }

		[Required]
		public string Password { get; set; }

		public int OTP { get; set; }
		public DateTime ExpiredOTP { get; set; }

		public Boolean IsUsed { get; set; }

		[JsonIgnore]
		public virtual ICollection<RoleAccount> RoleAccounts { get; set; }

		[JsonIgnore]
		public virtual Employee Employee { get; set; }

		
	}
}