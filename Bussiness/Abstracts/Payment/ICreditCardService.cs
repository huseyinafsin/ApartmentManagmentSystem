using System.Threading.Tasks;
using Core.Service.Abstract;
using Core.Utilities.Results;
using Dto.Concrete.CreditCard;
using Entity.Mongo;

namespace Bussiness.Abstracts.Payment
{
    public interface ICreditCardService : IService<CreditCard,string>
    {
        Task<IDataResult<CreditCardModelDto>> GetCardWithDetails(string cardId);
    }
}
