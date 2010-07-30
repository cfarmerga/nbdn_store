using System;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class DefaultDependencyFactory : DependencyFactory
    {
        Func<object> how_to_create;

        public DefaultDependencyFactory(Func<object> how_to_create)
        {
            this.how_to_create = how_to_create;
        }

        public object create()
        {
            return how_to_create();
        }
    }
}