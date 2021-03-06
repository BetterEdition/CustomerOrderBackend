﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerSystemBLL.BusinessObjects;
using CustomerSystemBLL.Converters;
using CustomerSystemDAL.Facade;
using CustomerSystemDAL.UOW;

namespace CustomerSystemBLL.Services
{
    class CustomerService : ICustomerService
    {
        DALFacade facade;
        private CustomerConverter conv = new CustomerConverter();

        public CustomerService(DALFacade facade)
        {
            this.facade = facade;
        }
        public CustomerBO Create(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCust = uow.CustomerRepository.Create(conv.Convert(cust));
                uow.Complete();

                return conv.convert(newCust);
            }
        }

        public List<CustomerBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.CustomerRepository.GetAll().Select(c => conv.convert(c)).ToList();
            }
        }

        public CustomerBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.convert(uow.CustomerRepository.Get(Id));
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
                return conv.convert(customerFromDb);
            }
        }

        public CustomerBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newcust = uow.CustomerRepository.Delete(Id);
                uow.Complete();
                return conv.convert(newcust);
            }

        }
    }
}
