using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class RawHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}