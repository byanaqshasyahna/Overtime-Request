﻿using OvertimeRequest_API.Context;
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

        public IEnumerable RequestData()
        {
            var result = (from e in eContext.Employees
                          join eo in eContext.EmployeeOvertimes on e.NIP equals eo.NIP
                          join o in eContext.Overtimes on eo.OvertimeId equals o.Id
                          join a in eContext.Activities on o.Id equals a.OvertimeId
                          join ac in eContext.Accounts on e.NIP equals ac.NIP
                          where o.ManagerApprove == (Approval)0
                          orderby e.NIP
                          select new
                          {
                              NIP = e.NIP,
                              FullName = e.FirstName + " " + e.LastName,
                              Email = e.Email,
                              Phone = e.PhoneNumber,
                              Salary = e.Salary,
                              BirthDate = e.BirthDate,
                              PaidOvertime = e.PaidOvertime,
                              Gender = ((Gender)e.Gender).ToString(),
                              RoleName = eContext.Roles.Where(r => r.RoleAccounts.Any(ra => ra.NIP == e.NIP)).ToList()  
                          }).ToList();
            return result;
        }

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
