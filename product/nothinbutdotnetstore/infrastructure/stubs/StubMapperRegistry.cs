using System;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.infrastructure.stubs
{
    public class StubMapperRegistry : MapperRegistry
    {
        public DiscreteMapper<Input, Output> get_mapper_to_map<Input, Output>()
        {
            object mapper = new DepartmentMapper();
            return (DiscreteMapper<Input, Output>) mapper;
        }
    }
}