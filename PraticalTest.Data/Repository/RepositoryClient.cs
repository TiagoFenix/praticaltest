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
    public class RepositoryClient : IRepositoryClient
    {
        public IEnumerable<Client> GetAll(string Name, string Gender, Guid? SelectedCityGUID,
            Guid? SelectedRegionGUID, DateTime? LastPurchaseFrom, DateTime? LastPurchaseTo,
            Guid? SelectedClassificationGUID, Guid? SelectedSellerGUID)
        {
            PraticalTestDbContext context = new PraticalTestDbContext();

            var obj = (from t in context.Clients
                       select t);

            if (!string.IsNullOrEmpty(Name))
                obj = obj.Where(a => a.Name == Name);

            if (!string.IsNullOrEmpty(Gender))
                obj = obj.Where(a => a.Gender == Gender);

            if (SelectedRegionGUID.HasValue && SelectedRegionGUID.Value != Guid.Empty)
                obj = obj.Where(a => a.RegionId == SelectedRegionGUID);

            if (LastPurchaseFrom.HasValue && LastPurchaseFrom != DateTime.MinValue)
                obj = obj.Where(a => a.LastPurchase > LastPurchaseFrom);

            if (LastPurchaseTo.HasValue && LastPurchaseTo != DateTime.MinValue)
                obj = obj.Where(a => a.LastPurchase < LastPurchaseTo);

            if (SelectedClassificationGUID.HasValue && SelectedClassificationGUID.Value != Guid.Empty)
                obj = obj.Where(a => a.ClassificationId == SelectedClassificationGUID);

            if (SelectedSellerGUID.HasValue && SelectedSellerGUID.Value != Guid.Empty)
                obj = obj.Where(a => a.SellerId == SelectedSellerGUID);


            return obj.Select(a => new Client()
            {
                ClientId = a.ClientId,
                Name = a.Name,
                Phone = a.Phone,
                Gender = a.Gender,
                LastPurchase = a.LastPurchase,
                Seller = new User()
                {
                    UserId = a.Seller.UserId,
                    Name = a.Seller.Name
                },
                Region = new Region()
                {
                    RegionId = a.Region.RegionId,
                    RegionName = a.Region.RegionName,
                    CityId = a.Region.CityId,
                    City = new City()
                    {
                        CityId = a.Region.City.CityId,
                        CityName = a.Region.City.CityName
                    }
                },
                Classification = new Classification()
                {
                    ClassificationId = a.Classification.ClassificationId,
                    ClassificationName = a.Classification.ClassificationName
                },
                Address = a.Address,
                Occupation = a.Occupation
            });
        }
    }
}
