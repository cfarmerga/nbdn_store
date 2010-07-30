using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers.custom;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class DefaultDependencyFactorySpecs
    {
        public abstract class concern : Observes<DependencyFactory,
                                            DefaultDependencyFactory>
        {
        }

        [Subject(typeof(DefaultDependencyFactory))]
        public class when_creating_a_dependency : concern
        {
            Establish c = () =>
            {
                obj_to_return = new object();

                Func<object> how_to_create_dependency = () =>
                {
                    was_called = true;
                    return obj_to_return;
                };

                provide_a_basic_sut_constructor_argument(how_to_create_dependency);
            };

            Because b = () =>
                actual_result = sut.create();

            It should_use_the_method_given_during_construction = () =>
            {
                was_called.ShouldBeTrue();
                actual_result.ShouldEqual(obj_to_return);
            };

            static bool was_called;
            static object actual_result;
            static object obj_to_return;
        }
    }
}