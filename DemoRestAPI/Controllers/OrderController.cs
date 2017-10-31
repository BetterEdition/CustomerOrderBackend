using System;
using System.Collections.Generic;
using CustomerSystemBLL;
using CustomerSystemBLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DemoRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        IBLLFacade facade;


        public OrderController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]
        public IEnumerable<OrderBO> GetAll()
        {
            return facade.OrderService.GetAll();
        }

        [HttpGet("{Id}")]
        public OrderBO Get(int Id)
        {
            return facade.OrderService.Get(Id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.OrderService.Delete(id);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OrderBO order)
        {
            if (id != order.Id)
            {
                return StatusCode(405, "Path Id does not match the Order ID in JSON object");
            }
            try
            {
                return Ok(facade.OrderService.Update(order));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }

        }


        // POST: api/orders
        [HttpPost]
        public IActionResult Post([FromBody]OrderBO order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.OrderService.Create(order));
        }

    }
}
