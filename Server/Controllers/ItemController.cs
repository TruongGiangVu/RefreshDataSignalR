using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Server.Hubs;
using Server.Models;
using Server.Repositories;
using Server.Services;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IHubContext<ItemHub> hub;

        public ItemController(IHubContext<ItemHub> hub)
        {
            this.hub = hub;
        }
        public IActionResult RunJob(){
            return Ok();
        }
        [HttpGet()]
        public IActionResult Get(string? userid){
            ItemRepository repository = new();
            return Ok(repository.Get(userid));
        }
        [HttpGet("ConnectedUser")]
        public IActionResult GetConnectedUser(){
            return Ok(ConnectionManager.ConnectedUsers);
        }
        [HttpPost()]
        public IActionResult CreateItem([FromBody] Item item){
            ItemRepository repository = new();
            repository.Create(item);
            this.RefreshData(item.UserId!);
            return Ok("00");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Item item){
            ItemRepository repository = new();
            repository.Update(id, item);
            this.RefreshData(item.UserId!);
            return Ok("00");
        }
        private void RefreshData(string userId){
            ItemRepository repository = new();
            hub.Clients.All.SendAsync("refreshData", repository.Get(userId));
        }
    }
}