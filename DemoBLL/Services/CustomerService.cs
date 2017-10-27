using System;
using System.Collections.Generic;
using System.Text;
using CustomerSystemBLL.BusinessObjects;
using CustomerSystemBLL.Converters;
using CustomerSystemDAL.Facade;

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
            throw new NotImplementedException();
        }

        public List<CustomerBO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerBO Get(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerBO Update(CustomerBO cust)
        {
            throw new NotImplementedException();
        }

        public CustomerBO Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
