using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedikeeperAssignment.Models;
using MedikeeperAssignment.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using MedikeeperAssignment.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedikeeperAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        public IConfiguration configuration;
        private IItemsService _itemService;

        private readonly ItemService itemRepository;

        public ItemController(IItemsService service)
        {
            _itemService = service;
        }

        // GET: api/item
        [HttpGet]
        public IEnumerable<Item> GetAllItemsMaxCost()
        {
            var items = _itemService.GetAllMaxCost();

            return items;
        }

        // GET api/item/{itemName}
        [HttpGet("{itemName}")]
        public Item GetMaxCostByItemName(string itemName)
        {
            //var item = itemRepository.GetItemMaxCost(itemName);
            var item = _itemService.GetItemMaxCost(itemName);

            return item;
        }

        // POST api/item
        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {

            return Ok();
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return NotFound();
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
