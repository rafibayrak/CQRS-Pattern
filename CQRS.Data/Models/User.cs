using System;

namespace CQRS.Data.Models
{
    public class User : BaseModel
    {
        public User()
        {
            Id = Guid.NewGuid();
            CreationTime = DateTime.UtcNow;
            ModificationTime = DateTime.UtcNow;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
