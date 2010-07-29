using System;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public class DefaultLoggingFactory : LoggerFactory
    {
        public Logger get_logger_bound_to(Type type_that_requested_logging_services)
        {
            return Container.retrieve.an<Logger>();
        }
    }
}