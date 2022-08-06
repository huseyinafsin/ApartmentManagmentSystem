using System;
using ServiceStack.Redis;
using System;
using Microsoft.Extensions.Configuration;


namespace Core.Cahce.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly RedisEndpoint _redisEndpoint;

        public RedisCacheManager(RedisEndpoint redisEndpoint)
        {

            _redisEndpoint = redisEndpoint;
        }
        public T Get<T>(string key)
        {

            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                return redisClient.Get<T>(key);
            }
        }

        public object Get(string key)
        {
            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                return redisClient.Get(key);
            }
        }

        public void Add(string key, object data, int duration)
        {
            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                redisClient.Set(key, data, TimeSpan.FromMinutes(duration));
            }
        }

        public void Add(string key, object data)
        {
            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                redisClient.Set(key, data);
            }
        }

        public bool IsAdd(string key)
        {
            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                return redisClient.ContainsKey(key);
            }
        }

        public void Remove(string key)
        {
            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                redisClient.Remove(key);
            }
        }

        public void RemoveByPattern(string pattern)
        {
            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                redisClient.RemoveByPattern(pattern);
            }
        }
    }


}
