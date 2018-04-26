using System;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
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
        [DataMember]
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Address { get; private set; }
    }
}