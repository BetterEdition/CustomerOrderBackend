using System.Collections.Generic;
using CustomerSystemBLL;
using CustomerSystemBLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Collections;

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
        public IActionResult Get()
        {
            return Ok(new List<CustomerBO>());
        }

        [HttpGet("{Id}")]
        public CustomerBO Get(int Id)
        {
            return facade.CustomerService.Get(Id);
        }
        // POST: api/Customers
        [HttpPost]
        public IActionResult Post([FromBody]CustomerBO cust)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.CustomerService.Create(cust));
        }
    }
}
