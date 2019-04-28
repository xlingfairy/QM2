using System;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    
    public class ServerHeaderDto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        public ServerHeaderDto(Server server)
        {
            Name = server.Name;
            Address = server.Address;
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string Address { get; private set; }
    }
}