using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.Apartment;
using DataAccess.Concrete.Apartment;
using DataAccess.Contexts;
using Dto.Concrete.Apartment.Message;
using Entity.Concrete.MsSql;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Apartment
{
    public class MessageRepository : EfGenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(ApartmentContext context) : base(context)
        {
        }

        public async Task<List<Message>> GetUserMessages(int id)
        {
            return await (from m in _context.Messages
                          join um in _context.UserMessages
                              on m.Id equals um.MessageId
                          where um.ReceiverId == id
                          select m).ToListAsync();

        }

        public async Task<List<Message>> GetUserMessagesBetween(GetUserMessagesBetween between)
        {
            return await (from m in _context.Messages
                         join um in _context.UserMessages
                             on m.Id equals um.MessageId
                         where um.ReceiverId == between.ToUserId && um.SenderId == between.FromUserId
                         select m).ToListAsync();
        }
    }

}