namespace BZ.INZ.Infrastructure.Logger.Strategies {
    public interface IObfuscationStrategy {
        string Obfuscate(string value);
    }
}
