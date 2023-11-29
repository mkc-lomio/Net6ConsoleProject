using System;
using System.Runtime.Caching;

namespace ConsolePlayground.Utilities
{
    public class OTPStorage
    {
        private static MemoryCache _cache = new MemoryCache("OTPStorage");

        public static void StoreOTP(string key, string otp)
        {
            // Set cache policy (5 minutes expiration)
            CacheItemPolicy policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
            };

            // Store OTP in the cache
            _cache.Set(key, otp, policy);
        }

        public static string RetrieveOTP(string key)
        {
            // Retrieve OTP from cache
            return _cache.Get(key) as string;
        }
    }
}
