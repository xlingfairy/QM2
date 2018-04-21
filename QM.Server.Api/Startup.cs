using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace QM.Server.Api
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {

            // Configure Web API for self-host. 
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;

            config.EnableCors();

            app.UseWebApi(config);
            config.EnsureInitialized();
        }

    }
}
