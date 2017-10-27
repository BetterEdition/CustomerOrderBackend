using System.Collections.Generic;
using CustomerSystemDAL.Entities;

namespace CustomerSystemDAL.UOW
{
    public interface ICustomerRepository
    {
        Customer Create(Customer cust);

        List<Customer> GetAll();

        Customer Get(int Id);

        Customer Delete(int Id);
    }
}