// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;
// using PowerScraper.Core.Scraping.DataStructure.Collection;
//
// namespace PowerScraper.Core.Serializers.Json;
//
// public class KeysJsonConverter : JsonConverter<CollectionTree>
// {
//     private readonly Type[] _types;
//
//     public KeysJsonConverter(params Type[] types)
//     {
//         _types = types;
//     }
//
//     public override void WriteJson(JsonWriter writer, CollectionTree? value, Newtonsoft.Json.JsonSerializer serializer)
//     {
//         var tree = (CollectionTree)value!;
//         var t = JToken.FromObject(value!);
//
//         if (t.Type != JTokenType.Object)
//         {
//             t.WriteTo(writer);
//         }
//         else
//         {
//             var o = (JObject)t;
//             IList<string> propertyNames = o.Properties().Select(p => p.Name).ToList();
//             if (o.ContainsKey("Items"))
//                 o.Replace(("")); // JToken("");
//             o.AddFirst(new JProperty("Keys", new JArray(propertyNames)));
//             
//             o.WriteTo(writer);
//         }
//     }
//
//     public override CollectionTree? ReadJson(JsonReader reader, Type objectType, CollectionTree? existingValue, bool hasExistingValue,
//         Newtonsoft.Json.JsonSerializer serializer)
//     {
//         throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
//     }
//
//     public override bool CanRead => false;
//
//     public bool CanConvert(Type objectType)
//     {
//         return _types.Any(t => t == objectType);
//     }
// }