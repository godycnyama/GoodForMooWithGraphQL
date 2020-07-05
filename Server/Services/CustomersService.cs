using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GoodForMoo.Server.DataAccess;
using GoodForMoo.Server.DataModels;
using GoodForMoo.Server.Services;

namespace GoodForMoo.Server.Services
{
    public class CustomersService: ICustomersService
    {
        DataAccessContext db;
        public CustomersService(DataAccessContext c)
        {
            db = c;
        }

        //Get all customers records
        public IQueryable<Customer> GetAllCustomers()
        {
            return db.Customers;
        }
    
        //Add new customer record     
        public async Task<Customer> AddCustomer(CreateCustomerInput createCustomerInput)
        {
            Customer _customer = new Customer
            {
                CustomerName = createCustomerInput.CustomerName,
                PhysicalAddress = createCustomerInput.PhysicalAddress,
                Town = createCustomerInput.Town,
                PostalCode = createCustomerInput.PostalCode,
                Province = createCustomerInput.Province,
                Telephone = createCustomerInput.Telephone,
                Mobile = createCustomerInput.Mobile,
                Email = createCustomerInput.Email
            };
            await db.Customers.AddAsync(_customer);
            await db.SaveChangesAsync();
            return _customer;
        }
        //Update customer record  
        public async Task<Customer> UpdateCustomer(int id, UpdateCustomerInput updateCustomerInput)
        {
            //check if customer exists
            Customer customer = await db.Customers.FindAsync(id);
            if(customer == null)
            {
                throw new Exception("Customer not found");
            }
            customer.CustomerName = updateCustomerInput.CustomerName;
            customer.PhysicalAddress = updateCustomerInput.PhysicalAddress;
            customer.Town = updateCustomerInput.Town;
            customer.PostalCode = updateCustomerInput.PostalCode;
            customer.Province = updateCustomerInput.Province;
            customer.Telephone = updateCustomerInput.Telephone;
            customer.Mobile = updateCustomerInput.Mobile;
            customer.Email = updateCustomerInput.Email;
           
            await db.SaveChangesAsync();
            return customer;
        }
        //Get customer record    
        public async Task<Customer> GetCustomer(int id)
        {
            return await db.Customers.FindAsync(id);
        }

        //Get customer record   
        public IQueryable<Customer> GetCustomerByID(int id)
        {
            return db.Customers.Where(t => t.CustomerID == id);
        }

        //Delete customer record     
        public async Task<Customer> DeleteCustomer(int id)
        {
            //check if customer exists
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new Exception("Customer  not found");
            }
            db.Customers.Remove(customer);
            await db.SaveChangesAsync();
            return customer;
        }
    }
}

