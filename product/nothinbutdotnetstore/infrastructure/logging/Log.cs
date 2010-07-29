using System;
using System.Diagnostics;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public class Log
    {

        public static Logger an
        {
            get {
                var stackFrame = new StackFrame(1);
                return Container.retrieve.an<LoggerFactory>().get_logger_bound_to(stackFrame.GetMethod().DeclaringType);
            }
        }
    }
}