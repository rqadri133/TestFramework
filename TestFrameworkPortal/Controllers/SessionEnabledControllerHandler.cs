using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Http.WebHost;
using System.Web.Routing;

namespace TestFrameworkPortal.Controllers
{
    // Enbaling Session in Web API 
    // very rare to use but could passed encrypted value between sessions 


    public class SessionEnabledControllerHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionEnabledControllerHandler(RouteData routeData)
            : base(routeData)
        { }
    }

    public class SessionEnabledHttpControllerRouteHandler : HttpControllerRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new SessionEnabledControllerHandler(requestContext.RouteData);
        }
    }


}