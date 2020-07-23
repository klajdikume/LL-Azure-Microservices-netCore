using AutoMapper;
using ECommerce.API.Costumers.Db;
using ECommerce.API.Costumers.Interfaces;
using ECommerce.API.Costumers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Costumers.Providers
{
    public class CustomerProviders : ICustomerProviders
    {
        private readonly CustomersDbContext _dbContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CustomerProviders(CustomersDbContext dbContext, ILogger logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
            SeedData();
        }

        private void SeedData()
        {
            if (!_dbContext.Customers.Any())
            {
                _dbContext.Customers.Add(new Db.Customer() { Id = 1, Name = "KeyBoadrd", Address = "St 3 Deshmoret" });
                _dbContext.Customers.Add(new Db.Customer() { Id = 2, Name = "Mouse", Address = "BalumStrasse" });
                _dbContext.Customers.Add(new Db.Customer() { Id = 3, Name = "Monitor", Address = "OsterrichStrasse" });
                _dbContext.SaveChanges();
            }
        }

        public async Task<(bool isSuccess, Models.Customer Customer, string Message)> GetCustomerAsync(int id)
        {
            try
            {
                _logger?.LogInformation("Querying customers");

                var customer = await _dbContext.Customers.FirstOrDefaultAsync(i => i.Id == id);
                if (customer != null)
                {
                    _logger?.LogInformation($"Customer with Id = {customer.Id} resulted");
                    var result = _mapper.Map<Db.Customer, Models.Customer>(customer);

                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, IEnumerable<Models.Customer>, string Message)> GetCustomersAsync()
        {
            try
            {
                _logger?.LogInformation("Querying customers");

                var customers = await _dbContext.Customers.ToListAsync();
                if(customers != null && customers.Any())
                {
                    _logger?.LogInformation($"{customers.Count} customers resulted");
                    var result = _mapper.Map<IEnumerable<Db.Customer>, IEnumerable<Models.Customer>>(customers);

                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch(Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
