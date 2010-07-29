 using System;
 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class RequestSpecs
     {
         public abstract class concern : Observes<Request,
                                             DefaultRequest>
         {
        
         }

         [Subject(typeof(DefaultRequest))]
         public class when_mappping_an_input_model : concern
         {
             Establish c = () =>
                               {
                                   model_mapper = the_dependency<RequestModelMapper>();

                                   model_value = 100;
                                   model_mapper.Stub(x => x.create_model_from_request<int>(request)).Return(model_value);
                               };

             Because b = () => 
                result = sut.map<int>();

             It should_return_the_model = () =>
                                          result.ShouldEqual(model_value);

             static int result;
             static int model_value;
             static RequestModelMapper model_mapper;
             static Request request;
         }
     }

     
 }
