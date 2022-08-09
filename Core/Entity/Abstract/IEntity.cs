using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract
{
    public interface IEntity<out TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; }
        public bool Status { get; set; } 

    }
}
