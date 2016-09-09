using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PraticalTest.Domain;
using PraticalTest.Domain.Interfaces;
using PraticalTest.Service.Interfaces;

namespace PraticalTest.Service
{
    public class ServiceClient : IServiceClient
    {
        IRepositoryClient _repositoryClient;

        public ServiceClient(IRepositoryClient repositoryClient)
        {
            _repositoryClient = repositoryClient;
        }

        public IEnumerable<Client> GetAll(
            string name, 
            string gender,
            Guid? cityGUID,
            Guid? regionGUID, 
            DateTime? lastPurchaseFrom, 
            DateTime? lastPurchaseTo,
            Guid? classificationGUID, 
            Guid? sellerGUID)
        {
            try
            {
                IEnumerable<Client> listClient =
                    _repositoryClient.GetAll(
                    name, 
                    gender,
                    cityGUID, 
                    regionGUID,
                    lastPurchaseFrom, 
                    lastPurchaseTo,
                    classificationGUID, 
                    sellerGUID);

                return listClient;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }


    }
}
