using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
    	private readonly IEnumerable<WebCommand> _commands;

    	public WebCommand get_command_that_can_handle(Request request)
        {
            return (from c in _commands
							 where c.can_handle(request)
							 select c).
    		Single();
        }
	  public DefaultCommandRegistry(IEnumerable<WebCommand> commands)
	  {
	  	_commands = commands;
	  }
    }
}