using Core.Application.Interfaces.Application;
using Mapster;

public class MapperContainer : IMapperContainer
{
    public TDestination Map<TSource, TDestination>(TSource source)
    {
        return source.Adapt<TDestination>();
    }

    public IEnumerable<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> source)
    {
        return source.Adapt<IEnumerable<TDestination>>();
    }
}