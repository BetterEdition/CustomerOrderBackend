using System;
using CustomerSystemDAL.Context;
using CustomerSystemDAL.Entities;
using CustomerSystemDAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerSystemDAL.UOW
{

    public class UnitOfWork : IUnitOfWork
    {


        public ICustomerRepository CustomerRepository { get; internal set; }
        public IorderRepository OrderRepository { get; internal set; }


        private EASVContext context;
        private static DbContextOptions<EASVContext> optionsStatic;

        /* public UnitOfWork()
         {
             context = new EASVContext();
             CustomerRepository = new CustomerRepository(context);

         }
 */
        public UnitOfWork(DbOptions opt)
        {
            if (opt.Environment == "Development" && String.IsNullOrEmpty(opt.ConnectionString))
            {
                optionsStatic = new DbContextOptionsBuilder<EASVContext>()
                   .UseInMemoryDatabase("TheDB")
                   .Options;
                context = new EASVContext(optionsStatic);
            }
            else
            {
                var options = new DbContextOptionsBuilder<EASVContext>()
                .UseSqlServer(opt.ConnectionString)
                    .Options;
                context = new EASVContext(options);
            }
            OrderRepository = new OrderRepository(context);
            CustomerRepository = new CustomerRepository(context);
        }



        public int Complete()
        {
            //The number of objects written to the underlying database.
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}