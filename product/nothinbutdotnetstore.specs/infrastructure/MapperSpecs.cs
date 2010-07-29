using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class MapperSpecs
    {
        public abstract class concern : Observes<Mapper,
                                            DefaultMapper>
        {
        }

        [Subject(typeof(DefaultMapper))]
        public class when_mapping_an_input_to_an_output : concern
        {
            Establish c = () =>
            {
                mapped_item = new OurMappedItem();

                provide_a_basic_sut_constructor_argument<MapperRegistry>(
                    new MyMapperRegistry<int, OurMappedItem>(new MyMapper<int, OurMappedItem>(mapped_item)));

            };

            Because b = () =>
                result = sut.map<int, OurMappedItem>(value_to_map);

            It should_return_the_output_mapped_using_the_appropriate_discrete_mapper = () =>
                result.ShouldEqual(mapped_item);

            static OurMappedItem result;
            static OurMappedItem mapped_item;
            static DiscreteMapper<int,OurMappedItem> discrete_mapper;
            static int value_to_map = 1;
        }

        public class MyMapper<Input, Output> : DiscreteMapper<Input, Output>
        {
            Output to_return;

            public MyMapper(Output to_return)
            {
                this.to_return = to_return;
            }

            public Output map_from(Input input)
            {
                return to_return;
            }
        }
        public class MyMapperRegistry<Input,Output> : MapperRegistry
        {
            DiscreteMapper<Input, Output> to_return;

            public MyMapperRegistry(DiscreteMapper<Input, Output> to_return)
            {
                this.to_return = to_return;
            }

            public DiscreteMapper<Input, Output> get_mapper_to_map<Input, Output>()
            {
                object item = to_return;
                return (DiscreteMapper<Input, Output>) item;
            }
        }

        class OurMappedItem
        {
        }
    }
}