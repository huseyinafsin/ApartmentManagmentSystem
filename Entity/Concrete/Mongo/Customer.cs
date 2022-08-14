using Core.Entity.Concrete;
using Core.Models;

namespace Entity.Mongo
{
    public class Customer : MongoDbEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string AccountId { get; set; }

    }
}