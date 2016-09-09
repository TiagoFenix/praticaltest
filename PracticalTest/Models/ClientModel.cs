using PraticalTest.Domain;
using PraticalTest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticalTest.Models
{
    public class ClientModel
    {
        public ClientModel()
        {
            this.parameters = new SearchParameters();
            this.clients = new List<ClientViewModel>();
        }

        public IEnumerable<ClientViewModel> clients { get; set; }

        public SearchParameters parameters { get; set; }

        public class SearchParameters
        {
            [DisplayName("Name")]
            public string Name { get; set; }

            [DisplayName("Gender")]
            public string Gender { get; set; }            

            [DisplayName("City")]
            public Guid? SelectedCityGUID { get; set; }            

            [DisplayName("Region")]
            public Guid? SelectedRegionGUID { get; set; }

            [DataType(DataType.Date)]
            [DisplayName("Last purchase")]
            public DateTime LastPurchaseFrom { get; set; }

            [DataType(DataType.Date)]
            public DateTime LastPurchaseTo { get; set; }

            [DisplayName("Classification")]
            public Guid? SelectedClassificationGUID { get; set; }           

            [DisplayName("Seller")]
            public Guid? SelectedSellerGUID { get; set; }

            public List<CityViewModel> Cities { get; set; }
            public List<RegionViewModel> Regions { get; set; }
            public List<SellerViewModel> Sellers { get; set; }
            public List<ClassificationViewModel> Classifications { get; set; }

            public bool Admin { get; set; }
        }

        public class ClientViewModel
        {
            public string Classification { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Gender { get; set; }
            public string City { get; set; }
            public string Region { get; set; }
            [DataType(DataType.Date)]
            public DateTime LastPurchase { get; set; }
            public string Seller { get; set; }
        }
    }
}