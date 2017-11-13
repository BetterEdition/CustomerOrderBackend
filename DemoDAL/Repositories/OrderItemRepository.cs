using System;
using System.Collections.Generic;
using CustomerSystemDAL.Entities;
using CustomerSystemDAL.Context;
using System.Linq;

namespace CustomerSystemDAL.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        EASVContext _context;
        public OrderItemRepository(EASVContext context)
        {
            _context = context;
        }

        public OrderItem Create(OrderItem oItem)
        {
            _context.OrderItems.Add(oItem);
            return oItem;
        }

        public OrderItem Delete(int Id)
        {
            var oItem = Get(Id);
            _context.OrderItems.Remove(oItem);
            return oItem;
        }

        public OrderItem Get(int Id)
        {
            return _context.OrderItems.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _context.OrderItems.ToList();
        }

        public IEnumerable<OrderItem> GetAllById(List<int> ids)
        {
            return null;
        }
    }
}
