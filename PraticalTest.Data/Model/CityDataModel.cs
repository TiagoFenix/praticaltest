using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraticalTest.Data
{
    public class CityDataModel
    {
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public virtual ICollection<RegionDataModel> Regions { get; set; }
    }
}
