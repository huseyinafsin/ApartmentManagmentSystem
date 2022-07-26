﻿using Core.Abstract;

namespace Dto.Concrete.Dtos.Tenant
{
    public class TenantUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string InitialPassword { get; set; }

        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public bool HasACar { get; set; }
        public string Plate { get; set; }
    }
}
