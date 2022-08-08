using Core.Abstract;

namespace Dto.Concrete.Apartment.Message
{
    public class GetUserMessagesBetween : IDto
    {
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }

    }
}