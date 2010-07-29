namespace nothinbutdotnetstore.infrastructure
{
    public interface DiscreteMapper<Input,Output>
    {
        Output map_from(Input input);
    }
}