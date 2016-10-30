using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace BZ.INZ.Infrastructure.Logger.Strategies {
    public class ObfuscationJsonConverter : JsonConverter {
        private readonly IDictionary<string, IObfuscationStrategy> propToObfuscation;

        public ObfuscationJsonConverter(IDictionary<string, IObfuscationStrategy> propToObfuscation) {
            this.propToObfuscation = propToObfuscation;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var token = JToken.FromObject(value);
            var o = new JObject(new JProperty("Log", token));
            foreach (var node in o.Descendants().Where(
                t => t.Type == JTokenType.Property &&
                propToObfuscation.ContainsKey(((JProperty)t).Name))) {
                var tokenValue = ((JProperty)node).Value.ToString();
                var strategy = propToObfuscation[((JProperty)node).Name];
                ((JProperty)node).Value = strategy.Obfuscate(tokenValue);
            }
            o.WriteTo(writer);
        }

        public override bool CanConvert(Type objectType) {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}
