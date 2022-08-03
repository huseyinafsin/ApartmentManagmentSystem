using System.Threading.Tasks;
using Core.Repository;

namespace PaymentService.Repository.Abstract
{
    public interface IWeatherForecastDal : IRepository<WeatherForecast>
    {
        Task<WeatherForecast> GetByIdAsync(string id);
    }
}
