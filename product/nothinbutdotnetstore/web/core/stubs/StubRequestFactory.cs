using System;
using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext http_context)
        {
            return new StubRequest(http_context);
        }

        class StubRequest : Request
        {
            readonly HttpContext http_context;

            public StubRequest(HttpContext http_context)
            {
                this.http_context = http_context;
            }

            public InputModel map<InputModel>()
            {
                return Activator.CreateInstance<InputModel>();
            }

            public string raw_command
            {
                get { return http_context.Request.RawUrl; }
            }
        }
    }
}