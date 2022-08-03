using System.Threading.Tasks;
using Core.Repository;

namespace PaymentService.Repository.Abstract
{
    public interface IWeatherForecastDal : IMongoDbRepository<WeatherForecast>
    {
        Task<WeatherForecast> GetByIdAsync(string id);
    }
}
