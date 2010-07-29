using System;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public interface LoggerFactory
    {
        Logger get_logger_bound_to(Type type_that_requested_logging_services);
    }
}