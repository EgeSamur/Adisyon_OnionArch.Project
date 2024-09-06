using Microsoft.AspNetCore.Identity;

namespace Adisyon_OnionArch.Project.Domain.Entities.Auth
{
    public class User : IdentityUser<Guid>
    {
        public byte[] PasswordSalt { get; set; }
        public byte[] PaswordHashByte { get; set; }
        public bool IsAdmin { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireTime { get; set; }
    }
}
