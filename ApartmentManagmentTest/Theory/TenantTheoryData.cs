using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto.Concrete.Dtos.Tenant;
using Dto.Concrete.User;
using Xunit;

namespace ApartmentManagmentTest.Theory
{
    public class TenantTheoryData : TheoryData<TenantForRegister>
    {
        public TenantTheoryData()
        {
            Add(new TenantForRegister()
            {
                IdentityNumber = "16515525",
                Email = "huseyinafssin@mail.com",
                Firstname = "Hüseyin",
                Lastname = "Afşin",
                FlatId = 1,
                HasACar = true,
                Phone = "665655356",
                Plate = "365456464",

            });
        }
    }
}
