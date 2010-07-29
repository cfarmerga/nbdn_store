 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
 {   
     public class RequestFactorySpec
     {
         public abstract class concern : Observes<RequestFactory,DefaultRequestFactory>
         {
        
         }

         [Subject(typeof(RequestFactory))]
         public class when_we_need_a_request: concern
         {
             private Establish c = () =>
                                       {
                                           httpContext = contextResolver.Invoke();

                                       };
                                           
             
             private Because b = () =>
                                 request = sut.create_request_from(httpContext);


             private It should_populate_the_command_property_from_an_http_context = () =>
                                                                                        {
                                                                                            contextResolver.received(
                                                                                                x => x.Invoke());
                                                                                            request.command.
                                                                                                ShouldNotBeNull();
                                                                                        };

             private static HttpContext httpContext;
             private static Request request;
             private static CurrentContextResolver contextResolver;


         }

           
     }
 }
