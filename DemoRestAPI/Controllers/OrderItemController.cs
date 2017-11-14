using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSystemBLL;
using CustomerSystemBLL.BusinessObjects;
using CustomerSystemDAL.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DemoRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderItemController : Controller
    {
        IBLLFacade facade;


        public OrderItemController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]
        public IEnumerable<OrderItemBO> GetAll()
        {
            return facade.OrderItemService.GetAll();
        }

        [HttpGet("{Id}")]
        public OrderItemBO Get(int Id)
        {
            return facade.OrderItemService.Get(Id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.OrderItemService.Delete(id);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OrderItemBO orderItem)
        {
            if (id != orderItem.Id)
            {
                return StatusCode(405, "Path Id does not match the Order ID in JSON object");
            }
            try
            {
                return Ok(facade.OrderItemService.Update(orderItem));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }

        }


        // POST: api/orders
        [HttpPost]
        public IActionResult Post([FromBody]OrderItemBO orderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.OrderItemService.Create(orderItem));
        }

    }
}
