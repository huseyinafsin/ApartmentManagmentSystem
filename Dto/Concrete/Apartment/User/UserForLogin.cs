using Core.Abstract;

namespace Dto.Concrete.User 
{
    public class UserForLogin : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
