using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalTest.Domain.Interfaces
{
    public interface IRepositoryClassification
    {
        IEnumerable<Classification> GetAll();
    }
}
