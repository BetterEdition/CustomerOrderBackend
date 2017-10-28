using System.Collections.Generic;
using CustomerSystemBLL;
using CustomerSystemBLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRestAPI.Controllers
{
	[EnableCors("MyPolicy")]
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class CustomerController : Controller
	{
        IBLLFacade facade;


        public CustomerController(IBLLFacade facade)
        {
            this.facade = facade;
        }
        [HttpGet]
	    public IEnumerable<CustomerBO> Get()
	    {
	        return facade.CustomerService.GetAll();
	    }
    }
}
