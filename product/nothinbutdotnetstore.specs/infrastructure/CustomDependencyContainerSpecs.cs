 using System;
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
             Establish c = () =>
             {
                 factory =an<DependencyFactory>();
                 dependency_factory_registry = the_dependency<DependencyFactories>();
                 dependency_factory_registry.Stub(x => x.get_dependency_factory_for(typeof(IDbConnection))).Return(factory);
             };

             protected static DependencyFactories dependency_factory_registry;
             protected static DependencyFactory factory;

         }

         [Subject(typeof(CustomDependencyContainer))]
         public class when_retrieving_an_instance_of_a_dependency_and_it_is_able_to_resolve_that_dependency : concern
         {

             Establish c = () =>
             {
                 connection = new SqlConnection();
                 factory.Stub(x => x.create()).Return(connection);
             };

             Because b = () =>
                 result = sut.an<IDbConnection>();

             It should_return_the_dependency_created_using_the_dependency_factory = () =>
                 result.ShouldEqual(connection);

             static IDbConnection result;
             static IDbConnection connection;
         }

         [Subject(typeof(CustomDependencyContainer))]
         public class when_retrieving_an_instance_of_a_dependency_non_generically : concern
         {

             Establish c = () =>
             {
                 connection = new SqlConnection();
                 factory.Stub(x => x.create()).Return(connection);
             };

             Because b = () =>
                 result = sut.an(typeof(IDbConnection));

             It should_return_the_dependency_created_using_the_dependency_factory = () =>
                 result.ShouldEqual(connection);

             static object result;
             static IDbConnection connection;
         }

         [Subject(typeof(CustomDependencyContainer))]
         public class when_retrieving_a_dependency_and_the_factory_for_the_dependency_throws_an_exception : concern
         {

             Establish c = () =>
             {
                 inner_exception = new Exception();
                 factory.Stub(x => x.create()).Throw(inner_exception);
             };

             Because b = () =>
                 catch_exception(() => sut.an<IDbConnection>());

             It should_throw_a_dependency_creation_exception_with_the_appropriate_information = () =>
             {
                 var creation_exception = exception_thrown_by_the_sut.ShouldBeAn<DepedencyCreationException>();
                 creation_exception.InnerException.ShouldEqual(inner_exception);
                 creation_exception.type_that_could_not_be_created.ShouldEqual(typeof(IDbConnection));
             };

             static Exception inner_exception;
         }
     }
 }
