using Core.Entity.Concrete;
using Core.Models;

namespace Entity.Mongo
{
    public class Transaction : MongoDbEntity
    {
        public string CredditCardId { get; set; }
        public string PaymentDetails { get; set; }
        public double Amount { get; set; }

    }
}