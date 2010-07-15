using System;
using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext http_context)
        {
            return new StubRequest();
        }

        class StubRequest : Request
        {
            public string get_query_string()
            {
                throw new NotImplementedException();
            }

            public string get_value_for(string input_element_key)
            {
                throw new NotImplementedException();
            }
        }
    }
}