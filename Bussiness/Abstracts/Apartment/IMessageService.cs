using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Service.Abstract;
using Core.Utilities.Results;
using Dto.Concrete.Apartment.Message;
using Entity.Concrete.MsSql;

namespace Bussiness.Abstracts.Apartment
{
    public interface IMessageService : IService<Message,int>
    {
        public Task<IDataResult<Message>> SendMessage(MessageCreateDto messageCreateDto);
        public Task<DataResult<List<Message>>> GetUserMessages(int id);
        public Task<IResult> CreateMessage(MessageCreateDto messageCreateDto);
        public Task<IResult> GetUserMessagesBetween(GetUserMessagesBetween between);
    }
}
