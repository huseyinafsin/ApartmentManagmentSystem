using Core.Entity.Concrete;

namespace Entity.Mongo
{
    public class Transaction : MongoDbEntity
    {
        public int CredditCardId { get; set; }
        public string PaymentDetails { get; set; }
        public int Amount { get; set; }
        public virtual CreditCards CreditCard { get; set; }

    }
}