using System;
<<<<<<< HEAD
namespace CustomerSystemDAL.Repositories
{
    public class CustomerRepository
    {
        public CustomerRepository()
        {
=======
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
>>>>>>> f4d5332d443b24ffb1e1acc0977e95d8d3086fee
        }
    }
}
