using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodForMoo.Server.DataModels;

namespace GoodForMoo.Server.Services
{
   public interface IOrdersService
    {
        public IQueryable<Order> GetAllOrders();
        public Task<Order> AddOrder(CreateOrderInput createOrderInput);
        public Task<Order> UpdateOrder(int id, UpdateOrderInput updateOrderInput);
        public Task<Order> GetOrder(int id);
        public IQueryable<Order> GetOrderByID(int id);
        public Task<Order> DeleteOrder(int id);
    }
}
