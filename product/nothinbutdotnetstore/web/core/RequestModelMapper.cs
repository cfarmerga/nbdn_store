namespace nothinbutdotnetstore.web.core
{
    public interface RequestModelMapper
    {
        T create_model_from_request<T>(Request request);
    }
}