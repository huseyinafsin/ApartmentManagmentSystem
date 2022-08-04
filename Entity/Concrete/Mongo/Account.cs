using System.Collections.Generic;
using Core.Entity.Concrete;

namespace Entity.Mongo
{
    public class Account : MongoDbEntity
    {
        public int Balance { get; set; }

        public IEnumerable<CreditCards> CreditCards { get; set; }
      
    }
}