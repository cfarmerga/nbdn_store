using System;

namespace nothinbutdotnetstore.infrastructure
{
    public static class FuncExtension
    {
        public static Func<T> cache_result<T>(this Func<T> factory) where T : class
        {
            T cached = null;
            return () =>
                       {
                           if (cached == null)
                               cached = factory();
                           return cached;
                           //return factory();
                       };
        }
    }
}