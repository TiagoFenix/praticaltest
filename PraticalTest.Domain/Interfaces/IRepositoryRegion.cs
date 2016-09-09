using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalTest.Domain.Interfaces
{
    public interface IRepositoryRegion
    {
        IEnumerable<Region> GetAll(Guid? cityId = null);
    }
}
