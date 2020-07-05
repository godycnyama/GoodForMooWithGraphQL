using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodForMoo.Server.DataAccess;
using GoodForMoo.Server.DataModels;

namespace GoodForMoo.Server.Services
{
    public class OrderDetailsService: IOrderDetailsService
    {
        DataAccessContext db;
        public OrderDetailsService(DataAccessContext c)
        {
            db = c;
        }
        CultureInfo en = new CultureInfo("en");

        //Get order records by odata
        public IQueryable<OrderDetail> GetOrderDetails()
        {
            ///return db.Orders;
            return db.OrderDetails;
        }

        public IEnumerable<OrderDetail> GetOrderDetailsPerOrderID(int ownerID)
        {
            return db.OrderDetails.Where(a => a.OrderID == ownerID)
                                  .ToList();
        }
        
    }
}
