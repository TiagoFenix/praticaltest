using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PraticalTest.Domain;
using PraticalTest.Domain.Interfaces;
using PraticalTest.Data.Context;

namespace PraticalTest.Data.Repository
{
    public class RepositoryUser : IRepositoryUser
    {
        public User Authenticate(string userEmail)
        {
            PraticalTestDbContext context = new PraticalTestDbContext();

            var obj = (from t in context.Users
                       where t.Email == userEmail
                       select t).FirstOrDefault();

            User user = new User();
            if (obj != null)
            {
                user.UserId = obj.UserId;
                user.Name = obj.Name;
                user.Password = obj.Password;
                user.Email = obj.Email;
                user.IsAdmin = obj.IsAdmin ?? false;
            }

            return user;
        }

        public IEnumerable<User> GetAll(bool isAdmin)
        {
            PraticalTestDbContext context = new PraticalTestDbContext();

            var obj = (from t in context.Users
                       where t.IsAdmin == isAdmin
                       select t);

            return obj.Select(a => new User()
            {
                UserId = a.UserId,
                Name = a.Name
            });
        }
    }
}
