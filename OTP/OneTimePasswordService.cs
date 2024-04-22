using System.Security.Cryptography;

namespace otp1
{
    public class OneTimePasswordService : IOneTimePasswordService
    {
        private const int OTPDuration = 300;
        private static Dictionary<string, DateTime> otpStore = new Dictionary<string, DateTime>();

        public string GenerateOTP()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_-+=<>?";

            var otpLength = 8; // Lungimea OTP generat
            var otp = new char[otpLength];

            // Folosește clasa Random pentru a genera caractere aleatoare
            Random random = new Random();

            // Generare aleatorie a caracterelor OTP din lista de caractere
            for (int i = 0; i < otpLength; i++)
            {
                otp[i] = chars[random.Next(chars.Length)];
            }

            var otpString = new string(otp);
            otpStore.Add(otpString, DateTime.Now.AddSeconds(OTPDuration));
            return otpString;

        }


        public bool ValidateOTP(string otp)
        {
            if (otpStore.ContainsKey(otp) && otpStore[otp] > DateTime.Now)
            {
                otpStore.Remove(otp);
                return true;
            }
            return false;
        }
    }

}
