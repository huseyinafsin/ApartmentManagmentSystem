namespace Core.Cahce.Redis
{
    public class RedisEndpointInfo
    {
        public string Endpoint { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
    }
}