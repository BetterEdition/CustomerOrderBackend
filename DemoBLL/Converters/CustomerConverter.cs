﻿using System;
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
                FirstName = cust.FirstName,
                LastName = cust.LastName
<<<<<<< HEAD
=======


>>>>>>> c66e93a58bd89234e4fd2a82c63ca8b5202c0300
            };
        }
        internal CustomerBO convert(Customer cust)
        {
            if (cust == null) { return null; }
            return new CustomerBO()
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName,

            };
        }
    }
}