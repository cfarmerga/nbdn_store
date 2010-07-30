using System;

namespace nothinbutdotnetstore.infrastructure
{
    public static class FuncExtension
    {
        public static Func<T> cache_result<T>(this Func<T> factory) 
        {
            T cached = default(T);
            var is_cached = false;

            return () =>
                       {
                           //TODO - Refactor this
                           if (is_cached) return cached;
                           is_cached = true;
                           cached = factory();
                           return cached;
                       };
        }
    }
}