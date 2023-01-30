using HW15.Data;
using HW15.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using HW15.Validator;

namespace HW15.Services
{
    public class UserService : ContextBase
    {
        public UserService()
        {
            _context = new CinemaDBContext();
        }

        public UserService(CinemaDBContext context) : base(context)
        {
        }

        public IQueryable<User> FindAll()
        {
            return base.FindAll<User>();
        }

        public IQueryable<User> FindWhere(Expression<Func<User, bool>> expression)
        {
            return base.FindWhere<User>(expression);
        }

        public void Add(User user)
        {
            var emailValidator = new EmailValidator();
            if (emailValidator.IsValid(user.Email)) { base.Add<User>(user); }
            else { throw new ArgumentException("Invalid email address."); }
        }

        public void Update(User user)
        {
            var emailValidator = new EmailValidator();
            if (emailValidator.IsValid(user.Email)) { base.Update<User>(user); }
            else { throw new ArgumentException("Invalid email address."); }
        }

        public void Delete(User user)
        {
            base.Delete<User>(user);
        }
    }
}
