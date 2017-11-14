using System;
using System.Collections.Generic;
using CustomerSystemBLL.BusinessObjects;
using CustomerSystemDAL;
using CustomerSystemBLL.Converters;
using CustomerSystemDAL.UOW;
using System.Linq;

namespace CustomerSystemBLL.Services
{
    class OrderService : IOrderService
    {
        IDALFacade facade;
        private OrderConverter conv = new OrderConverter();
        public OrderService(IDALFacade facade)
        {
            this.facade = facade;
        }
        public OrderBO Create(OrderBO order)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newOrder = uow.OrderRepository.Create(conv.Convert(order));
                uow.Complete();

                return conv.Convert(newOrder);
            }
        }
        

        public OrderBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newOrder = uow.OrderRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newOrder);
            }
        }

        public OrderBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.OrderRepository.Get(Id));
            }
        }

        public List<OrderBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.OrderRepository.GetAll().Select(c => conv.Convert(c)).ToList();
            }
        }

        public OrderBO Update(OrderBO order)
        {
            using (var uow = facade.UnitOfWork)
            {
                var orderFromDb = uow.OrderRepository.Get(order.Id);
                if (orderFromDb == null)
                {
                    throw new InvalidOperationException("Order not found");
                }
                orderFromDb.orderDate = order.orderDate;
                orderFromDb.deliveryDate = order.deliveryDate;
                uow.Complete();
                return conv.Convert(orderFromDb);
            }
        }
    }
}
