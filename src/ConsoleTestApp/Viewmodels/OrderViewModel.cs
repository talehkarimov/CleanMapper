public class OrderViewModel
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public List<OrderItemViewModel> Items { get; set; }
    public AddressViewModel ShippingAddress { get; set; }
}