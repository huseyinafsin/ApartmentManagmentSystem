using Core.Entity.Concrete;

namespace Entity.Mongo
{
    public class Customer : MongoDbEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

    }
}