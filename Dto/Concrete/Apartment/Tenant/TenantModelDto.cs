using Core.Abstract;
using Entity.Concrete.MsSql;

namespace Dto.Concrete.Apartment.Tenant
{
    public class TenantModelDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FlatId { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string InitialPassword { get; set; } = "12345";

        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public bool HasACar { get; set; }
        public string Plate { get; set; }

    }
}