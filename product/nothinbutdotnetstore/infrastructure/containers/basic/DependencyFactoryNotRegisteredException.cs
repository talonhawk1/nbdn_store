using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DependencyFactoryNotRegisteredException : Exception
    {
        public const string ERROR_MESSAGE_FORMAT = "The type {0} has no dependency factory registered";

        public DependencyFactoryNotRegisteredException(Type type_that_has_no_factory):base(string.Format(ERROR_MESSAGE_FORMAT,type_that_has_no_factory.Name))
        {
            this.type_that_has_no_factory = type_that_has_no_factory;
        }

        public Type type_that_has_no_factory { get; private set; }
    }
}