using System;
using CustomerSystemBLL.Services;
using CustomerSystemDAL;
using CustomerSystemDAL.Facade;
using Microsoft.Extensions.Configuration;

namespace CustomerSystemBLL.Facade
{
    public class BLLFacade : IBLLFacade
    {
        private IDALFacade facade;



        public BLLFacade(IConfiguration conf)
        {
            facade = new DALFacade(new DbOptions()
            {
                ConnectionString = conf.GetConnectionString("DefaultConnection"),
                Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            });
        }


        public ICustomerService CustomerService
        {
            get { return new CustomerService(facade); }

        }
        public IOrderService OrderService
        {
            get { return new OrderService(facade); }
        }
<<<<<<< HEAD

        public IOrderItemService OrderItemService
        {
            get { return new OrderItemService(facade); }
        }
||||||| merged common ancestors
=======

        public IOrderItemService OrderItemService { get; }
>>>>>>> 1faddd91ad149b93bc9348695bd83fa7d10dc946
    }
}
