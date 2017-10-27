using System;
using CustomerSystemBLL.BusinessObjects;
using System.Linq;
using CustomerSystemDAL.Entities;

namespace CustomerSystemBLL.Converters
{
    public class CustomerConverter
    {
        public CustomerConverter()
        {

        }
        internal Customer Convert(CustomerBO cust)
        {
            if (cust == null) { return null; }
            return new Customer()
            {
                Id = cust.Id,
                firstName = cust.firstName,
                lastName = cust.lastName
            };
        }
        internal CustomerBO convert(Customer cust)
        {
            if (cust == null) { return null; }
            return new CustomerBO()
            {
                Id = cust.Id,
                firstName = cust.firstName,
                lastName = cust.lastName,

            };
        }
    }
}