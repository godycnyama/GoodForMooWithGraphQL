using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodForMoo.Server.DataAccess;
using GoodForMoo.Server.DataModels;

namespace GoodForMoo.Server.Services
{
    public class OrdersService: IOrdersService
    {
        DataAccessContext db;
        public OrdersService(DataAccessContext c)
        {
            db = c;
        }
        CultureInfo en = new CultureInfo("en");

        //Get order records
        public IQueryable<Order> GetAllOrders()
        {
            ///return db.Orders;
            return db.Orders.Include(c => c.Customer)
                            .Include(c => c.OrderDetails);
        }

        //Add new order record     
        public async Task<Order> AddOrder(CreateOrderInput createOrderInput)
        {
            Debug.WriteLine(JsonConvert.SerializeObject(createOrderInput.OrderDetails));
            //CultureInfo en = new CultureInfo("en");

            //search for a customer record
            Customer customer = await db.Customers.FindAsync(createOrderInput.CustomerID);

            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            Order order = new Order
            {
                Customer = customer,
                OrderDate = DateTime.Now,
                DeliveryAddress = createOrderInput.DeliveryAddress,
                DeliveryDate = DateTime.Parse(createOrderInput.DeliveryDate),
                OrderStatus = createOrderInput.OrderStatus,
                Currency = "R"
            };

            order.OrderDetails = new List<OrderDetail>();
            foreach (var item in createOrderInput.OrderDetails){
                var orderDetail = new OrderDetail();
                orderDetail.ProductID = item.ProductID;
                orderDetail.ProductName = item.ProductName;
                orderDetail.UnitPrice = item.UnitPrice;
                orderDetail.Currency = item.Currency;
                orderDetail.Quantity = item.Quantity;
                orderDetail.UnitOfMeasure = item.UnitOfMeasure;
                order.SubTotal += item.UnitPrice * item.Quantity;
                order.OrderDetails.Add(orderDetail);
            }
            
            order.Tax = order.SubTotal * (decimal)0.15;
            order.Total = order.SubTotal + order.Tax;
            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return order; 
        }   

        //Update order record   
        public async Task<Order> UpdateOrder(int id, UpdateOrderInput updateOrderInput)
        {
            Debug.WriteLine(JsonConvert.SerializeObject(updateOrderInput.OrderDetails));

            //CultureInfo en = new CultureInfo("en");

            //search for order record
            Order order = await db.Orders
                .Include(p => p.OrderDetails)
                .SingleAsync(p => p.OrderID == id);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            //search for a customer record
            Customer customer = await db.Customers.FindAsync(updateOrderInput.CustomerID);

            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            order.Customer = customer;
            order.DeliveryAddress = updateOrderInput.DeliveryAddress;
            order.DeliveryDate = DateTime.Parse(updateOrderInput.DeliveryDate);
            order.Currency = "R";
            order.OrderStatus = updateOrderInput.OrderStatus;
            List<OrderDetail> _orderDetails = new List<OrderDetail>(order.OrderDetails.ToList());
            foreach (var item in _orderDetails)
            {
                order.OrderDetails.Remove(item);
            }
            //order.OrderDetails.Clear();
            order.SubTotal = 0;
            order.Tax = 0;
            order.Total = 0;
            await db.SaveChangesAsync();
            Debug.WriteLine(JsonConvert.SerializeObject(order));
            //update orderDetails
            order.OrderDetails = new List<OrderDetail>();
            foreach (var item in updateOrderInput.OrderDetails)
            {
                var orderDetail = new OrderDetail();
                orderDetail.ProductID = item.ProductID;
                orderDetail.ProductName = item.ProductName;
                orderDetail.UnitPrice = item.UnitPrice;
                orderDetail.Currency = item.Currency;
                orderDetail.Quantity = item.Quantity;
                orderDetail.UnitOfMeasure = item.UnitOfMeasure;
                order.SubTotal += item.UnitPrice * item.Quantity;
                order.OrderDetails.Add(orderDetail);
            }

            order.Tax = order.SubTotal * (decimal)0.15;
            order.Total = order.SubTotal + order.Tax;
            //db.Orders.Update(order);
            Debug.WriteLine(JsonConvert.SerializeObject(order));
            await db.SaveChangesAsync();
            return order;
        }
        //Get order record   
        public async Task<Order> GetOrder(int id)
        {
           return await db.Orders.FindAsync(id);
        }

        //Get order record   
        public IQueryable<Order> GetOrderByID(int id)
        {
            return db.Orders.Where(t => t.OrderID == id);
        }

        //Delete order record   
        public async Task<Order> DeleteOrder(int id)
        {
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            db.Orders.Remove(order);
            await db.SaveChangesAsync();
            return order;
        }
    }
}
