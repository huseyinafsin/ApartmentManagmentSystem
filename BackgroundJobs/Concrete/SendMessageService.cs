using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackgroundJobs.Abstract;
using Bussiness.Abstracts.Apartment;
using Core.Service.Abstract;
using Entity.Concrete.MsSql;

namespace BackgroundJobs.Concrete
{
    public class SendMessageService:ISendMessageService
    {
        private readonly IService<UserMessage,int> _userMessageService;
        private readonly IUserService _userService;

        public SendMessageService(IService<UserMessage, int> userMessageService, IUserService userService)
        {
            _userMessageService = userMessageService;
            _userService = userService;
        }


        public async Task SendMessage(int userId, string message)
        {
            var userMessage = new UserMessage()
            {
                ReceiverId = userId,
                SenderId = 3, // 1 is id of admin or system. Can be keept in configure file
                Message = new Message()
                {
                    MessageText = message
                },
            };
            _userMessageService.AddAsync(userMessage);
        }

        public async Task SendMessageToAll()
        {
            var userList = await _userService.GetAllAsync();

            foreach (var user in userList.Data)
            {
                var userMessage = new UserMessage()
                {
                    ReceiverId = user.Id,
                    SenderId = 3, // 1 is id of admin or system. Can be keept in configure file
                    Message = new Message()
                    {
                        MessageText = "Your bill is created"
                    },
                };
               await _userMessageService.AddAsync(userMessage);

            }

        }
    }
}
