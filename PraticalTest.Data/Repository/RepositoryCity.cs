using PraticalTest.Data.Context;
using PraticalTest.Domain;
using PraticalTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalTest.Data.Repository
{
    public class RepositoryCity : IRepositoryCity
    {
        public IEnumerable<City> GetAll()
        {
            PraticalTestDbContext context = new PraticalTestDbContext();

            var obj = (from t in context.Cities
                       select t);

            return obj.Select(a => new City()
            {
                CityId = a.CityId,
                CityName = a.CityName
            });
        }
    }
}
