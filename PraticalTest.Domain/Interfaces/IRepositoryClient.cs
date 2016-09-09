using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalTest.Domain.Interfaces
{
    public interface IRepositoryClient
    {
        IEnumerable<Client> GetAll(string name, string gender, Guid? selectedCityGUID, Guid? selectedRegionGUID,
            DateTime? lastPurchaseFrom, DateTime? lastPurchaseTo, Guid? selectedClassificationGUID,
            Guid? selectedSellerGUID);
    }
}
