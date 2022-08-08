using Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Serilog;

namespace Bussiness.Configuration.Filters.Log
{
    public class MongoDbLogger
    {
        public ILogger LoggerManager;
        public LogType LogType;
        private readonly MongoDbSettings settings;


        public MongoDbLogger(IConfiguration configuration, IOptions<MongoDbSettings> options)
        {
            this.settings = options.Value;
            var mongoClient = new MongoClient(settings.ConnectionString).GetDatabase(settings.Database);

            if(LogType==LogType.Informational)
                LoggerManager = new LoggerConfiguration().WriteTo.MongoDB(mongoClient,collectionName:"log").CreateLogger();
            else
                LoggerManager = new LoggerConfiguration().WriteTo.MongoDB(mongoClient,collectionName:"errorLog").CreateLogger();
            
        }
    }
}
