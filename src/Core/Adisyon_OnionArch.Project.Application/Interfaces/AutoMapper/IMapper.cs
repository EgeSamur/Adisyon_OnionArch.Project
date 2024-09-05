namespace Adisyon_OnionArch.Project.Application.Interfaces.AutoMapper
{
    public interface IMapper
    {
        // Tek bir maplama
        TDestination Map<TDestination, TSource>(TSource source, string? ignore = null);
        // listeli maplama
        IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null);

        TDestination Map<TDestination>(object source, string? ignore = null);
        IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null);

    }
}
