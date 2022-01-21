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
        // Gets a list of the full inventory for a store based off of store id. Uses a zip method to join product and inventory tables
        [HttpGet("{id}")]
        public ActionResult Get(int id)
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
        // Add a product, add that product to the inventory
        [HttpPost]
        public ActionResult Post([FromBody] Product productToAdd)
        {
            if (productToAdd.ProductName != null)
            {
                _bl.AddProduct(productToAdd);
                return Created($"{productToAdd.ProductName} has been added to the product list!", productToAdd);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpPost("{prodId}/{storeId}/{quantity}")]
        public ActionResult Post(int prodId, int storeId, int quantity)
        {
            if(storeId != 0)
            {
                _bl.AddProductToInventory(prodId, storeId, quantity);
                return Created($"Your product has been added to the inventory for store #{storeId}!", prodId);
            }
            else
            {
                return NoContent();
            }
        }

        // PUT api/<InventoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bl.RemoveProduct(id);
        }
    }
}
