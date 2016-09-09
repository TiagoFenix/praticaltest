using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraticalTest.Data
{
    public class RegionDataModel
    {
        public Guid RegionId { get; set; }
        public string RegionName { get; set; }
        public Guid CityId { get; set; }

        public virtual CityDataModel City { get; set; }

        public virtual ICollection<ClientDataModel> Clients { get; set; }    
    }
}
