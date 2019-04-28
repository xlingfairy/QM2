using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    
    public class Server
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public Server(string name, string address)
        {
            Name = name;
            Address = address;
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
