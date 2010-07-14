using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        public WebCommand get_command_that_can_handle(Request request)
        {
            throw new NotImplementedException();
        }
    }
}