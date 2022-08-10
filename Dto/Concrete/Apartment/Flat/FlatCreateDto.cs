using Core.Abstract;

namespace Dto.Concrete.Apartment.Flat
{
    public class FlatCreateDto : IDto
    {
        public int FlatTypeId { get; set; }
        public double MonthlyPrice { get; set; }
        public string Block { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
    }
}