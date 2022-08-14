using Core.Entity.Concrete;
using Core.Models;

namespace Entity.Mongo
{
    public class CreditCard : MongoDbEntity
    {
        public string AccountId { get; set; }
        public string Number { get; set; }
        public double Debt { get; set; }
        public double Limit { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Cvv { get; set; }

    }
}