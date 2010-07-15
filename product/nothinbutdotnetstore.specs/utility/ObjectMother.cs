using System;
using System.IO;
using System.Web;

namespace nothinbutdotnetstore.specs.utility
{
    public class ObjectMother
    {
        public static HttpContext create_http_context()
        {
            return new HttpContext(create_request(), create_response());
        }

        static HttpResponse create_response()
        {
            return new HttpResponse(new StringWriter());
        }

        public static RequestBuilder create_request()
        {
            return new RequestBuilder();
        }

        public class RequestBuilder
        {
            string query_string = string.Empty;

            public static implicit operator HttpRequest(RequestBuilder builder)
            {
                return new HttpRequest("blah.aspx", "http://localhost/blah.aspx", builder.query_string);
            }

            public RequestBuilder with_query_string(string format)
            {
                query_string = format;
                return  this;
            }
        }
    }
}