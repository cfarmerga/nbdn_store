using System;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class SingletonDependencyFactory : DependencyFactory
    {
        DependencyFactory base_factory;
        object cached;

        public SingletonDependencyFactory(DependencyFactory base_factory)
        {
            this.base_factory = base_factory;
        }

        public object create()
        {
            return cached ?? (cached = base_factory.create());
        }
    }
}