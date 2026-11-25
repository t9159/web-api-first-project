using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Services
{
    public interface IOrderService
    {
        public Task<Order> AddOrder(Order order);
    }
}
