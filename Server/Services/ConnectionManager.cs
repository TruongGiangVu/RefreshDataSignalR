using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Server.Models;

namespace Server.Services
{
    public class ConnectionManager
    {
        public static ConcurrentDictionary<string, string> ConnectedUsers = new ConcurrentDictionary<string, string>();
        public static bool Add(string userid, string connectionId){
            Console.WriteLine($"Add ConnectedId:{connectionId} userid:{userid}");
            bool ret = ConnectedUsers.TryAdd(connectionId, userid);
            return ret;
        }
        public static bool Remove(string connectionId){
            string garbage = "";
            Console.WriteLine($"Remove ConnectedId:{connectionId} userid:{garbage}");
            bool ret = ConnectedUsers.TryRemove(connectionId, out garbage!);
            Console.WriteLine($"Remove ConnectedId:{connectionId} garbage:{garbage}");
            return ret;
        }
        public static List<(string connectionId, string userid)> Get(){
            List<(string connectionId, string userid)> data = new();
            foreach( KeyValuePair<string, string> item in ConnectedUsers ){
                data.Add((item.Key, item.Value));
            }
            return data;
        }
    }
}