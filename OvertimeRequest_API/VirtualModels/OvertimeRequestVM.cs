using System;

namespace OvertimeRequest_API.VirtualModels
{
    public class OvertimeRequestVM
    {
        
        public DateTime DateRequest { get; set; }
        public string Description { get; set; }
        public DateTime EndTime { get; set; }
        public string NIP { get; set; }
        public DateTime StartTime { get; set; }
        
        
        

    }
}
