using PraticalTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalTest.Service.Interfaces
{
    public interface IServiceClient
    {
        IEnumerable<Client> GetAll(
            string name,
            string gender,
            Guid? cityGUID,
            Guid? regionGUID,
            DateTime? lastPurchaseFrom,
            DateTime? lastPurchaseTo,
            Guid? classificationGUID,
            Guid? sellerGUID);
    }
}
