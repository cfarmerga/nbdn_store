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

            //remainder of setup
            factories.Add(typeof(CommandRegistry), new AutoWiringDependencyFactory(constructor_resolver, typeof(DefaultCommandRegistry), container));
            factories.Add(typeof(FrontController), new AutoWiringDependencyFactory(constructor_resolver, typeof(DefaultFrontController), container));
            factories.Add(typeof(Mapper), new AutoWiringDependencyFactory(constructor_resolver, typeof(DefaultMapper), container));
            factories.Add(typeof(RequestFactory), new AutoWiringDependencyFactory(constructor_resolver, typeof(DefaultRequestFactory), container));
            factories.Add(typeof(ResponseEngine), new AutoWiringDependencyFactory(constructor_resolver, typeof(DefaultResponseEngine), container));
            factories.Add(typeof(ViewRegistry), new AutoWiringDependencyFactory(constructor_resolver, typeof(DefaultViewRegistry), container));

            factories.Add(typeof(CatalogBrowsingTasks), new AutoWiringDependencyFactory(constructor_resolver, typeof(StubCatalogBrowsingTasks), container));
            factories.Add(typeof(IEnumerable<RequestCommand>), new AutoWiringDependencyFactory(constructor_resolver, typeof(StubSetOfCommands), container));
            factories.Add(typeof(MapperRegistry), new AutoWiringDependencyFactory(constructor_resolver, typeof(StubMapperRegistry), container));
            factories.Add(typeof(ViewPathRegistry), new AutoWiringDependencyFactory(constructor_resolver, typeof(StubViewPathRegistry), container));
        }
    }
}