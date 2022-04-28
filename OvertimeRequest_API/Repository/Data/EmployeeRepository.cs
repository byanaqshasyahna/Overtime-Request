using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;
using OvertimeRequest_API.VirtualModels;
using System;
using System.Collections;
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
            if (tabEmpOvt != null)
            {
                var tabOvt = eContext.Overtimes.Where(o => o.Id == tabEmpOvt.OvertimeId).SingleOrDefault();
                
                    if(tabOvt.OvertimeDate.Date == overtimeRequestVM.DateRequest.Date)
                    {
                        var act = new Activity
                        {
                            StartTime = overtimeRequestVM.StartTime,
                            FinishTime = overtimeRequestVM.EndTime,
                            Description = overtimeRequestVM.Description,
                            OvertimeId = tabOvt.Id
                        };
                        eContext.Activities.Add(act);
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

                    var dataIdOvertime = eContext.Overtimes.Where(o => o.OvertimeDate == overtimeRequestVM.DateRequest).ToList().LastOrDefault();
                    var ovtEmp = new EmployeeOvertime
                    {
                        NIP = overtimeRequestVM.NIP,
                        OvertimeId = dataIdOvertime.Id,

                    };
                    eContext.EmployeeOvertimes.Add(ovtEmp);
                    eContext.SaveChanges();

                    var act = new Activity
                    {
                        StartTime = overtimeRequestVM.StartTime,
                        FinishTime = overtimeRequestVM.EndTime,
                        Description = overtimeRequestVM.Description,
                        OvertimeId = dataIdOvertime.Id
                    };
                    eContext.Activities.Add(act);
                    
                }
                   
                    
                
                var result = eContext.SaveChanges();
                return result;
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

            var dataIdOvertime = eContext.Overtimes.Where(o => o.OvertimeDate == overtimeRequestVM.DateRequest).ToList().LastOrDefault();
            var ovtEmp = new EmployeeOvertime
            {
                NIP = overtimeRequestVM.NIP,
                OvertimeId = dataIdOvertime.Id,
                
            };
            eContext.EmployeeOvertimes.Add(ovtEmp);
            eContext.SaveChanges();

            var act = new Activity
            {
                StartTime = overtimeRequestVM.StartTime,
                FinishTime = overtimeRequestVM.EndTime,
                Description = overtimeRequestVM.Description,
                OvertimeId = dataIdOvertime.Id
            };
                eContext.Activities.Add(act);
                var result = eContext.SaveChanges();


                return result;
            }
            
        }

        /*public int ApproveManager(ApprovedVM approvedVM)
        {
            var ovtEmp = eContext.EmployeeOvertimes.Where(eo => eo.NIP == approvedVM.NIP).ToList();
            return 0;
        }*/

        public EmployeeVM getEmployeeByEmail(string Email)
        {
            var emp = eContext.Employees.Where(e => e.Email == Email).SingleOrDefault();

            EmployeeVM employeeVM = new EmployeeVM
            {
                NIP = emp.NIP,
                Email = emp.Email,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Gender = emp.Gender,
                Salary = emp.Salary,
                BirthDate = emp.BirthDate,
                PhoneNumber = emp.PhoneNumber
            };
            return employeeVM;
        }
    }
}
