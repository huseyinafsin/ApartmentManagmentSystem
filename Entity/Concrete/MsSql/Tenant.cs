using Core.Abstract;
using Core.Entity.Concrete;
using System.Collections.Generic;

namespace Entity.Concrete.MsSql
{
    public class Tenant : BaseEntity
    {
        public int UserId { get; set; }
        public int FlatId { get; set; }

        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public bool HasACar { get; set; }
        public string Plate { get; set; }

        public virtual User User { get; set; }
        public virtual Flat Flat { get; set; }
        public virtual IEnumerable<Bill> Bills { get; set; }

    }
}
