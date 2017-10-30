using System;
using CustomerSystemBLL.BusinessObjects;
using System.Linq;
using CustomerSystemDAL.Entities;

namespace CustomerSystemBLL.Converters
{
    public class CustomerConverter : IConverter<Customer, CustomerBO>
    {
        public CustomerConverter()
        {

        }

        public CustomerBO Convert(Customer cust)
        {

            if (cust == null) { return null; }
            return new CustomerBO()
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
<<<<<<< HEAD
                LastName = cust.LastName,
=======
                LastName = cust.LastName

>>>>>>> 114be74babcbd96a6165d94303759e692354420f

            };
        }


        public Customer Convert(CustomerBO cust)
        {
            if (cust == null) { return null; }
            return new Customer()
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }
    }
}