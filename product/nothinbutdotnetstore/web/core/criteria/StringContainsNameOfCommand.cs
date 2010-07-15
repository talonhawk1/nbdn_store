namespace nothinbutdotnetstore.web.core.criteria
{
    public class StringContainsNameOfCommand
    {
        string actual_command_name;

        public StringContainsNameOfCommand(string actual_command_name)
        {
            this.actual_command_name = actual_command_name;
        }

        public bool matches(Request request)
        {
            return request.raw_command.Contains(actual_command_name);
        }
    }
}