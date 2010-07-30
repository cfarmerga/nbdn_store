using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.custom;
using nothinbutdotnetstore.web.core;

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
            factories.Add(typeof(FrontController),new AutoWiringDependencyFactory(null,typeof(DefaultFrontController),container));
        }
    }
}