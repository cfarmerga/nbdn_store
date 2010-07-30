using System;
using System.Linq;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class GreedyConstructorResolver : ConstructorResolver
    {
        public ConstructorInfo get_applicable_constructor_on(Type type)
        {
            return type.GetConstructors().OrderByDescending(x => x.GetParameters().Length).First();
        }
    }
}