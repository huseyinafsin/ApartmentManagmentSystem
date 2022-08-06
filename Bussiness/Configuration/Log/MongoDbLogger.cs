using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Serilog;

namespace Bussiness.Configuration.Log
{
    public class MongoDbLogger
    {
        public ILogger LoggerManager;
        private readonly MongoDbSettings settings;


        public MongoDbLogger(IConfiguration configuration, IOptions<MongoDbSettings> options)
        {
            this.settings = options.Value;
            var mongoClient = new MongoClient(settings.ConnectionString).GetDatabase(settings.Database);

            LoggerManager = new LoggerConfiguration().WriteTo.MongoDB(mongoClient,collectionName:"log").CreateLogger();


        }
    }
}
