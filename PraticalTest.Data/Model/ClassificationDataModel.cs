using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraticalTest.Data
{
    public class ClassificationDataModel
    {
        public Guid ClassificationId { get; set; }
        public string ClassificationName { get; set; }
        public virtual ICollection<ClientDataModel> Clients { get; set; }
    }
}
