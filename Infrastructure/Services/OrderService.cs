
using core.Entities.OrderAggregates;
using core.Interfaces;
using core.Specifications;
using Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IBasketRepository basketRepository
        , IUnitOfWork unitOfWork)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            //Form Order

            //Get basket Items from basket repository
            var basket=await _basketRepository.GetBasketAsync(basketId);
            var orderItemList= new List<OrderItem>();
            foreach(var item in basket.Items)
            {
                var productItem=await _unitOfWork.Repository<Product>().GetByID(item.Id);
                var ProductOrderItem= new ProductItemOrdered(productItem.Id,productItem.Name , productItem.PictureUrl);
                var orderItem = new OrderItem(ProductOrderItem, productItem.Price, item.Quantity);
                orderItemList.Add(orderItem);
            }

            var deliveryMethod= await _unitOfWork.Repository<DeliveryMethod>().GetByID(deliveryMethodId);
            
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

            _unitOfWork.Repository<Order>().Add(order);

            //Save order to DB
            var result=await _unitOfWork.Complete();

            if(result <= 0) return null; 

            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _unitOfWork.Repository<DeliveryMethod>().GetListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
          var specs= new  OrdersWithItemsAndOrderingSpecification(id, buyerEmail);

          return await _unitOfWork.Repository<Order>().GetByIDAsync(specs);
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
             var specs= new  OrdersWithItemsAndOrderingSpecification(buyerEmail);

            return await _unitOfWork.Repository<Order>().GetListAsync(specs);
        }
    }
}