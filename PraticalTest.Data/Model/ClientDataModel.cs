﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraticalTest.Data
{
    public class ClientDataModel
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime LastPurchase { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }
        public Guid SellerId { get; set; }
        public Guid? RegionId { get; set; }
        public Guid? ClassificationId { get; set; }

        public virtual UserDataModel Seller { get; set; }
        public virtual RegionDataModel Region { get; set; }
        public virtual ClassificationDataModel Classification { get; set; }
    }
}
