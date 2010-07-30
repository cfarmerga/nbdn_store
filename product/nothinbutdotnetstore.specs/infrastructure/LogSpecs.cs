 
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.logging;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class LogSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(Log))]
        public class when_providing_access_to_the_underlying_logging_api : concern
        {
            Establish c = () =>
            {
                the_logger = an<Logger>();
                logger_factory = an<LoggerFactory>();
                container = an<DependencyContainer>();

                container.Stub(x => x.an<LoggerFactory>()).Return(logger_factory);

                logger_factory.Stub(
                    x => x.get_logger_bound_to(typeof(when_providing_access_to_the_underlying_logging_api))).Return(
                        the_logger);

                ContainerResolver container_resolver = () => container;

                change(() => Container.container_resolver).to(container_resolver);

            };

            Because b = () =>
                result = Log.an;

            It should_return_the_logging_api_bound_to_the_type_that_requested_logging = () =>
                result.ShouldEqual(the_logger);


            static Logger result;
            static Logger the_logger;
            static DependencyContainer container;
            static LoggerFactory logger_factory;
        }
    }
}
