using System.Data;
using System.Linq;
using System.Reflection;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers.custom;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class GreedyConstructorResolverSpecs
    {
        public abstract class concern : Observes<ConstructorResolver,
                                            GreedyConstructorResolver>
        {
        }

        [Subject(typeof(GreedyConstructorResolver))]
        public class when_constructor_for_a_type_is_retrieved : concern
        {
            Because b = () =>
                result = sut.get_applicable_constructor_on(typeof(MyTestType));

            It should_be_the_constructor_with_the_largest_number_of_parameters = () =>
                result.GetParameters().Count().ShouldEqual(3);

            static ConstructorInfo result;
        }

        public class MyTestType
        {
            public int one;
            public string two;
            public IDbConnection three;

            public MyTestType()
            {
            }

            public MyTestType(int one, string two)
            {
                this.one = one;
                this.two = two;
            }

            public MyTestType(int one, string two, IDbConnection three)
            {
                this.one = one;
                this.two = two;
                this.three = three;
            }

            public MyTestType(int one)
            {
                this.one = one;
            }

            public MyTestType(IDbConnection three)
            {
                this.three = three;
            }
        }
    }
}