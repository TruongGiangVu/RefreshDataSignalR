using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Server.Models
{
    public class Item
    {
        public int? Id { get; set; }
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public Item()
        {

        }
        public Item(int? id, string? userId, string? name, string? description)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Description = description;
        }

        public override string? ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}