using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers.custom;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class SingletonDependencyFactorySpecs
    {
        public abstract class concern : Observes<DependencyFactory,
                                            DefaultDependencyFactory>
        {
        }

        [Subject(typeof(DefaultDependencyFactory))]
        public class when_creating_multiple_instances_of_the_dependency : concern
        {
            Establish c =
                () =>
                {
                    Func<object> factory = () => new OurItem();

                    provide_a_basic_sut_constructor_argument(
                        factory.cache_result());

                };

            Because b = () =>
            {
                first_result = sut.create();
                second_result = sut.create();
            };

            It should_return_the_same_instance_each_time = () =>
                first_result.Equals(second_result).ShouldBeTrue();

            static object first_result;
            static object second_result;
        }

        class OurItem
        {
        }
    }
}