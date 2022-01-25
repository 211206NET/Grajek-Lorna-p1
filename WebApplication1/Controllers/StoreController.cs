﻿using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase 
    {
        private IBL _bl;
        private IMemoryCache _memoryCache;
        public StoreController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<StoreController>
        [HttpGet]
        public List<Storefront> Get()
        {
            //List<Storefront> allStores = _bl.GetAllStores();
            //_memoryCache.Set("storefront", allStores, new TimeSpan(0,0,30));
            return _bl.GetAllStores();
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public ActionResult<Storefront> Get(int id)
        {
            Storefront foundStore = _bl.GetStorefrontById(id);
            if(foundStore.StoreID != 0)
            {
                return Ok(foundStore);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<StoreController>
        [HttpPost]
        public ActionResult Post([FromBody] Storefront storetoAdd)
        {
            _bl.AddStore(storetoAdd);
            return Created("Successfully Added!", storetoAdd);
        }
    }
}
