using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DependencyCreationException : Exception
    {
        public DependencyCreationException(string message, Exception innerException, Type type_that_could_not_be_created) : base(message, innerException)
        {
            this.type_that_could_not_be_created = type_that_could_not_be_created;
        }

        public Type type_that_could_not_be_created { get; private set; }
    }
}