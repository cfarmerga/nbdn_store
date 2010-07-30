using System;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class DepedencyCreationException: Exception
    {
        public Type type_that_could_not_be_created { private set; get; }

        public DepedencyCreationException(Exception exception, Type type_that_could_not_be_created):base(string.Empty,exception)
        {
            this.type_that_could_not_be_created = type_that_could_not_be_created;
        }
    }
}