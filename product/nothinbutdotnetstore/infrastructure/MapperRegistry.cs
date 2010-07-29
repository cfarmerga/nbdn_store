namespace nothinbutdotnetstore.infrastructure
{
    public interface MapperRegistry
    {
        DiscreteMapper<Input,Output> get_mapper_to_map<Input, Output>();
    }
}