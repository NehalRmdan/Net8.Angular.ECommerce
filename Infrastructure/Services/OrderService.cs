
using core.Entities.OrderAggregates;
using core.Interfaces;
using core.Specifications;
using Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly BasketRepository _basketRepository;
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<DeliveryMethod> _deliveryMethodsRepository;

        public OrderService(BasketRepository basketRepository
        , IGenericRepository<Order> orderRepository, IGenericRepository<Product> productRepository, IGenericRepository<DeliveryMethod> deliveryMethodRepository)
        {
            _basketRepository = basketRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _deliveryMethodsRepository = deliveryMethodRepository;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            //Form Order

            //Get basket Items from basket repository
            var basket=await _basketRepository.GetBasketAsync(basketId);
            var orderItemList= new List<OrderItem>();
            foreach(var item in basket.Items)
            {
                var productItem=await _productRepository.GetByID(item.Id);
                var ProductOrderItem= new ProductItemOrdered(productItem.Id,productItem.Name , productItem.PictureUrl);
                var orderItem = new OrderItem(ProductOrderItem, productItem.Price, item.Quantity);
                orderItemList.Add(orderItem);
            }

            var deliveryMethod= await _deliveryMethodsRepository.GetByID(deliveryMethodId);
            
               // calc subtotal
            var subtotal = orderItemList.Sum(item => item.Price * item.Quantity);

            var order= new Order(
                buyerEmail:buyerEmail,
                orderItems: orderItemList,
                shippedToAddress : shippingAddress,
                deliveryMethod : deliveryMethod,
                subTotal : subtotal,
                paymentIntentId : 1
            );


            //Save order to DB

            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _deliveryMethodsRepository.GetListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
          var specs= new  OrdersWithItemsAndOrderingSpecification(id, buyerEmail);

          return await _orderRepository.GetByIDAsync(specs);
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
             var specs= new  OrdersWithItemsAndOrderingSpecification(buyerEmail);

            return await _orderRepository.GetListAsync(specs);
        }
    }
}