using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.custom;
using nothinbutdotnetstore.infrastructure.stubs;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application.catalogbrowsing;
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
            Container.container_resolver = () => container;

            //remainder of setup
            var greedy_constructor_resolver = new GreedyConstructorResolver();
            factories.Add(typeof(CommandRegistry), new AutoWiringDependencyFactory(greedy_constructor_resolver, typeof(DefaultCommandRegistry), container));
            factories.Add(typeof(FrontController), new AutoWiringDependencyFactory(greedy_constructor_resolver, typeof(DefaultFrontController), container));
            factories.Add(typeof(Mapper), new AutoWiringDependencyFactory(greedy_constructor_resolver, typeof(DefaultMapper), container));
            factories.Add(typeof(RequestFactory), new AutoWiringDependencyFactory(greedy_constructor_resolver, typeof(DefaultRequestFactory), container));
            factories.Add(typeof(ResponseEngine), new AutoWiringDependencyFactory(greedy_constructor_resolver, typeof(DefaultResponseEngine), container));
            factories.Add(typeof(ViewRegistry), new AutoWiringDependencyFactory(greedy_constructor_resolver, typeof(DefaultViewRegistry), container));
            
            factories.Add(typeof(CatalogBrowsingTasks), new AutoWiringDependencyFactory(greedy_constructor_resolver, typeof(StubCatalogBrowsingTasks), container));
            factories.Add(typeof(IEnumerable<RequestCommand>), new AutoWiringDependencyFactory(greedy_constructor_resolver, typeof(StubSetOfCommands), container));
            factories.Add(typeof(MapperRegistry), new AutoWiringDependencyFactory(greedy_constructor_resolver, typeof(StubMapperRegistry), container));
            factories.Add(typeof(ViewPathRegistry), new AutoWiringDependencyFactory(greedy_constructor_resolver, typeof(StubViewPathRegistry), container));
        }

    }
        public class StubSetOfCommands : IEnumerable<RequestCommand>
        {
            public IEnumerator<RequestCommand> GetEnumerator()
            {
                yield return
                    new DefaultRequestCommand(x => x.command.Contains("ViewSubDepartments"),
                                              new ViewSubDepartmentsInADepartment(
                                                  Container.retrieve.an<CatalogBrowsingTasks>(),
                                                  Container.retrieve.an<ResponseEngine>()));
                yield return
                    new DefaultRequestCommand(x => x.command.Contains("ViewProducts"),
                                              new ViewProductsInADepartment(
                                                  Container.retrieve.an<CatalogBrowsingTasks>(),
                                                  Container.retrieve.an<ResponseEngine>()));
                yield return
                    new DefaultRequestCommand(x => true,
                                              new ViewMainDepartments(
                                                  Container.retrieve.an<CatalogBrowsingTasks>(),
                                                  Container.retrieve.an<ResponseEngine>()));
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
}