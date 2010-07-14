using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultFrontController : FrontController
    {
        private CommandRegistry CommandRegistry;

        public DefaultFrontController(CommandRegistry commandRegistry)
        {
            this.CommandRegistry = commandRegistry;    
        }

        public void process(Request request)
        {
            var command = CommandRegistry.get_command_that_can_handle(request);
            command.process(request);
        }
    }
}