using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Dto.Concrete.Apartment.Message;
using Entity.Concrete.MsSql;

namespace Bussiness.Abstracts.Apartment
{
    public interface IMessageService
    {
        public Task<IDataResult<Message>> SendMessage(MessageCreateDto messageCreateDto);
    }
}
