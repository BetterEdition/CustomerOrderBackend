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

        

        public BLLFacade(IConfiguration conf){
            facade = new DALFacade(new DbOptions()
            {
                ConnectionString = conf.GetConnectionString("DefaultConnection"),
                Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT Development")
            });
        }


        public ICustomerService CustomerService {
            get { return new CustomerService(new DALFacade(new DbOptions())); }
        }
    }
}
