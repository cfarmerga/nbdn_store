using System;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class AutoWiringDependencyFactory : DependencyFactory
    {
        ConstructorResolver constructor_resolver;
        Type type;
        DependencyContainer container;

        public AutoWiringDependencyFactory(ConstructorResolver constructor_resolver, Type type, DependencyContainer container)
        {
            this.constructor_resolver = constructor_resolver;
            this.type = type;
            this.container = container;
        }

        public object create()
        {
            var constructor = constructor_resolver.get_applicable_constructor_on(type);

            var ctor_params = constructor
                .GetParameters()
                .Select(constructor_parameter => container.an(constructor_parameter.ParameterType));

            return constructor.Invoke(ctor_params.ToArray());
        }
    }
}