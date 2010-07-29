using System;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public class Log
    {
        public static LoggingFactoryResolver logging_factory_resolver = delegate {

            throw new NotImplementedException("This needs to be configured at app startup");
        };

        public static Logger an
        {
            get { throw new NotImplementedException(); }
        }
    }
}