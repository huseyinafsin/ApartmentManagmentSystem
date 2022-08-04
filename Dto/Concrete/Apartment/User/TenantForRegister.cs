using Core.Abstract;

namespace Dto.Concrete.User
{
    public class TenantForRegister : IDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public bool HasACar { get; set; }
        public string Plate { get; set; }
    }
}
