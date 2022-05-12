namespace OvertimeRequest_Client.VirtualModels
{
    public class LoginResponseVM
    {
        public int status { get; set; }
        public string TokenJWT { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string NIP { get; set; }
        public string Salary { get; set; }
        public string fullName { get; set; }
    }
}
