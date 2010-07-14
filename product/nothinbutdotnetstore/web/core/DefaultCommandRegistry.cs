using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<WebCommand> commands;

        public WebCommand get_command_that_can_handle(Request request)
        {
            return commands.First(x => x.can_handle(request));
        }

        public DefaultCommandRegistry(IEnumerable<WebCommand> commands)
        {
            this.commands = commands;
        }
    }
}