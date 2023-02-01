// using System.Collections.ObjectModel;
// using PowerScraper.Core.Scraping.DataStructure;
// using PowerScraper.Core.Scraping.DataStructure.Collection;
// using YamlDotNet.Core;
// using YamlDotNet.Core.Events;
// using YamlDotNet.Serialization;
// using YamlDotNet.Serialization.NamingConventions;
// using YamlDotNet.Serialization.Utilities;
//
// namespace PowerScraper.Core.Serializers.Yaml;
//
// // class MethodCall
// // {
// // public string MethodName { get; set; }
// // public Collection<object> Arguments { get; set; }
// // }
// public sealed class CollectionTreeConverter : IYamlTypeConverter
// {
//     // Unfortunately the API does not provide those in the ReadYaml and WriteYaml
//     // methods, so we are forced to set them after creation.
//     public IValueSerializer? ValueSerializer { get; set; }
//     public IValueDeserializer? ValueDeserializer { get; set; }
//
//     public bool Accepts(Type type) => type == typeof(CollectionTree);
//
//     public object ReadYaml(IParser parser, Type type)
//     {
//         parser.Consume<MappingStart>();
//
//         var call = new CollectionTree()
//         {
//             // ModuleName =
//             // (string)ValueDeserializer.DeserializeValue(parser, typeof(string), new SerializerState(), ValueDeserializer),
//             // Items = (Dictionary<string, string>)ValueDeserializer.DeserializeValue(parser, typeof(Dictionary<string, string>), new SerializerState(), ValueDeserializer),
//             // Nodes = (Dictionary<string, CollectionTree>)ValueDeserializer.DeserializeValue(parser, typeof(Dictionary<string, CollectionTree>), new SerializerState(), ValueDeserializer),
//         };
//
//         parser.Consume<MappingEnd>();
//
//         return call;
//     }
//
//     public void WriteYaml(IEmitter emitter, object? value, Type type)
//     {
//         emitter.Emit(new MappingStart());
//
//         var call = (CollectionTree)value;
//         ValueSerializer?.SerializeValue(emitter, call.ModuleName, typeof(string));
//         ValueSerializer?.SerializeValue(emitter, call.Nodes, typeof(List<CollectionTree>));
//         ValueSerializer?.SerializeValue(emitter, call.Items, typeof(List<(string, string)>));
//
//         Console.WriteLine($"{call.ModuleName}, {call.Nodes}, {call.Items}");
//         // ValueSerializer?.SerializeValue(emitter, call?.Items.Keys, typeof(List<string>));
//         emitter.Emit(new MappingEnd());
//     }
//
//
//     CollectionTree DeserializeMethodCall(string yaml)
//     {
//         var methodCallConverter = new CollectionTreeConverter();
//         var deserializerBuilder = new DeserializerBuilder()
//             .WithNamingConvention(CamelCaseNamingConvention.Instance)
//             .WithTypeConverter(methodCallConverter);
//
//         methodCallConverter.ValueDeserializer = deserializerBuilder.BuildValueDeserializer();
//
//         var deserializer = deserializerBuilder.Build();
//         var call = deserializer.Deserialize<CollectionTree>(yaml);
//         return call;
//     }
// }