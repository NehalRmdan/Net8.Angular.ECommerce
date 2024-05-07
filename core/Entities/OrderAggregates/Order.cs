using System.Reflection.Metadata.Ecma335;

namespace core.Entities.OrderAggregates
{
    public class Order : BaseEntity
    {
        public Order()
        {
        }

        public Order(IReadOnlyList<OrderItem> orderItems
            , string buyerEmail
            , Address shippedToAddress
            , DeliveryMethod deliveryMethod
            , decimal subTotal
            , int paymentIntentId)
        {
            BuyerEmail = buyerEmail;
            OrderItems = orderItems;
            ShippedToAddress = shippedToAddress;
            DeliveryMethod = deliveryMethod;
            PaymentIntentId = paymentIntentId;
            SubTotal = subTotal;
        }

        public IReadOnlyList<OrderItem> OrderItems { get; set; }

        public string BuyerEmail { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public Address ShippedToAddress { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

        public int PaymentIntentId { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public decimal SubTotal { get; set; }

        public decimal GetTotal() { 
             return SubTotal + DeliveryMethod.Price; 
        }

    }
}
