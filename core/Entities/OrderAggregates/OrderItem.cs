namespace core.Entities.OrderAggregates
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
        }

        public OrderItem(ProductItemOrdered productOrderItem, decimal price, int quantity)
        {
            ProductOrderItem = productOrderItem;
            Price = price;
            Quantity = quantity;
        }

        public ProductItemOrdered ProductOrderItem { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

    }
}
