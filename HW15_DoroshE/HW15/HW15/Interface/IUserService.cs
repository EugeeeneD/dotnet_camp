using HW15.Data.Entities;
using System.Linq.Expressions;

namespace HW15.Interface
{
    public interface IUserService
    {
        void Add(User user);
        void Delete(User user);
        IQueryable<User> FindAll();
        IQueryable<User> FindWhere(Expression<Func<User, bool>> expression);
        bool IsValidEmail(string email);
        void Update(User user);
    }
}