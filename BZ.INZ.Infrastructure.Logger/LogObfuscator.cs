using BZ.INZ.Infrastructure.Logger.Strategies;
using Newtonsoft.Json;

namespace BZ.INZ.Infrastructure.Logger {
    public class LogObfuscator {
        private ObfuscationJsonConverter converter;

        public LogObfuscator(ObfuscationJsonConverter converter) {
            this.converter = converter;
        }

        public string Obfuscation(object argument) {
            var result =  JsonConvert.SerializeObject(argument, Formatting.Indented, converter);
            return result;
        }
    }
}
