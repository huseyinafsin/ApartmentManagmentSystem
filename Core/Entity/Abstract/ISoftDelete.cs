using System;

namespace Core.Abstract
{
    public interface ISoftDelete 
    {
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; } 


    }
}