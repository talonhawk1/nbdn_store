using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext http_context)
        {
            throw new NotImplementedException();
        }
    }
}