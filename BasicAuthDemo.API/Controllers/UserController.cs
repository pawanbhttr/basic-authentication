using BasicAuthDemo.API.Attributes;
using System.Collections.Generic;
using System.Web.Http;

namespace BasicAuthDemo.API.Controllers
{
    [BasicAuthentication]
    public class UserController : ApiController
    {
        // GET api/<controller>
        [CheckIP]
        public string Get()
        {
            return "Basic Auth With IP Check Successfull";
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "Basic Auth Only Successfull";
        }
    }
}