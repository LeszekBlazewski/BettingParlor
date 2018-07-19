using System;

namespace BettingParlor_Refactor.UnitTests
{
    /// <summary>
    /// Generates random string used to create users with fake credentials in tesing process.
    /// </summary>
    /// <remarks>
    /// Used by <see cref="ClientFactory"/> class to create fake users.
    /// </remarks>
    class RandomStringGenerator
    {
        /// <summary>
        /// Returns random string composed of 8 characters.
        /// </summary>
        /// <returns>Random string composed of 8 characters.</returns>
        /// <remarks>
        /// Used by <see cref="ClientFactory"/> class to generate users with fake credentials.
        /// </remarks>
        public string GenerateRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }
    }
}
