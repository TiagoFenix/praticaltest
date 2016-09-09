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
    public class ServiceClassification : IServiceClassification
    {
        IRepositoryClassification _repositoryClassification;

        public ServiceClassification(IRepositoryClassification repositoryClassification)
        {
            _repositoryClassification = repositoryClassification;
        }

        public IEnumerable<Classification> GetAll()
        {
            try
            {
                IEnumerable<Classification> classList = _repositoryClassification.GetAll();

                return classList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
