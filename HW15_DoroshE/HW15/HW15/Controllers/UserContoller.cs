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

        public UserContoller(IEmailValidator emailValidator)
        {
            _emailValidator = emailValidator;
        }

        public User CreateUser(string firstName, string secondName, string email)
        {
            User user = new User
            { 
                FirstName = firstName,
                LastName = secondName,
                Email = email
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
            var email = _emailValidator.IsValid(user.Email);

            if (!firstName)
            {
                message = "First name is invalid.";
                return false;
            }

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
