using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerSystemBLL.BusinessObjects;
using CustomerSystemBLL.Converters;
using CustomerSystemDAL;
using CustomerSystemDAL.Facade;
using CustomerSystemDAL.UOW;

namespace CustomerSystemBLL.Services
{
    class CustomerService : ICustomerService
    {
        IDALFacade facade;
        private CustomerConverter conv = new CustomerConverter();

        public CustomerService(IDALFacade facade)
        {
            this.facade = facade;
        }
        public CustomerBO Create(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCust = uow.CustomerRepository.Create(conv.Convert(cust));
                uow.Complete();

                return conv.Convert(newCust);
            }
        }

        public List<CustomerBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.CustomerRepository.GetAll().Select(c => conv.Convert(c)).ToList();
            }
        }

        public CustomerBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.CustomerRepository.Get(Id));
            }

        }

        public CustomerBO Update(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var customerFromDb = uow.CustomerRepository.Get(cust.Id);
                if (customerFromDb == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }
                customerFromDb.FirstName = cust.FirstName;
                customerFromDb.LastName = cust.LastName;
                customerFromDb.Address = cust.Address;
                customerFromDb.Age = cust.Age;
                uow.Complete();
                return conv.Convert(customerFromDb);
            }
        }

        public CustomerBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newcust = uow.CustomerRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newcust);
            }

        }
    }
}
