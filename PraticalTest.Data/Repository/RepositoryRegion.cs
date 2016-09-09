using PraticalTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PraticalTest.Domain;
using PraticalTest.Data.Context;

namespace PraticalTest.Data.Repository
{
    public class RepositoryRegion : IRepositoryRegion
    {
        public IEnumerable<Region> GetAll(Guid? cityId = default(Guid?))
        {
            PraticalTestDbContext context = new PraticalTestDbContext();

            var obj = (from t in context.Regions
                       where cityId.HasValue ? t.CityId == cityId.Value : 1 == 1
                       select t);

            return obj.Select(a => new Region()
            {
                RegionId = a.RegionId,
                RegionName = a.RegionName,
                City = new City() { CityId = a.City.CityId, CityName = a.City.CityName }
            });
        }
    }
}
