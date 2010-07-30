using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class DefaultDependencyFactories : DependencyFactories
    {
        IDictionary<Type, DependencyFactory> factories;

        public DefaultDependencyFactories(IDictionary<Type, DependencyFactory> factories)
        {
            this.factories = factories;
        }

        public DependencyFactory get_dependency_factory_for(Type dependency_type)
        {
            ensure_the_dependency_factory_is_registered_for(dependency_type);
            return factories[dependency_type];
        }

        void ensure_the_dependency_factory_is_registered_for(Type dependency_type)
        {
            if (factories.ContainsKey(dependency_type)) return;

            throw new DependencyFactoryNotRegisteredException(dependency_type);

        }
    }
}