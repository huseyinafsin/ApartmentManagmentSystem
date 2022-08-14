using System.Collections.Generic;
using Core.Entity.Concrete;
using Core.Models;

namespace Entity.Mongo
{
    public class Account : MongoDbEntity
    {
        public int Balance { get; set; }

      
    }
}