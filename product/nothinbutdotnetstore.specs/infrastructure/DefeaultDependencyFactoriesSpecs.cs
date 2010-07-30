 using System;
 using System.Collections.Generic;
 using System.Data;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers.custom;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class DefeaultDependencyFactoriesSpecs
     {
         public abstract class concern : Observes<DependencyFactories,
                                             DefaultDependencyFactories>
         {

             Establish c = () =>
             {
                 the_factory = an<DependencyFactory>();
                 factories = new Dictionary<Type,DependencyFactory>();
                 provide_a_basic_sut_constructor_argument(factories);
             };

             protected static DependencyFactory the_factory;
             protected static IDictionary<Type, DependencyFactory> factories;
         }

         [Subject(typeof(DefaultDependencyFactories))]
         public class when_getting_the_dependency_factory_for_a_type_and_it_has_the_factory : concern
         {

             Establish c = () =>
             {
                 factories.Add(typeof(IDbConnection),the_factory);
             };

             Because b = () =>
                 result = sut.get_dependency_factory_for(typeof(IDbConnection));

             It should_return_the_dependency_factory_for_the_type = () =>
                 result.ShouldEqual(the_factory);

             static DependencyFactory result;
         }

         [Subject(typeof(DefaultDependencyFactories))]
         public class when_getting_the_dependency_factory_for_a_type_and_it_does_not_have_the_factory : concern
         {

             Because b = () =>
                 catch_exception(() => sut.get_dependency_factory_for(typeof(IDbConnection)));


             It should_throw_a_dependency_factory_not_registered_exception = () =>
             {
                 var item = exception_thrown_by_the_sut.ShouldBeAn<DependencyFactoryNotRegisteredException>();
                 item.type_that_has_no_factory.ShouldEqual(typeof(IDbConnection));
             };


         }
     }
 }
