using System;
using System.Collections.Generic;
using CustomerSystemBLL.BusinessObjects;
using CustomerSystemDAL;
using CustomerSystemBLL.Converters;
using System.Linq;

namespace CustomerSystemBLL.Services
{
    public class OrderItemService : IOrderItemService
    {
        IDALFacade facade;
        private OrderItemConverter conv = new OrderItemConverter();
        public OrderItemService(IDALFacade facade)
        {
            this.facade = facade;
        }

        public OrderItemBO Create(OrderItemBO oItem)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newoItem = uow.OrderItemRepository.Create(conv.Convert(oItem));
                uow.Complete();
                return conv.Convert(newoItem);
            }

        }

        public OrderItemBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newoItem = uow.OrderItemRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newoItem);
            }

        }

        public OrderItemBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.OrderItemRepository.Get(Id));
            }
        }

        public List<OrderItemBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.OrderItemRepository.GetAll().Select(oi => conv.Convert(oi)).ToList();

            }
        }

        public OrderItemBO Update(OrderItemBO bo)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newoItem = uow.OrderItemRepository.Create();
            }
        }
    }
}
