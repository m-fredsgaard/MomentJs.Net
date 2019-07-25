using System;
using MomentJs.Net.Definitions;
using Newtonsoft.Json;

namespace MomentJs.Net.Converters
{
    internal class OrdinalJsonConverter : JsonConverter
    {
        public override bool CanRead => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string function = value.ToString();
            if (string.IsNullOrWhiteSpace(function))
                function = "function (number) { return number; }";

            writer.WriteRawValue(function);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException(
                "Unnecessary because CanRead is false. The type will skip the converter.");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Ordinal);
        }
    }
}