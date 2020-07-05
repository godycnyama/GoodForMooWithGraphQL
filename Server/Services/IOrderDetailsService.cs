using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GoodForMoo.Server.DataModels;

namespace GoodForMoo.Server.Services
{
   public interface IOrderDetailsService
    {
        public IQueryable<OrderDetail> GetOrderDetails();
        public IEnumerable<OrderDetail> GetOrderDetailsPerOrderID(int ownerID);
    }
}
