using System;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public interface DependencyFactories
    {
        DependencyFactory get_dependency_factory_for(Type dependency_type);
    }
}