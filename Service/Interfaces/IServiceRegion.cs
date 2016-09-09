using PraticalTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalTest.Service.Interfaces
{
    public interface IServiceRegion
    {
        IEnumerable<Region> GetAll(Guid? cityId = null);
    }
}
