using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using StackExchange.Redis;

namespace Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
        private IDatabase _redis;
        public BasketRepository( IConnectionMultiplexer multiplexer)
        {
            _redis =  multiplexer.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _redis.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            RedisValue cutomerBasket = await _redis.StringGetAsync(basketId);

            return  cutomerBasket.IsNullOrEmpty? null: JsonSerializer.Deserialize<CustomerBasket>(cutomerBasket);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
              var customerBasket= await _redis.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

            if(!customerBasket) return null;

            return await GetBasketAsync(basket.Id);
        }
    }
}