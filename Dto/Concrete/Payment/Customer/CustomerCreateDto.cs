using Core.Abstract;

namespace Dto.Concrete.Payment.Customer
{
    public class CustomerCreateDto : IDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

    }
}
