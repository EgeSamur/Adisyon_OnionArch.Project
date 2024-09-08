﻿using AutoMapper;
using AutoMapper.Internal;

namespace Adisyon_OnionArch.Project.CustomMapper.AutoMapper
{
    public class Mapper : Application.Interfaces.AutoMapper.IMapper
    {
        public static List<TypePair> _typePairs = new();
        private IMapper _mapperContainer;

        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);
            return _mapperContainer.Map<TSource, TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);
            return _mapperContainer.Map<IList<TSource>, IList<TDestination>>(source);
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {
            Config<TDestination, object>(5, ignore);
            return _mapperContainer.Map<TDestination>(source);

        }

        public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
        {
            Config<TDestination, IList<object>>(5, ignore);
            return _mapperContainer.Map<IList<TDestination>>(source);
        }

        protected void Config<TDestination, TSource>(int depth = 5, string? ignore = null)
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestination));
            if (_typePairs.Any(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType) && ignore is null)
            {
                return;
            }
            _typePairs.Add(typePair);
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var item in _typePairs)
                {
                    if (ignore is not null)
                    {
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ignore, x => x.Ignore()).ReverseMap();
                    }
                    else
                    {
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth);
                    }
                }
            });
            _mapperContainer = config.CreateMapper();
        }

    }
}
