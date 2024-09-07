﻿namespace Adisyon_OnionArch.Project.Application.Interfaces.RedisCache
{
    public interface IRedisCacheService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, DateTime? expratimTime = null);
    }
}
