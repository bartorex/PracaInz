using System;

namespace BZ.INZ.Infrastructure.Logger.Strategies {
    public class ExceptThreLastCharactersObfuscationStrategy : IObfuscationStrategy {
        public string Obfuscate(string value) {
            var digitsLen = Math.Max(0, value.Length - 3);
            var lastChars = value.Substring(digitsLen);
            return string.Format("{0} {1}", new string('*', digitsLen), lastChars);
        }
    }
}
