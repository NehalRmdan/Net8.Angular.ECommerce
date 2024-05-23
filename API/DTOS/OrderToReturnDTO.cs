using core.Entities.OrderAggregates;

namespace API.DTOS
{
    public class OrderToReturnDTO
    {
        public int Id { get; set; }

        public IReadOnlyList<OrderItemDTO> OrderItems { get; set; }

        public string BuyerEmail { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        public Address ShippedToAddress { get; set; }

        public string DeliveryMethod { get; set; }
		public decimal ShippingPrice { get; set; }

        public int PaymentIntentId { get; set; }

        public string Status { get; set; } 

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

    }
}