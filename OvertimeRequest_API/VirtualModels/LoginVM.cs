using System.ComponentModel.DataAnnotations;

namespace OvertimeRequest_API.VirtualModels
{
    public class LoginVM
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
