using ECommerce.API.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Search.Interfaces
{
    public interface IOrderService
    {
        Task<(bool IsSuccess, IEnumerable<Order> Orders, string ErrorMessage)> 
            GetOrdersAsync(int customerId);
    }
}
