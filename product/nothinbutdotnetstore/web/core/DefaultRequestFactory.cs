using System;
using System.Web;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestFactory : RequestFactory
    {
        Mapper mapper;

        public DefaultRequestFactory(Mapper mapper)
        {
            this.mapper = mapper;
        }

        public DefaultRequestFactory():this(new DefaultMapper())
        {
        }

        public Request create_request_from(HttpContext http_context)
        {
            return new DefaultRequest(mapper, http_context.Request.Params,
                                      http_context.Request.RawUrl);
        }
    }
}