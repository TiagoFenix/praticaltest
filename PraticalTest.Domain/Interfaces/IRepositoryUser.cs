using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalTest.Domain.Interfaces
{
    public interface IRepositoryUser
    {
        User Authenticate(string userEmail);
        IEnumerable<User> GetAll(bool admin);
    }
}
