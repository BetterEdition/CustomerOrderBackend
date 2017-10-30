using System;
using System.Collections.Generic;
using System.Linq;

using CustomerSystemDAL.Context;
using CustomerSystemDAL.Entities;


namespace CustomerSystemDAL.Repositories
{

    class CustomerRepository : ICustomerRepository
    {
        EASVContext _context;


        public CustomerRepository(EASVContext context)
        {
            _context = context;
        }
        public Customer Create(Customer cust)
        {
            _context.Customers.Add(cust);
            return cust;
        }

        public Customer Delete(int Id)
        {
            var cust = Get(Id);
            _context.Customers.Remove(cust);
            return cust;
        }

        public Customer Get(int Id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
        //To get more customers by id
        public IEnumerable<Customer> GetAllById(List<int> ids)
        {
            return null;
        }

    }
}
