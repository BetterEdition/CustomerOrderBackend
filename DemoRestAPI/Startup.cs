using CustomerSystemBLL;
using CustomerSystemBLL.BusinessObjects;
using CustomerSystemBLL.Facade;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CustomerRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

			services.AddCors(o => o.AddPolicy("MyPolicy", builder => {
				builder.WithOrigins("http://localhost:4200")
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));

            services.AddSingleton(Configuration);
            services.AddScoped<IBLLFacade, BLLFacade>();
        
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                
                var facade = new BLLFacade(Configuration);

                var orderItem = facade.OrderItemService.Create(new OrderItemBO()
                {
                    UnitPrice = 3.5,
                    Quantity = 10,
                    
                });
                

                var order = facade.OrderService.Create(new OrderBO()
                {
                    CustomerId = 5,



                });

                var cust = facade.CustomerService.Create(
                    new CustomerBO()
                    {
                        FirstName = "dd",
                        LastName = "ff",

                    });
                var cust2 = facade.CustomerService.Create(
                    new CustomerBO()
                    {
                        FirstName = "tt",
                        LastName = "ss",

                    });
                var cust3 = facade.CustomerService.Create(
                    new CustomerBO()
                    {
                        FirstName = "dd",
                        LastName = "ee",

                    });
            

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
				loggerFactory.AddDebug();
				app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

