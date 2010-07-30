using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.custom;
using nothinbutdotnetstore.infrastructure.stubs;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        public static void run()
        {
            IDictionary<Type, DependencyFactory> factories = new Dictionary<Type, DependencyFactory>();
            var container = new CustomDependencyContainer(new DefaultDependencyFactories(factories));
            var constructor_resolver = new GreedyConstructorResolver();
            Container.container_resolver = () => container;

            Action<Type, Type> add_factory_to_dependency_factories =
                (contract_type, implementation_type) =>
                factories.Add(contract_type,
                              new AutoWiringDependencyFactory(constructor_resolver, implementation_type, container));


           
            add_factory_to_dependency_factories(typeof(CommandRegistry), typeof(DefaultCommandRegistry));
            add_factory_to_dependency_factories(typeof(FrontController), typeof(DefaultFrontController));
            add_factory_to_dependency_factories(typeof(Mapper), typeof(DefaultMapper));
            add_factory_to_dependency_factories(typeof(RequestFactory), typeof(DefaultRequestFactory));
            add_factory_to_dependency_factories(typeof(ResponseEngine), typeof(DefaultResponseEngine));
            add_factory_to_dependency_factories(typeof(ViewRegistry), typeof(DefaultViewRegistry));
            add_factory_to_dependency_factories(typeof(CatalogBrowsingTasks), typeof(StubCatalogBrowsingTasks));
            add_factory_to_dependency_factories(typeof(IEnumerable<RequestCommand>), typeof(StubSetOfCommands));
            add_factory_to_dependency_factories(typeof(MapperRegistry), typeof(StubMapperRegistry));
            add_factory_to_dependency_factories(typeof(ViewPathRegistry), typeof(StubViewPathRegistry));

        
        }
    }
}