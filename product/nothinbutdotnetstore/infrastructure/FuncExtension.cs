using System;

namespace nothinbutdotnetstore.infrastructure
{
    public static class FuncExtension
    {
        public static Func<T> cache_result<T>(this Func<T> factory)
        {
            return factory;
        }
    }
}