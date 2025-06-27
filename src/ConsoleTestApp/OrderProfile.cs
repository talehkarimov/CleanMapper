using CleanMapper.Core;

public class OrderProfile : MapProfile
{
    public override void Configure(MappingConfiguration config)
    {
        config.CreateMap<OrderDto, OrderViewModel>();
        config.CreateMap<OrderItemDto, OrderItemViewModel>();
        config.CreateMap<AddressDto, AddressViewModel>();
    }
}