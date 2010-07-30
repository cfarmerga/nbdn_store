 using System.Data;
 using System.Reflection;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers.custom;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class ConstructorResolverSpecs
     {
         public abstract class concern : Observes<ConstructorResolver,
                                             GreedyConstructorResolver>
         {
        
         }

         [Subject(typeof(GreedyConstructorResolver))]
         public class when_retrieving_an_applicable_constructor : concern
         {
             Because b = () =>
                 chosen_ctor = sut.get_applicable_constructor_on(typeof(MyObj));

             It should_choose_the_constructor_with_the_most_arguments = () =>
                 chosen_ctor.GetParameters().Length.ShouldEqual(3);

             static ConstructorInfo chosen_ctor;
         }

         class MyObj
         {
             IDbCommand command;
             IDbConnection connection;
             IDbDataAdapter data_adapter;

             public MyObj(IDbCommand command)
             {
                 this.command = command;
             }

             public MyObj(IDbCommand command, IDbConnection connection)
             {
                 this.command = command;
                 this.connection = connection;
             }

             public MyObj(IDbCommand command, IDbConnection connection, IDbDataAdapter data_adapter)
             {
                 this.command = command;
                 this.connection = connection;
                 this.data_adapter = data_adapter;
             }
         }
     }
 }
