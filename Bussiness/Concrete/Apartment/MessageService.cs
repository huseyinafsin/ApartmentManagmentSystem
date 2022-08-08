using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts.Apartment;
using Core.Repository;
using Core.Service.Abstract;
using Core.Service.Concretye;
using Core.Utilities.Results;
using DataAccess.Abstract.Apartment;
using Dto.Concrete.Apartment.Message;
using Entity.Concrete.MsSql;

namespace Bussiness.Concrete.Apartment
{
    public class MessageService :  Service<Message, int>, IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IService<UserMessage,int> _userMessageService;
        private readonly IMapper _mapper;
        public MessageService(IRepository<Message> repository, IMessageRepository messageRepository, IMapper mapper, IService<UserMessage, int> userMessageService) : base(repository)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _userMessageService = userMessageService;
        }

        public async Task<DataResult<List<Message>>> GetUserMessages(int id)
        {
           var result =await  _messageRepository.GetUserMessages(id);

           return result == null
               ? new ErrorDataResult<List<Message>>("Not found")
               : new SuccessDataResult<List<Message>>() { Data = result };

        }

        public async Task<IResult> CreateMessage(MessageCreateDto messageCreateDto)
        {

            var message = new Message()
            {
                MessageText = messageCreateDto.MessageText,
            };

            var userMessage = new UserMessage()
            {

                ReceiverId = messageCreateDto.FromUserId,
                SenderId = messageCreateDto.ToUserId,
                Message = message
            };

            await _userMessageService.AddAsync(userMessage);

            return new SuccessResult("Message sent");
        }

        public async Task<IResult> GetUserMessagesBetween(GetUserMessagesBetween between)
        {
            var result = await _messageRepository.GetUserMessagesBetween(between);

            return result == null
                ? new ErrorDataResult<List<Message>>("Not found")
                : new SuccessDataResult<List<Message>>() { Data = result };
        }
    }
}
