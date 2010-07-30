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

            Dictionary<Type, Type> graph = new Dictionary<Type, Type>();

            graph.Add(typeof(CommandRegistry), typeof(DefaultCommandRegistry));
            graph.Add(typeof(FrontController), typeof(DefaultFrontController));
            graph.Add(typeof(Mapper), typeof(DefaultMapper));
            graph.Add(typeof(RequestFactory), typeof(DefaultRequestFactory));
            graph.Add(typeof(ResponseEngine), typeof(DefaultResponseEngine));
            graph.Add(typeof(ViewRegistry), typeof(DefaultViewRegistry));
            graph.Add(typeof(CatalogBrowsingTasks), typeof(StubCatalogBrowsingTasks));
            graph.Add(typeof(IEnumerable<RequestCommand>), typeof(StubSetOfCommands));
            graph.Add(typeof(MapperRegistry), typeof(StubMapperRegistry));
            graph.Add(typeof(ViewPathRegistry), typeof(StubViewPathRegistry));

            foreach (var typeMap in graph)
            {
                factories.Add(typeMap.Key, new AutoWiringDependencyFactory(constructor_resolver, typeMap.Value, container));
            }
        
        }
    }
}