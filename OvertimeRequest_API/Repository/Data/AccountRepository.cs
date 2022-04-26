using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;
using OvertimeRequest_API.VirtualModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace OvertimeRequest_API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext aContext;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            aContext = myContext;
        }

        public int Register(RegisterVM registerVM)
        {
            DateTime today = DateTime.Now;
            string increamentNIK;
            //Cek isi table kosong atau tidak
            if (aContext.Employees.ToList().Count != 0)
            {
                int increament = Convert.ToInt32(LastNIK()) + 1;
                increamentNIK = increament.ToString();
            }
            else
            {
                increamentNIK = today.Year.ToString() + "00" + 1;
            }

            //Cek Email yang sudah digunakan
            if (CekEmail(registerVM).Count > 0)
            {
                return 2;
            }
            else
            {
                var emp = new Employee
                {
                    NIP = increamentNIK,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    PhoneNumber = registerVM.Phone,
                    Gender = (Models.Gender)registerVM.Gender,
                    Salary = registerVM.Salary,
                    BirthDate = registerVM.BirthDate,
                    Email = registerVM.Email,

                };
                aContext.Employees.Add(emp);

                var passHasing = Hasing.HashPassword(registerVM.Password);

                var acc = new Account
                {
                    NIP = emp.NIP,
                    Password = passHasing,
                };
                aContext.Accounts.Add(acc);
                aContext.SaveChanges();

                var roleAccount = new RoleAccount
                {
                    NIP = emp.NIP,
                    RoleId = 5
                };
                aContext.RoleAccounts.Add(roleAccount);

                aContext.SaveChanges();
                SendEmail(registerVM.Email, registerVM.Password);
                return 1;
            }
        }
        public int Login(LoginVM loginVM)
        {
            var cekEmail = aContext.Employees.Where(e => e.Email == loginVM.Email).SingleOrDefault();

            if (cekEmail == null)
            {
                //email tidak ada (Akun tidak ada)
                return 0;
            }
            else
            {
                var getPassword = aContext.Accounts.Where(a => a.NIP == cekEmail.NIP).SingleOrDefault();
                var validate = Hasing.ValidatePassword(loginVM.Password, getPassword.Password);

                if ((cekEmail.Email == loginVM.Email) && (!validate))
                {
                    return 1;
                }
                return 2;
            }
        }

        public string LastNIK()
        {
            //mendapatkan NIK terakhir 
            return aContext.Employees.ToList().LastOrDefault().NIP;
        }

        public List<Employee> CekEmail(RegisterVM registerVM)
        {
            var result = aContext.Employees.Where(e => e.Email == registerVM.Email).ToList();
            return result;
        }

        public static void SendEmail(string email, string password)
        {
            //Sending Email
            string from = "sonbydude@gmail.com"; //From address
            string to = email;
            MailMessage message = new MailMessage(from, to);

            
            message.Subject = "Your Office Account";
            message.Body = "Your account password : " + password;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("sonbydude", "087885612712");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
                
            }

            catch (Exception ex)
            {
                throw ex;
                
            }
        }
    }
}
