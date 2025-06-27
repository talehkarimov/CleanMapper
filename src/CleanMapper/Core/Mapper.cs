using CleanMapper.Interfaces;

namespace CleanMapper.Core;

public class Mapper : IMapper
{
    private readonly MappingConfiguration _config = new();

    public Mapper(params IProfile[] profiles)
    {
        foreach (var profile in profiles)
        {
            profile.Configure(_config);
        }
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        if (source == null) return default;

        if (_config.Mappings.TryGetValue((typeof(TSource), typeof(TDestination)), out var mapFunc))
        {
            return ((Func<TSource, TDestination>)mapFunc)(source);
        }

        throw new InvalidOperationException($"No mapping found from {typeof(TSource)} to {typeof(TDestination)}");
    }

    public void AddProfile(IProfile profile)
    {
        profile.Configure(_config);
    }
}