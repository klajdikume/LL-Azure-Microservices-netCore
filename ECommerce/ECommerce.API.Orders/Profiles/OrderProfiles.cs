using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Orders.Profiles
{
    public class OrderProfiles : AutoMapper.Profile
    {
        public OrderProfiles()
        {
            CreateMap<Db.Order, Models.Order>();
            CreateMap<Db.OrderItem, Models.OrderItem>();
        }
    }
}
