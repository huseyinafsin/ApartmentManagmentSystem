using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract
{
    public interface IEntity
    {
    }

    public interface IEntity<out TKey> : IEntity
    {
        public TKey Id { get; }
        DateTime CreatedAt { get; set; }
    }
}
