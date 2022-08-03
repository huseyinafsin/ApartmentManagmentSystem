using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PaymentService.Models;
using PaymentService.Repository.Abstract;

namespace PaymentService.Repository.Concrete
{
    public class WeatherForecastMongoDbDal : MongoDbRepositoryBase<WeatherForecast>, IWeatherForecastDal
    {
        public WeatherForecastMongoDbDal(IOptions<MongoDbSettings> options) : base(options)
        {
        }

        public async Task<WeatherForecast> GetByIdAsync(string id)
        {
          return (WeatherForecast)await Collection.FindAsync<WeatherForecast>(id);
        }
    }
}
