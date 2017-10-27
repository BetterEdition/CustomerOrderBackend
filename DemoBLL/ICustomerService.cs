using System;
using System.Collections.Generic;
using CustomerSystemBLL.BusinessObjects;

namespace CustomerSystemBLL
{
    public interface ICustomerService
    {
        CustomerBO Create(CustomerBO cust);

        List<CustomerBO> GetAll();

        CustomerBO Get(int id);

        CustomerBO Update(CustomerBO cust);

        CustomerBO Delete(int Id);


    }
}
