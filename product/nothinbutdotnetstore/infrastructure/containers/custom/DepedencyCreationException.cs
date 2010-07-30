using System;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class DepedencyCreationException: Exception
    {
        public Type type_that_could_not_be_created { get; private set; }
    }
}