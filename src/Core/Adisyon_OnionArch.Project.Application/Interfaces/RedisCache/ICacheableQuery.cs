namespace Adisyon_OnionArch.Project.Application.Interfaces.RedisCache
{
    // cachlemek istediğimiz requeste gidip bunu veriyoruz.
    public interface ICacheableQuery
    {
        string CacheKey { get; }
        double CacheTime { get; }
    }
}
