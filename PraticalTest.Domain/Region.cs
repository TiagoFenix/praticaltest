using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalTest.Domain
{
    public class Region
    {
        public Guid RegionId { get; set; }
        public string RegionName { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}
