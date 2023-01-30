using HW15.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Validator
{
    public class EmailValidator : IEmailValidator
    {
        public bool IsValid(string email)
        {
            try
            {
                var i = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
