 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
 {   
     public class RequestSpecs
     {
         public abstract class concern : Observes<Request,
                                             DefaultRequest>
         {
        
         }

         [Subject(typeof(DefaultRequest))]
         public class when_observation_name : concern
         {
        
             It first_observation = () =>        
                 
         }
     }
 }
