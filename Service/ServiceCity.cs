using PraticalTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PraticalTest.Service.Interfaces;
using PraticalTest.Domain.Interfaces;

namespace PraticalTest.Service
{
    public class ServiceCity : IServiceCity
    {
        IRepositoryCity _repositoryCity;

        public ServiceCity(IRepositoryCity repositoryCity)
        {
            _repositoryCity = repositoryCity;
        }

        public IEnumerable<City> GetAll()
        {
            try
            {                
                IEnumerable<City> cityList = _repositoryCity.GetAll();
                return cityList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
