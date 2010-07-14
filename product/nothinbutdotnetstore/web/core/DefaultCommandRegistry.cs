using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<WebCommand> commands;

        public WebCommand get_command_that_can_handle(Request request)
        {
            foreach (WebCommand webCommand in commands) {
                if (webCommand.can_handle(request)) {
                    return webCommand;
                }
            }
            return new MissingWebCommand();
        }

        public DefaultCommandRegistry(IEnumerable<WebCommand> commands)
        {
            this.commands = commands;
        }
    }
}