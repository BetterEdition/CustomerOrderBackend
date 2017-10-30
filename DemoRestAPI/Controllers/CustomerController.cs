using System;
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

        [HttpGet("{Id}")]
        public CustomerBO Get(int Id)
        {
            return facade.CustomerService.Get(Id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.CustomerService.Delete(id);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CustomerBO cust)
        {
            if (id != cust.Id)
            {
                return StatusCode(405, "Path Id does not match Customer ID in JSON object");
            }
            try
            {
                return Ok(facade.CustomerService.Update(cust));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }

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
