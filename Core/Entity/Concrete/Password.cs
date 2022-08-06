namespace Core.Entity.Concrete
{
    public class Password : BaseEntity
    {
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}