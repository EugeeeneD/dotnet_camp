using HW15.Data.Entities;
using HW15.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Controllers
{
    public class UserContoller
    {
        private readonly IEmailValidator _emailValidator;
        private readonly IPhoneNumberValidator _phoneNumberValidator;

        public UserContoller(IEmailValidator emailValidator, IPhoneNumberValidator phoneNumberValidator)
        {
            _emailValidator = emailValidator;
            _phoneNumberValidator = phoneNumberValidator;
        }

        public User CreateUser(string firstName, string secondName, string email, string phoneNumber)
        {
            User user = new User
            { 
                FirstName = firstName,
                LastName = secondName,
                Email = email,
                PhoneNumber = phoneNumber
            };
            if (!ValidateUser(user, out string message))
            {
                throw new ArgumentException("Incorrect input data.");
            }
            return user;
        }

        public bool ValidateUser(User user, out string message)
        {
            var firstName = user.FirstName.Length >= 3;
            if (!firstName)
            {
                message = "First name is invalid.";
                return false;
            }

            bool phoneNumber = _phoneNumberValidator.IsValid(user.PhoneNumber);
            if (!phoneNumber)
            {
                message = "Phone number is invalid.";
                return false;
            }

            var email = _emailValidator.IsValid(user.Email);
            if (!email)
            {
                message = "Email is invalid.";
                return false;
            }

            message = "Alright.";
            return true;
        }
    }
}
