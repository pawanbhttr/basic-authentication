using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BasicAuthDemo.API.Attributes
{
    public class CheckIPAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var whiteListedIPs = ConfigurationManager.AppSettings["WhiteListedIPAddresses"];
            if (!string.IsNullOrWhiteSpace(whiteListedIPs))
            {
                var whiteListIPList = whiteListedIPs.Split(',').ToList();
                var ipAddressString = HttpContext.Current.Request.UserHostAddress.ToString();
                var ipAddress = IPAddress.Parse(ipAddressString);
                var isInwhiteListIPList =
                        whiteListIPList
                            .Where(a => a.Trim()
                            .Equals(ipAddressString, StringComparison.InvariantCultureIgnoreCase))
                            .Any();
                if (!isInwhiteListIPList)
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
            }
            base.OnActionExecuting(actionContext);
        }
    }
}