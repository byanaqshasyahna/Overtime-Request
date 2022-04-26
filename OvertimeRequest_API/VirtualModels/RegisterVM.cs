using System;

namespace OvertimeRequest_API.VirtualModels
{
    public class RegisterVM
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PaidOvertime { get; set; }
    }
}
