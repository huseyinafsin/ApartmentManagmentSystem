using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repository;
using Dto.Concrete.Apartment.Message;
using Entity.Concrete.MsSql;

namespace DataAccess.Abstract.Apartment
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<List<Message>> GetUserMessages(int id);
        Task<List<Message>> GetUserMessagesBetween(GetUserMessagesBetween between);
    }
}
