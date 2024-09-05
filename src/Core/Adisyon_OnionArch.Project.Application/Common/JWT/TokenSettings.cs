namespace Adisyon_OnionArch.Project.Application.Common.JWT
{
    public class TokenSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int TokenValidatyInMunites { get; set; }
    
    }
}
