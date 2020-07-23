using ECommerce.API.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Products
{
    public interface IProductsProvider
    {
        Task<(bool IsSuccess, IEnumerable<Product>, string ErrorMessage)> GetProductsAsync(); // return an named tuple
        Task<(bool IsSuccess, Product Product, string ErrorMessage)> GetProductAsync(int id); // return an named tuple
    }
}
