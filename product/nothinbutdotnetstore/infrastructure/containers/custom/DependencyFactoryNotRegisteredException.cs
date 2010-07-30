using System;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class DependencyFactoryNotRegisteredException: Exception
    {
        public Type type_that_has_no_factory { get; private set; }

        public DependencyFactoryNotRegisteredException(Type dependency_type)
        {
            this.type_that_has_no_factory = dependency_type;
        }
    }
}