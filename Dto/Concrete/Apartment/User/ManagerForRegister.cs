using Core.Abstract;

namespace Dto.Concrete.User
{
    public class ManagerForRegister : IDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    } 
}

