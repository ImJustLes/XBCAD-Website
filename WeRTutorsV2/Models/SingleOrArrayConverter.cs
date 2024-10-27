using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace WeRTutorsV2.Models
{
    public class SingleOrArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(List<T>);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                JToken token = JToken.Load(reader);
                Console.WriteLine($"Token Type: {token.Type}, Token Value: {token}");

                if (token.Type == JTokenType.Array)
                {
                    return token.ToObject<List<T>>();
                }
                else if (token.Type == JTokenType.String)
                {
                    // Convert single string to a list with one element
                    Console.WriteLine("Single value found, converting to list.");
                    return new List<T> { token.ToObject<T>() };
                }
                else
                {
                    throw new JsonSerializationException($"Unexpected token type: {token.Type}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion error in SingleOrArrayConverter: {ex.Message}");
                return new List<T>(); // Return an empty list if conversion fails
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<T> list = (List<T>)value;
            if (list.Count == 1)
            {
                serializer.Serialize(writer, list[0]);
            }
            else
            {
                serializer.Serialize(writer, list);
            }
        }
    }
}
