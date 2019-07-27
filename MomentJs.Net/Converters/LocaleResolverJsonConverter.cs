using System;
using System.Reflection;
using MomentJs.Net.Definitions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MomentJs.Net.Converters
{
    internal class LocaleResolverJsonConverter<T> : LocaleResolverJsonConverter
        where T : JsonConverter, new()
    {
        public override bool CanRead => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            value = GetValue(value);
            JsonConverter jsonConverter = new T();
            jsonConverter.WriteJson(writer, value, serializer);
        }
    }

    internal class LocaleResolverJsonConverter : JsonConverter
    {
        protected object GetValue(object localeResolver)
        {
            MethodInfo invokeMethod = localeResolver.GetType().GetMethod("Invoke");
            object value = invokeMethod?.Invoke(localeResolver, new object[0]);

            return value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            value = GetValue(value);
            if (value != null)
                JToken.FromObject(value).WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException(
                "Unnecessary because CanRead is false. The type will skip the converter.");
        }

        public sealed override bool CanConvert(Type objectType)
        {
            return objectType == typeof(LocaleDefinition.ValueResolver<>);
        }
    }
}