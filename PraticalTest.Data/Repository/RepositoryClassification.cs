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
    public class RepositoryClassification : IRepositoryClassification
    {
        public IEnumerable<Classification> GetAll()
        {
            PraticalTestDbContext context = new PraticalTestDbContext();

            var obj = (from t in context.Classifications
                       select t);

            return obj.Select(a => new Classification()
            {
                ClassificationId = a.ClassificationId,
                ClassificationName = a.ClassificationName
            });
        }
    }
}
