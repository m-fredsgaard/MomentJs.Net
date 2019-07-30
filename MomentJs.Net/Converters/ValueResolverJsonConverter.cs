using System;
using System.Globalization;
using System.Reflection;
using MomentJs.Net.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MomentJs.Net.Converters
{
    internal class ValueResolverJsonConverter<T> : ValueResolverJsonConverter
        where T : JsonConverter, new()
    {
        public override bool CanRead => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            value = GetValue(value, serializer.Culture);
            JsonConverter jsonConverter = new T();
            jsonConverter.WriteJson(writer, value, serializer);
        }
    }

    internal class ValueResolverJsonConverter : JsonConverter
    {
        protected object GetValue(object localeResolver, CultureInfo culture)
        {
            MethodInfo invokeMethod = localeResolver.GetType().GetMethod("Invoke");
            object value = invokeMethod?.Invoke(localeResolver, new object[] {culture});

            return value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            value = GetValue(value, serializer.Culture);
            if (value != null)
                JToken.FromObject(value).WriteTo(writer);
            else
                writer.WriteNull();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException(
                "Unnecessary because CanRead is false. The type will skip the converter.");
        }

        public sealed override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ValueResolver<>);
        }
    }
}