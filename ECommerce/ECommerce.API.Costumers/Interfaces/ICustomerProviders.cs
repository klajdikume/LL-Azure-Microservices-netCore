using ECommerce.API.Costumers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Costumers.Interfaces
{
    public interface ICustomerProviders
    {
        Task<(bool isSuccess, IEnumerable<Customer>, string Message)> GetCustomersAsync();
        Task<(bool isSuccess, Customer Customer, string Message)> GetCustomerAsync(int id);
    }
}
