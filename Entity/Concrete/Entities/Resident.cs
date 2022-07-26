﻿using Core.Abstract;
using Core.Entity.Concrete;
using System.Collections.Generic;

namespace Entity.Concrete
{
    public class Resident : BaseEntity, IEntity
    {
        public int UserId { get; set; }

        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public bool HasACar { get; set; }
        public string Plate { get; set; }

        public virtual User User { get; set; }
        public virtual IEnumerable<Bill> Bills { get; set; }

    }
}