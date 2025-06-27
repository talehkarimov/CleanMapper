using CleanMapper.Core;
using CleanMapper.Extensions;
var mapper = new Mapper(new OrderProfile());

var orderDto = new OrderDto
{
    Id = 1001,
    CustomerName = "John Doe",
    ShippingAddress = new AddressDto { Street = "123 Main St", City = "Baku" },
    Items = new List<OrderItemDto>
            {
                new OrderItemDto { ProductId = 1, ProductName = "Laptop", Price = 1500 },
                new OrderItemDto { ProductId = 2, ProductName = "Mouse", Price = 25 }
            }
};

// Map root object
var orderViewModel = mapper.Map<OrderDto, OrderViewModel>(orderDto);

// Manually map nested collection and object
orderViewModel.Items = mapper.MapList<OrderItemDto, OrderItemViewModel>(orderDto.Items).ToList();
orderViewModel.ShippingAddress = mapper.Map<AddressDto, AddressViewModel>(orderDto.ShippingAddress);

// Output result
Console.WriteLine($"Order Id: {orderViewModel.Id}");
Console.WriteLine($"Customer: {orderViewModel.CustomerName}");
Console.WriteLine($"Shipping: {orderViewModel.ShippingAddress.Street}, {orderViewModel.ShippingAddress.City}");
Console.WriteLine("Items:");
foreach (var item in orderViewModel.Items)
{
    Console.WriteLine($"- {item.ProductName}: ${item.Price}");
}