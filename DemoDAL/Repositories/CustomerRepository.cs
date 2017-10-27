using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerSystemDAL.Context;
using CustomerSystemDAL.Entities;
using CustomerSystemDAL.UOW;

namespace CustomerSystemDAL.Repositories
{
     
    class CustomerRepository : ICustomerRepository
    {
        EASVContext _context;

        public Customer Create(Customer cust)
        {
            _context.Customers.Add(cust);
            return cust;
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
            
        }

        public Customer Get(int Id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == Id);
        }

        public Customer Delete(int Id)
        {
            var cust = Get(Id);
            _context.Customers.Remove(cust);
            return cust;
        }
    }
}
