using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest : Request
    {
        RequestModelMapper mapper;

        public DefaultRequest(RequestModelMapper mapper)
        {
            this.mapper = mapper;
        }

        public InputModel map<InputModel>()
        {
            return mapper.create_model_from_request<InputModel>(this);
        }

        public string command
        {
            get { throw new NotImplementedException(); }
        }
    }
}