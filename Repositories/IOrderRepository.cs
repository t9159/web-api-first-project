using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        public Task<Order> AddOrder(Order order);

    }
}
