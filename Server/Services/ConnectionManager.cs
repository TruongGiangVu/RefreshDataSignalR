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
        public static ConcurrentDictionary<string, List<string>> ConnectedUsers = new ConcurrentDictionary<string, List<string>>();
        public static bool Add(string userid, string connectionId){
            Console.WriteLine($"Add userid:{userid} ConnectedId:{connectionId} ");
            bool ret;
            List<string> existingUserConnectionIds;
            ConnectedUsers.TryGetValue(userid, out existingUserConnectionIds!);

            // happens on the very first connection from the user
            if(existingUserConnectionIds == null || existingUserConnectionIds.Count <=0)
            {
                existingUserConnectionIds = new List<string>();
            }

            // First add to a List of existing user connections (i.e. multiple web browser tabs)
            existingUserConnectionIds.Add(connectionId);

            
            // Add to the global dictionary of connected users
            ret = ConnectedUsers.TryAdd(userid, existingUserConnectionIds);

            return ret;
        }
        public static bool Remove(string connectionId){
            bool ret = false;
            string userid = GetUserId(connectionId)??"";
            List<string> existingUserConnectionIds;
            ConnectedUsers.TryGetValue(userid, out existingUserConnectionIds!);

            // remove the connection id from the List 
            existingUserConnectionIds?.Remove(connectionId);

            // If there are no connection ids in the List, delete the user from the global cache (ConnectedUsers).
            if(existingUserConnectionIds?.Count == 0)
            {
                // if there are no connections for the user,
                // just delete the userName key from the ConnectedUsers concurent dictionary
                List<string> garbage; // to be collected by the Garbage Collector
                ret = ConnectedUsers.TryRemove(userid, out garbage!);
                Console.WriteLine($"Remove ConnectedId:{connectionId} userid:{garbage}");
            }
            return ret;
        }
        public static List<(string userid, List<string> connectionIds)> Get(){
            List<(string, List<string>)> data = new();
            foreach( KeyValuePair<string, List<string>> item in ConnectedUsers ){
                data.Add((item.Key, item.Value));
            }
            return data;
        }
        public static List<string>? GetConnectedId(string userid){
            return ConnectedUsers[userid];
        }
        public static string? GetUserId(string connectionId){
            var userid = ConnectedUsers.Where(entry => entry.Value.Any(p => p == connectionId))
              .Select(entry => entry.Key).FirstOrDefault();
            return userid;
        }
    }
}