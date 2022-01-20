using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IBL _bl;
        public InventoryController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<InventoryController>
        [HttpGet]
        public List<Inventory> Get()
        {
            return _bl.GetAllInventories();
        }

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public ActionResult<List<Inventory>> Get(int id)
        {
            List<Inventory> currentInventory = _bl.GetInventoryByStoreId(id);
            List<Product> currentProducts = _bl.GetAllProductsByStoreId(id);
            var prodInventory = currentProducts.Zip(currentInventory, (p, i) => new { Product = p, Inventory = i });
            
            if (prodInventory != null)
            {
                return Ok(prodInventory);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<InventoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InventoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
