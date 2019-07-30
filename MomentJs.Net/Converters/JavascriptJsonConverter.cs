using System;
using MomentJs.Net.Globalization;
using Newtonsoft.Json;

namespace MomentJs.Net.Converters
{
    internal class JavascriptJsonConverter : JsonConverter
    {
        public override bool CanRead => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string function = value.ToString();
            if (string.IsNullOrWhiteSpace(function))
                function = "function (value) { return value; }";

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
            return typeof(Javascript).IsAssignableFrom(objectType);
        }
    }
}