using ECommerce.API.Costumers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Costumers.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerProviders _customerProviders;

        public CustomersController(ICustomerProviders customerProviders)
        {
            _customerProviders = customerProviders;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var result = await _customerProviders.GetCustomersAsync();
            if (result.isSuccess)
            {
                return Ok(result.Item2);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var result = await _customerProviders.GetCustomerAsync(id);
            if (result.isSuccess)
            {
                return Ok(result.Item2);
            }
            return NotFound();
        }
    }
}
