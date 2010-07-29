using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestFactory:RequestFactory
    {
        public Request create_request_from(HttpContext http_context)
        {
            throw new NotImplementedException();
        }
    }
}
