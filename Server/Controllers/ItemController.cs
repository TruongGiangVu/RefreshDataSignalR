using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        public ItemController()
        {
            
        }
        [HttpGet()]
        public IActionResult Get(string? userid){
            ItemRepository repository = new();
            return Ok(repository.Get(userid));
        }
        [HttpPost()]
        public IActionResult CreateItem([FromBody] Item item){
            ItemRepository repository = new();
            repository.Create(item);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Item item){
            ItemRepository repository = new();
            repository.Update(id, item);
            return Ok();
        }
    }
}