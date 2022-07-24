using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.Concrete
{
    public class OperationClaim : BaseEntity, IEntity
    {
        public string Name { get; set; }
    }
}
