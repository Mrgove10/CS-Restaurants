using System;
using System.Linq;

namespace Grestau.Data.Services
{
    public class Utils
    {
        private static Random random = new Random();

        /// <summary>
        /// Generates a random alphanumeric string
        /// https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Generates a random number
        /// https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static int RandomNumber(int length)
        {
            const string chars = "0123456789";
            var r = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return int.Parse(r);
        }

        /// <summary>
        /// Generates a random email address
        /// http://www.startscripting.com/uncategorized/a-method-to-generate-any-test-data-like-email-address-credit-card-number-or-any-other-names-randomly/
        /// </summary>
        /// <param name="numberOfCharacters"></param>
        /// <returns></returns>
        public static string RandomEmail(int numberOfCharacters) // pass the number of characters for your email to be generated before '@'
        {
            var characters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            var emailAddress = new string(Enumerable.Repeat(characters, numberOfCharacters).Select(s => s[random.Next(s.Length)]).ToArray());
            emailAddress += "@test123.com";
            return emailAddress;
        }
    }
}