using PracticalTest.Models;
using PraticalTest.Domain;
using PraticalTest.Service.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace PracticalTest.Controllers
{
    public class ClientController : Controller
    {
        IServiceClient _serviceClient;
        IServiceUser _serviceUser;

        IServiceCity _serviceCity;
        IServiceRegion _serviceRegion;
        IServiceClassification _serviceClassification;

        public ClientController(
            IServiceClient serviceClient,
            IServiceUser serviceUser,
            IServiceCity serviceCity,
            IServiceRegion serviceRegion,
            IServiceClassification serviceClassification
            )
        {
            _serviceClient = serviceClient;
            _serviceUser = serviceUser;

            _serviceCity = serviceCity;
            _serviceRegion = serviceRegion;
            _serviceClassification = serviceClassification;
        }

        // GET: Client
        public ActionResult Index()
        {
            ClientModel model = new ClientModel();
            LoadData(model, true);
            model.parameters.Admin = CurrentUserIsAdmin();
            return View(model);
        }

        // POST: Client
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            ClientModel model = new ClientModel();

            model.parameters.Admin = CurrentUserIsAdmin();

            if (!model.parameters.Admin)
            {
                model.parameters.SelectedSellerGUID = new Guid(CurrentUserId());
            }

            if (form["SelectedCityGUID"].ToString() != string.Empty)
            {
                model.parameters.SelectedCityGUID = new Guid(form["SelectedCityGUID"].ToString());
            }

            if (form["SelectedRegionGUID"].ToString() != string.Empty)
            {
                model.parameters.SelectedRegionGUID = new Guid(form["SelectedRegionGUID"].ToString());
            }

            if (form["SelectedClassificationGUID"].ToString() != string.Empty)
            {
                model.parameters.SelectedClassificationGUID = new Guid(form["SelectedClassificationGUID"].ToString());
            }

            if (!CurrentUserIsAdmin())
            {
                model.parameters.SelectedSellerGUID = new Guid(CurrentUserId());
            }
            else if (form["SelectedSellerGUID"].ToString() != string.Empty)
            {
                model.parameters.SelectedSellerGUID = new Guid(form["SelectedSellerGUID"].ToString());
            }

            if (form["parameters.LastPurchaseFrom"].ToString() != string.Empty)
            {
                model.parameters.LastPurchaseFrom = Convert.ToDateTime(form["parameters.LastPurchaseFrom"].ToString());
            }

            if (form["parameters.LastPurchaseTo"].ToString() != string.Empty)
            {
                model.parameters.LastPurchaseTo = Convert.ToDateTime(form["parameters.LastPurchaseTo"].ToString());
            }

            model.parameters.Gender = form["parameters.Gender"].ToString() != string.Empty ? form["parameters.Gender"].ToString() : string.Empty;
            model.parameters.Name = form["parameters.Name"].ToString() != string.Empty ? form["parameters.Name"].ToString() : string.Empty;

            IEnumerable<Client> clientList = _serviceClient.GetAll(
                model.parameters.Name
                , model.parameters.Gender
                , model.parameters.SelectedCityGUID
                , model.parameters.SelectedRegionGUID
                , model.parameters.LastPurchaseFrom
                , model.parameters.LastPurchaseTo
                , model.parameters.SelectedClassificationGUID
                , model.parameters.SelectedSellerGUID
                );

            model.clients = clientList.Select(a => new PracticalTest.Models.ClientModel.ClientViewModel()
            {
                Name = a.Name
                ,
                Phone = a.Phone
                ,
                Gender = a.Gender
                ,
                LastPurchase = a.LastPurchase
                ,
                Seller = a.Seller.Name
                ,
                Region = a.Region.RegionName
                ,
                Classification = a.Classification.ClassificationName
                ,
                City = a.Region.City.CityName
            }).ToList();

            LoadData(model, false);
            return View(model);
        }

        private void LoadData(ClientModel model, bool getall)
        {
            //Getting drop down data
            IEnumerable<City> cities = _serviceCity.GetAll();
            IEnumerable<Region> regions = _serviceRegion.GetAll();
            IEnumerable<Classification> classifications = _serviceClassification.GetAll();
            IEnumerable<User> sellers = _serviceUser.GetAll(false);
            IEnumerable<Client> clients = new List<Client>();

            if (getall)
            {

                Guid? SelectedSellerGUID = null;
                if (!CurrentUserIsAdmin())
                {
                    SelectedSellerGUID = new Guid(CurrentUserId());
                }

                clients = _serviceClient.GetAll("", "", null, null, null, null, null, SelectedSellerGUID);
                model.clients = clients.Select(a => new PracticalTest.Models.ClientModel.ClientViewModel()
                {
                    Name = a.Name
                    ,
                    Phone = a.Phone
                    ,
                    Gender = a.Gender
                    ,
                    LastPurchase = a.LastPurchase
                    ,
                    Seller = a.Seller.Name
                    ,
                    Region = a.Region.RegionName
                    ,
                    Classification = a.Classification.ClassificationName
                    ,
                    City = a.Region.City.CityName
                }).ToList();

            }
            model.parameters.Cities = cities.Select(a => new CityViewModel()
            {
                CityId = a.CityId,
                CityName = a.CityName
            }).ToList();

            model.parameters.Regions = regions.Select(a => new RegionViewModel()
            {
                RegionId = a.RegionId,
                RegionName = a.RegionName
            }).ToList();

            model.parameters.Classifications = classifications.Select(a => new ClassificationViewModel()
            {
                ClassificationId = a.ClassificationId,
                ClassificationName = a.ClassificationName
            }).ToList();

            model.parameters.Sellers = sellers.Select(a => new SellerViewModel()
            {
                UserId = a.UserId,
                Name = a.Name
            }).ToList();


        }

        private bool CurrentUserIsAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;

            foreach (Claim claim in claims)
            {
                if (claim.Type == ClaimTypes.Role && claim.Value == "Admin")
                {
                    return true;
                }
            }

            return false;
        }
        private string CurrentUserEmail()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;

            foreach (Claim claim in claims)
            {
                if (claim.Type == ClaimTypes.Email)
                {
                    return claim.Value;
                }
            }

            return string.Empty;
        }
        private string CurrentUserId()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;

            foreach (Claim claim in claims)
            {
                if (claim.Type == ClaimTypes.NameIdentifier)
                {
                    return claim.Value;
                }
            }

            return string.Empty;
        }
    }
}