using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;
using OvertimeRequest_API.VirtualModels;
using System;
using System.Linq;

namespace OvertimeRequest_API.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>
    {
        private readonly MyContext eContext;
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            eContext = myContext;   
        }

        public int OvertimeRequest(OvertimeRequestVM overtimeRequestVM)
        {
            var date = DateTime.Now;
            var tabEmpOvt = eContext.EmployeeOvertimes.Where(eo => eo.NIP == overtimeRequestVM.NIP).ToList().LastOrDefault() ;
            /*if(tabEmpOvt != null)
            {
                var tabOvt = eContext.Overtimes.Where(o => o.Id == tabEmpOvt.OvertimeId).SingleOrDefault();
                *//*if (tabOvt == null)
                {
                    var ovt = new Overtime
                    {
                        CreateDate = date,
                        OvertimeDate = overtimeRequestVM.DateRequest
                    };
                    eContext.Overtimes.Add(ovt);
                    eContext.SaveChanges();
                }*//*
                if(tabOvt.OvertimeDate.Date == overtimeRequestVM.DateRequest.Date)
                {
                    var ovtEmp = new EmployeeOvertime
                    {
                        NIP = overtimeRequestVM.NIP,
                        OvertimeId = tabOvt.Id,
                        Start = overtimeRequestVM.StartTime,
                        Finish = overtimeRequestVM.EndTime,
                        Describe = overtimeRequestVM.Description
                    };
                    eContext.EmployeeOvertimes.Add(ovtEmp);
                }
                else
                {
                    var ovt = new Overtime
                    {
                        CreateDate = date,
                        OvertimeDate = overtimeRequestVM.DateRequest
                    };
                    eContext.Overtimes.Add(ovt);
                    eContext.SaveChanges();
                    var dataIdOvertime = eContext.Overtimes.Where(o => o.OvertimeDate == overtimeRequestVM.DateRequest).ToList().LastOrDefault() ;
                    var ovtEmp = new EmployeeOvertime
                    {
                        NIP = overtimeRequestVM.NIP,
                        OvertimeId = dataIdOvertime.Id,
                        Start = overtimeRequestVM.StartTime,
                        Finish = overtimeRequestVM.EndTime,
                        Describe = overtimeRequestVM.Description
                    };
                    eContext.EmployeeOvertimes.Add(ovtEmp);
                }
                
                var result = eContext.SaveChanges();

                return result;
            }*/
            /*else
            {*/
                var ovt = new Overtime
                {
                    CreateDate = date,
                    OvertimeDate = overtimeRequestVM.DateRequest
                };
                eContext.Overtimes.Add(ovt);
                eContext.SaveChanges();
                var dataIdOvertime = eContext.Overtimes.Where(o => o.OvertimeDate == overtimeRequestVM.DateRequest).ToList().LastOrDefault();
                var ovtEmp = new EmployeeOvertime
            {
                NIP = overtimeRequestVM.NIP,
                OvertimeId = dataIdOvertime.Id,
                Start = overtimeRequestVM.StartTime,
                Finish = overtimeRequestVM.EndTime,
                Describe = overtimeRequestVM.Description
            };
            eContext.EmployeeOvertimes.Add(ovtEmp);
            var result = eContext.SaveChanges();

                return result;
            //}
            

            

            
            
            

            
        }

        public int EmployeeRequest(OvertimeRequestVM overtimeRequestVM)
        {
            
            return 0;
        }
    }
}
