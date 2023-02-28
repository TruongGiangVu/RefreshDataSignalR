using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        public ItemController()
        {
            
        }
        [HttpPost("create")]
        public IActionResult CreateItem([FromBody] Item item){
            return Ok();
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateItem(int? id, [FromBody] Item item){
            return Ok();
        }
    }
}