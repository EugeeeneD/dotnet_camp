using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW15.Validators
{
    public class PhoneNumberValidator : IPhoneNumberValidator
    {
        public bool IsValid(string phone)
        {
            // acceptable pattern - "+380123364325"
            return Regex.Match(phone, @"^(\+[0-9]{12})$").Success;
        }
    }
}
