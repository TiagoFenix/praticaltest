using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalTest.Domain
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime LastPurchase { get; set; }
        public Guid SellerId { get; set; }
        public Guid RegionId { get; set; }
        public Guid ClassificationId { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }

        public User Seller { get; set; }
        public Region Region { get; set; }
        public Classification Classification { get; set; }
    }
}
