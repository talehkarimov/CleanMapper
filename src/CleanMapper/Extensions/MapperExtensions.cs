using CleanMapper.Interfaces;

namespace CleanMapper.Extensions;

public static class MapperExtensions
{
    public static IEnumerable<TDestination> MapList<TSource, TDestination>(this IMapper mapper, IEnumerable<TSource> sourceList)
    {
        foreach (var src in sourceList)
        {
            yield return mapper.Map<TSource, TDestination>(src);
        }
    }

    public static Dictionary<TKey, TDestination> MapDictionary<TKey, TSource, TDestination>(
        this IMapper mapper,
        IDictionary<TKey, TSource> sourceDict)
    {
        var result = new Dictionary<TKey, TDestination>();
        foreach (var kvp in sourceDict)
        {
            result[kvp.Key] = mapper.Map<TSource, TDestination>(kvp.Value);
        }
        return result;
    }

    public static TDestination[] MapArray<TSource, TDestination>(
        this IMapper mapper,
        TSource[] sourceArray)
    {
        var result = new TDestination[sourceArray.Length];
        for (int i = 0; i < sourceArray.Length; i++)
        {
            result[i] = mapper.Map<TSource, TDestination>(sourceArray[i]);
        }
        return result;
    }

    public static HashSet<TDestination> MapHashSet<TSource, TDestination>(
        this IMapper mapper,
        IEnumerable<TSource> source)
    {
        return source.Select(s => mapper.Map<TSource, TDestination>(s)).ToHashSet();
    }

    public static TDestination? MapNullable<TSource, TDestination>(
        this IMapper mapper,
        TSource? source)
        where TSource : struct
        where TDestination : struct
    {
        if (source.HasValue)
        {
            return mapper.Map<TSource, TDestination>(source.Value);
        }
        return null;
    }
}
