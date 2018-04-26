using System;
using System.Collections.Generic;
using System.Linq;

namespace QM.Server.Api.Controller
{
    public static class ServerRepository
    {
        private static List<Entity.Server> servers;

        static ServerRepository()
        {
            Initialize();
        }

        private static void Initialize()
        {
            servers = new List<Entity.Server>();
            servers.Add(new Entity.Server("localhost", "http://localhost:28682/"));
        }

        public static Entity.Server Lookup(string name)
        {
            return servers.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static IReadOnlyList<Entity.Server> LookupAll()
        {
            return servers;
        }
    }
}