using System;

namespace Core.Abstract
{
    public interface IMongoEntity
    {
    }

    public interface IMongoEntity<out TKey> : IMongoEntity where TKey : IEquatable<TKey>
    {
        public TKey Id { get; }
        DateTime CreatedAt { get; set; }
    }
}