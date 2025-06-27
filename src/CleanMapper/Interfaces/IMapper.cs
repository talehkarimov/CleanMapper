namespace CleanMapper.Interfaces;

public interface IMapper
{
    TDestination Map<TSource, TDestination>(TSource source);
    void AddProfile(IProfile profile);
}