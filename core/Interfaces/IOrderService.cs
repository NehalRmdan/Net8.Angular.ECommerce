using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities.OrderAggregates;

namespace core.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId,string basketId, Address shippingAddress);

        public Task<Order> GetOrderByIdAsync(int id, string buyerEmail);

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}