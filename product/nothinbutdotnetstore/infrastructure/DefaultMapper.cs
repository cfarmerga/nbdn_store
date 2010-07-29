using nothinbutdotnetstore.infrastructure.stubs;

namespace nothinbutdotnetstore.infrastructure
{
    public class DefaultMapper : Mapper
    {
        MapperRegistry mapper_registry;

        public DefaultMapper():this(new StubMapperRegistry())
        {
        }

        public DefaultMapper(MapperRegistry mapper_registry)
        {
            this.mapper_registry = mapper_registry;
        }

        public Output map<Input, Output>(Input input)
        {
            return mapper_registry.get_mapper_to_map<Input, Output>().map_from(input);
        }
    }
}