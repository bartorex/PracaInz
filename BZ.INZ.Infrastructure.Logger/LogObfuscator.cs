using BZ.INZ.Infrastructure.Logger.Strategies;
using Newtonsoft.Json;

namespace BZ.INZ.Infrastructure.Logger {
    public class LogObfuscator {

        
        private string Obfuscation(object argument, ObfuscationJsonConverter converter) {
            return JsonConvert.SerializeObject(argument, Formatting.Indented, converter);
        }
    }
}
