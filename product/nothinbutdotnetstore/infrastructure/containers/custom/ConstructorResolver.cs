using System;
using System.Reflection;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public interface ConstructorResolver
    {
        ConstructorInfo get_applicable_constructor_on(Type type);
    }

    public class GreedyConstructorResolver : ConstructorResolver
    {
        public ConstructorInfo get_applicable_constructor_on(Type type)
        {
            return type.GetConstructors().OrderByDescending(constructor => constructor.GetParameters().Count()).First();
        }
    }
}