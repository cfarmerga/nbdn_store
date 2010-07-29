using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class ContainerSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Container))]
        public class when_providing_access_to_the_underlying_container_behaviour : concern
        {
            Establish c = () =>
            {
                the_container = an<DependencyContainer>();
                resolver = () => the_container;

                change(() => Container.container_resolver).to(resolver);
            };

            Because b = () =>
                result = Container.retrieve;

            It should_return_the_gateway_to_the_container_services = () =>
                result.ShouldEqual(the_container);

            static DependencyContainer result;
            static DependencyContainer the_container;
            static ContainerResolver resolver;
        }
    }
}