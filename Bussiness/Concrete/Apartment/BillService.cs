using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Abstracts.Apartment;
using Core.Repository;
using Core.Service.Concretye;
using Entity.Concrete.MsSql;

namespace Bussiness.Concrete.Apartment
{
    public class BillService : Service<Bill,int>, IBillService
    {
        public BillService(IRepository<Bill> repository) : base(repository)
        {
        }
    }
}
