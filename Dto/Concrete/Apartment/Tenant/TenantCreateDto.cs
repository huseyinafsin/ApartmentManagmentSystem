using Core.Abstract;

namespace Dto.Concrete.Dtos.Tenant
{
    public class TenantCreateDto : IDto
    {
        public int UserId { get; set; }
        public int FlatId { get; set; }

        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public bool HasACar { get; set; }
        public string Plate { get; set; }
    }
}
