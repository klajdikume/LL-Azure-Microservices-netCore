using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Search.Interface
{
    public interface ISearchService
    {
        Task<(bool isSuccess, dynamic SearchResults)> SearchAsync(int customerId);
    }
}
