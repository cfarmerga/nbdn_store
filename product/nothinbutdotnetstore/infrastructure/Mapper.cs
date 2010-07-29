namespace nothinbutdotnetstore.infrastructure
{
    public interface Mapper
    {
         Output map<Input,Output>(Input input);
    }
}