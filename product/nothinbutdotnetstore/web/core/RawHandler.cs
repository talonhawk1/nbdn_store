using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class RawHandler : IHttpHandler
    {
        private readonly FrontController frontController;
        private readonly RequestFactory requestFactory;

        public RawHandler(FrontController frontController, RequestFactory requestFactory)
        {
            this.frontController = frontController;
            this.requestFactory = requestFactory;
        }

        public void ProcessRequest(HttpContext context)
        {
            var request = requestFactory.create_from(context);
            frontController.process(request);
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}