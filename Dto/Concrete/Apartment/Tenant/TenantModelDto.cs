using Core.Abstract;

namespace Dto.Concrete.Dtos.Tenant
{
    public class TenantModelDto : IDto
    {
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public bool HasACar { get; set; }
        public string Plate { get; set; }

    }
}