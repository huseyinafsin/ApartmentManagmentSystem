using Core.Entity.Concrete;
using Core.Models;

namespace Entity.Mongo
{
    public class CreditCards : MongoDbEntity
    {
        public int AccountId { get; set; }
        public string Number { get; set; }
        public double Debt { get; set; }
        public double Limit { get; set; }
        public int Mont { get; set; }
        public int Year { get; set; }
        public int Cvv { get; set; }

        public virtual Account Account { get; set; }
    }
}