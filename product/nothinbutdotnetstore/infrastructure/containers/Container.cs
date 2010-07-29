using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class Container
    {
        public static readonly ContainerResolver container_resolver =
            delegate { throw new NotImplementedException("This needs to be configured at application startup"); };

        public static DependencyContainer retrieve
        {
            get { return container_resolver(); }
        }
    }
}