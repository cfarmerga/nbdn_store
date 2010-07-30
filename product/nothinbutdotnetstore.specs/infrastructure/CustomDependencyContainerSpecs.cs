 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers;
 using nothinbutdotnetstore.infrastructure.containers.custom;

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
        
             It first_observation = () =>        
                 
         }
     }
 }
