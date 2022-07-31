using Core.Abstract;

namespace Entity.Concrete.Dtos.Resident
{
    public class ResidentModelDto : IDto
    {
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public bool HasACar { get; set; }
        public string Plate { get; set; }

    }
}