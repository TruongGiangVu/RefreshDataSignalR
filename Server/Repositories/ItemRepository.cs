using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Repositories
{
    public class ItemRepository
    {
        static private List<Item> storage = new(){
            new Item(1,"giang","Test1", "fsdfsdf"),
            new Item(2,"admin","Test2", "fsdfsdf"),
            new Item(3,"admin","Test3", "fsdfsdf"),
            new Item(4,"giang","Test4", "fsdfsdf"),
            new Item(5,"giang","Test5", "fsdfsdf"),
        };
        public ItemRepository()
        {

        }
        public List<Item> Get(string? userid) => string.IsNullOrEmpty(userid) ? storage : storage.Where(p => p.UserId == userid).ToList();
        public bool Create(Item item)
        {
            storage.Add(item);
            return true;
        }
        public bool Update(int id, Item item)
        {
            var index = storage.FindIndex(r => r.Id == id);
            if (index >= 0)
                storage[index] = item;
            return index >= 0 ? true : false;
        }

    }
}