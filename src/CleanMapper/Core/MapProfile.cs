using CleanMapper.Interfaces;

namespace CleanMapper.Core;

public abstract class MapProfile : IProfile
{
    public abstract void Configure(MappingConfiguration config);
}