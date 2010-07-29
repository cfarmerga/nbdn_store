using System.Collections.Specialized;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
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
                model_mapper = the_dependency<Mapper>();
                payload = new NameValueCollection();
                model_value = new OurMappedModel();
                model_mapper.Stub(x => x.map<NameValueCollection,OurMappedModel>(payload)).Return(model_value);

                provide_a_basic_sut_constructor_argument(payload);
                provide_a_basic_sut_constructor_argument("sdfsd");
            };

            Because b = () =>
                result = sut.map<OurMappedModel>();

            It should_return_the_model_mapped_from_the_payload = () =>
                result.ShouldEqual(model_value);

            static OurMappedModel result;
            static OurMappedModel model_value;
            static Mapper model_mapper;
            static NameValueCollection payload;
        }
    class OurMappedModel
    {
    }
    }

}