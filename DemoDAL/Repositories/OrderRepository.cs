using System;
using System.Collections.Generic;
using CustomerSystemDAL.Context;
using CustomerSystemDAL.Entities;
using System.Linq;

namespace CustomerSystemDAL.Repositories
{
    public class OrderRepository : IorderRepository
    {
        EASVContext _context;
        public OrderRepository(EASVContext context)
        {
            _context = context;
        }
        public Order Create(Order order)
        {
            _context.Orders.Add(order);
            return order;
        }

        public Order Delete(int Id)
        {
            var order = Get(Id);
            _context.Orders.Remove(order);
            return order;
        }

        public Order Get(int Id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == Id);

        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public IEnumerable<Order> GetAllById(List<int> ids)
        {
            return null;
        }
    }
}
