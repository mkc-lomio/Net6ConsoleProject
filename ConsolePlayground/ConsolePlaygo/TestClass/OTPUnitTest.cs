using ConsolePlayground.Helpers;
using ConsolePlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.TestClass
{
    public class OTPUnitTest
    {
        public static void TestOTP()
        {
            string key = "user2_otp"; // This could be a user identifier
            string otp = OTPGenerator.GenerateOTP(6);
            OTPStorage.StoreOTP(key, otp);

            // Example of retrieving the OTP
            DateTime startTime = DateTime.Now;
            TimeSpan duration = TimeSpan.FromMinutes(6);

            while (DateTime.Now - startTime < duration)
            {
                Console.WriteLine("Executing some task...");
                // Place the code for the task you want to perform here

                string retrievedOTP = OTPStorage.RetrieveOTP(key);
                Console.WriteLine($"Retrieved OTP: {retrievedOTP}");

                // Wait for 1 minute (60000 milliseconds)
                Thread.Sleep(60000);
            }
        }
    }
}
