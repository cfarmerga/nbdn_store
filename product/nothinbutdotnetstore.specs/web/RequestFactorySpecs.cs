using System.Collections.Specialized;
using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestFactorySpecs
    {
        public abstract class concern : Observes<RequestFactory, DefaultRequestFactory>
        {
        }

        [Subject(typeof(RequestFactory))]
        public class when_creating_a_request_from_an_http_context : concern
        {
            Establish c = () =>
            {
                url = "http://localhost/blah.aspx";
                http_context = ObjectMother.create_http_context()
                    .to_target(url);
                the_mapper = the_dependency<Mapper>();
            };

            Because b = () =>
                request = sut.create_request_from(http_context);

            It should_create_the_request_based_on_the_original_http_context = () =>
            {
                var actual_request = request.ShouldBeAn<DefaultRequest>();
                actual_request.command.ShouldEndWith("blah.aspx");
                actual_request.mapper.ShouldEqual(the_mapper);
                actual_request.payload.ShouldEqual(http_context.Request.Params);
            };

            static HttpContext http_context;
            static Request request;
            static string url;
            static NameValueCollection the_payload;
            static Mapper the_mapper;
        }
    }
}