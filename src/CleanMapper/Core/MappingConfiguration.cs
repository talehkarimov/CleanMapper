using System.Linq.Expressions;

namespace CleanMapper.Core;

public class MappingConfiguration
{
    internal Dictionary<(Type, Type), Delegate> Mappings = new();

    public void CreateMap<TSource, TDestination>()
    {
        var sourceProps = typeof(TSource).GetProperties();
        var destProps = typeof(TDestination).GetProperties();

        var sourceParam = Expression.Parameter(typeof(TSource), "src");
        var bindings = new List<MemberBinding>();

        foreach (var destProp in destProps)
        {
            var sourceProp = sourceProps.FirstOrDefault(p => p.Name == destProp.Name && p.PropertyType == destProp.PropertyType);
            if (sourceProp != null)
            {
                var propertyAccess = Expression.Property(sourceParam, sourceProp);
                bindings.Add(Expression.Bind(destProp, propertyAccess));
            }
        }

        var body = Expression.MemberInit(Expression.New(typeof(TDestination)), bindings);
        var lambda = Expression.Lambda<Func<TSource, TDestination>>(body, sourceParam);
        Mappings[(typeof(TSource), typeof(TDestination))] = lambda.Compile();
    }

    public void CreateMap<TSource, TDestination>(Func<TSource, TDestination> mapFunc)
    {
        Mappings[(typeof(TSource), typeof(TDestination))] = mapFunc;
    }
}