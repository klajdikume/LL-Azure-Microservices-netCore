using AutoMapper;
using ECommerce.API.Orders.Db;
using ECommerce.API.Orders.Interfaces;
using ECommerce.API.Orders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Orders.Providers
{
    public class OrdersProvider : IOrdersProvider
    {
        private readonly OrdersDbContext _dbContext;
        private readonly ILogger<OrdersProvider> _logger;
        private readonly IMapper _mapper;

        public OrdersProvider(OrdersDbContext dbContext, ILogger<OrdersProvider> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;

            //SeedData();
        }
        public async Task<(bool IsSuccess, IEnumerable<Models.Order> Orders, string ErrorMessage)> GetOrdersAsync(int customerId)
        {
            var orders = await _dbContext.Orders.Where(c => c.CustomerId == customerId).ToListAsync();
            if(orders != null && orders.Any())
            {
                _logger.LogInformation($"Orderes Resulted: {orders.Count}");
                var result = _mapper.Map<IEnumerable<Db.Order>, IEnumerable<Models.Order>>(orders);

                return (true, result, null);
            }
            return (false, null, "Not found");
        }
    }
}
