using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PraticalTest.Domain;
using PraticalTest.Service.Interfaces;
using PraticalTest.Domain.Interfaces;

namespace PraticalTest.Service
{
    public class ServiceRegion : IServiceRegion
    {
        IRepositoryRegion _repositoryRegion;

        public ServiceRegion(IRepositoryRegion repositoryRegion)
        {
            _repositoryRegion = repositoryRegion;
        }

        public IEnumerable<Region> GetAll(Guid? cityId = default(Guid?))
        {
            try
            {
                IEnumerable<Region> regionList = _repositoryRegion.GetAll(cityId);

                return regionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
