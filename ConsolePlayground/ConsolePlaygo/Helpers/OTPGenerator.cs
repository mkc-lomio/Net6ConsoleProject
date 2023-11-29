using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Helpers
{
    public class OTPGenerator
    {
        public static string GenerateOTP(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[length];
                rng.GetBytes(randomNumber);

                uint randomValue = BitConverter.ToUInt32(randomNumber, 0);
                return (randomValue % 1000000).ToString("D6"); // 6 digit OTP
            }
        }
    }
}
