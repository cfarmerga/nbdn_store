using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest : Request
    {
        public Mapper mapper;
        public NameValueCollection payload;
        public string command { get; private set; }

        public DefaultRequest(Mapper mapper, NameValueCollection payload,string command)
        {
            this.command = command;
            this.mapper = mapper;
            this.payload = payload;
        }

        public InputModel map<InputModel>()
        {
            return mapper.map<NameValueCollection,InputModel>(payload);
        }
    }
}