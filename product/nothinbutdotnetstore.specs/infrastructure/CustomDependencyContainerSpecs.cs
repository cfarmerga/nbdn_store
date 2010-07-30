 using System.Collections.Generic;
 using System.Data;
 using System.Data.SqlClient;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers;
 using nothinbutdotnetstore.infrastructure.containers.custom;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class CustomDependencyContainerSpecs
     {
         public abstract class concern : Observes<DependencyContainer,
                                             CustomDependencyContainer>
         {
        
         }

         [Subject(typeof(CustomDependencyContainer))]
         public class when_retrieving_an_instance_of_a_dependency_and_it_is_able_to_resolve_that_dependency : concern
         {

             Establish c = () =>
             {
                 dependency_factory_registry = the_dependency<DependencyFactories>();
                 factory =an<DependencyFactory>();

                 connection = new SqlConnection();
                 factory.Stub(x => x.create()).Return(connection);
                 dependency_factory_registry.Stub(x => x.get_dependency_factory_for(typeof(IDbConnection))).Return(factory);
             };

             Because b = () =>
                 result = an<IDbConnection>();

             It should_return_the_dependency_created_using_the_dependency_factory = () =>
                 result.ShouldEqual(connection);

             static IDbConnection result;
             static IDbConnection connection;
             static DependencyFactories dependency_factory_registry;
             static DependencyFactory factory;
         }
     }
 }
