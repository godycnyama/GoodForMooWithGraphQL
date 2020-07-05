using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GoodForMoo.Server.DataModels;

namespace GoodForMoo.Server.Services
{
   public interface ICustomersService
    {
        public IQueryable<Customer> GetAllCustomers();
        public Task<Customer> AddCustomer(CreateCustomerInput createCustomerInput);
        public Task<Customer> UpdateCustomer(int id, UpdateCustomerInput updateCustomerInput);
        public Task<Customer> GetCustomer(int id);
        public IQueryable<Customer> GetCustomerByID(int id);
        public Task<Customer> DeleteCustomer(int id);
    }
}
