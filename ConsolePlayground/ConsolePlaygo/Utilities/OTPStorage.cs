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

        public static (bool, string) ValidateOTP(string key, string inputOtpCode)
        {
            OTP storedOtp = RetrieveOTP(key);

            // Check if OTP is found and not expired
            if (storedOtp != null && DateTime.Now <= storedOtp.ExpirationDate)
            {
                // Check if the provided OTP code matches the stored OTP code
                if (storedOtp.OTPCode == inputOtpCode)
                {
                    return (true, "Valid");
                }
                else
                {
                    return (false, "Invalid");
                }
            }
            else
            {
                // If OTP is not found or expired
                return (false, "Expired");
            }
        }
    }
}
