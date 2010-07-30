using System;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class CustomDependencyContainer : DependencyContainer
    {
        DependencyFactories dependency_factories;

        public CustomDependencyContainer(DependencyFactories dependency_factories)
        {
            this.dependency_factories = dependency_factories;
        }

        public Dependency an<Dependency>()
        {
            return (Dependency) an(typeof(Dependency));
        }

        public object an(Type dependency_type)
        {
            try
            {
                return dependency_factories.get_dependency_factory_for(dependency_type).create();
            }
            catch (Exception e)
            {
                throw new DepedencyCreationException(e, dependency_type);
            }
        }
    }
}