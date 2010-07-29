using System;
using System.IO;
using System.Web;

namespace nothinbutdotnetstore.specs.utility
{
    public class ObjectMother
    {
        public static HttpContextBuilder create_http_context()
        {
            return new HttpContextBuilder();
        }

        public class HttpContextBuilder
        {
            string url;

            public HttpContextBuilder():this("http://localhost/blah.aspx")
            {
            }

            public HttpContextBuilder(string url)
            {
                this.url = url;
            }

            public HttpContextBuilder to_target(string new_url)
            {
               return new HttpContextBuilder(new_url); 
            }

            public static implicit operator HttpContext(HttpContextBuilder builder)
            {
                return new HttpContext(create_request(builder.url), create_response());
            }


        }

        public static HttpResponse create_response()
        {
            return new HttpResponse(new StringWriter());
        }

        public static HttpRequest create_request(string url)
        {
            return new HttpRequest(url, url, String.Empty);
        }
    }
}