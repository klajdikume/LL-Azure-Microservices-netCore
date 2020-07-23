using ECommerce.API.Search.Interface;
using ECommerce.API.Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Search.Services
{
    public class SearchServices : ISearchService
    {
        private readonly IOrderService _orderService;

        public SearchServices(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<(bool isSuccess, dynamic SearchResults)> SearchAsync(int customerId)
        {
            var ordersResult = await _orderService.GetOrdersAsync(customerId);
            if (ordersResult.IsSuccess)
            {
                var result = new
                {
                    Orders = ordersResult.Orders
                };
                return (true, result);
            }
            return (false, null);
        }
    }
}
