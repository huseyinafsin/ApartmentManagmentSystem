using System.Collections.Generic;
using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete.MsSql
{
    public class Message : BaseEntity
    {
        public string MessageText { get; set; }

        public bool HasRead { get; set; } = false;

    }
}
