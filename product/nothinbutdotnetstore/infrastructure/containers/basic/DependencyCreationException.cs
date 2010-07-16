using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DependencyCreationException : Exception
    {
        public const string ERROR_MESSAGE_FORMAT = "The type {0} could not be created properly";

        public Type type_that_could_not_be_created { get; private set; }

        public DependencyCreationException(Exception innerException, Type type_that_could_not_be_created) : base(string.Format(ERROR_MESSAGE_FORMAT,type_that_could_not_be_created), innerException)
        {
            this.type_that_could_not_be_created = type_that_could_not_be_created;
        }
    }
}