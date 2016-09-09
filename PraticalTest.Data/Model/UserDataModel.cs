using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraticalTest.Data
{
    public class UserDataModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }

        public ICollection<ClientDataModel> Clients { get; set; }
    }
}
