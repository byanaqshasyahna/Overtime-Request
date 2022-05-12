using System;
using System.Collections.Generic;

namespace OvertimeRequest_Client.VirtualModels
{
    public class OvertimeVM
    {
        
        public DateTime DateRequest { get; set; }
        public string Description { get; set; }
        public DateTime EndTime { get; set; }
        public string NIP { get; set; }
        public DateTime StartTime { get; set; }
        public List<OvertimeVM> Overtimes { get; set; }
        
        
        

    }
}
