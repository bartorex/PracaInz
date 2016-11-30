namespace BZ.INZ.Infrastructure.Logger.Strategies {
    public class DefaultObfuscationStrategy : IObfuscationStrategy {
        public string Obfuscate(string value) {
            return "*****";
        }
    }
}
