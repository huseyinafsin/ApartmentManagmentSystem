using Core.Abstract;

namespace Entity.Concrete
{
    public class Resident : User
    {
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public bool HasACar { get; set; }
        public string Plate { get; set; }
    }  
}
