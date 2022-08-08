using Core.Abstract;

namespace Dto.Concrete.User
{
    public class UserModel : IDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}