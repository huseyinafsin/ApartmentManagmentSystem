using Core.Abstract;

namespace Dto.Concrete.Apartment.Message
{
    public class MessageCreateDto :IDto
    {
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public string MessageText { get; set; }

    }
}