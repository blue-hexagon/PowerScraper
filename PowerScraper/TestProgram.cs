// using Newtonsoft.Json;
// using PowerScraper.Core.Scraping.DataStructure;
// using PowerScraper.Core.Scraping.DataStructure.Collection;
// using PowerScraper.Core.Serializers.Json;
// using PowerScraper.Core.Serializers.Yaml;
// using YamlDotNet.Serialization;
// using YamlDotNet.Serialization.NamingConventions;
// using YamlDotNet;
//
// namespace PowerScraper;
//
// public static class TestProgram
// {
//     public static void TestJsonSerializer()
//     {
//         var root = MakeTree();
//         var json = JsonConvert.SerializeObject(root, Formatting.Indented,
//             new KeysJsonConverter(typeof(CollectionTree)));
//         Console.WriteLine(json);
//     }
//
//     public static void TestEnumerator()
//     {
//         var root = new CollectionTrees(MakeTree());
//         foreach (var node in root)
//         {
//             Console.WriteLine(node.ModuleName);
//             foreach (var item in node.Items)
//             {
//                 Console.WriteLine(item.Item1 + " - " +item.Item2);
//             }
//         }
//     }
//
//     public static void TestRootTraverser()
//     {
//         var root = MakeTree();
//         root.TraverseCollection();
//     }
//
//     public static void TestYamlSerializer()
//     {
//         var root = MakeTree();
//         SerializeMethodCall(root);
//     }
//
//     private static CollectionTree MakeTree()
//     {
//         var root = new CollectionTree("All");
//         var hardware = new CollectionTree("Hardware");
//         var system = new CollectionTree("System");
//         var ram = new CollectionTree("RAM");
//         var cpu = new CollectionTree("CPU");
//         var inteli7 = new CollectionTree("Intel Core i7");
//         var inteli7_core1 = new CollectionTree("Core 1");
//         var inteli7_core1_specs = new CollectionTree("Specs");
//         root.InsertModule(hardware);
//         root.InsertModule(system);
//         system.AddItem("BIOS", "v4.18293");
//         hardware.InsertModule(cpu);
//         hardware.InsertModule(ram);
//         cpu.InsertModule(inteli7);
//         inteli7.InsertModule(inteli7_core1);
//         inteli7.AddItem("Core Count", "4");
//         inteli7_core1.AddItem("Temp", "75C");
//         inteli7_core1.InsertModule(inteli7_core1_specs);
//         inteli7_core1_specs.AddItem("Custom Prop", "XXX");
//         cpu.AddItem("Temp", "83C");
//         cpu.AddItem("Cores", "4");
//         ram.AddItem("Free", "4,8GiB");
//         return root;
//     }
//
//     // Console.WriteLine(JsonConvert.SerializeObject(root, Formatting.Indented));
//     private static void SerializeMethodCall(CollectionTree call)
//     {
//         var collectionTreeCallConverter = new CollectionTreeConverter();
//         var serializerBuilder = new SerializerBuilder()
//             .WithNamingConvention(CamelCaseNamingConvention.Instance)
//             .WithTypeConverter(collectionTreeCallConverter)
//             .DisableAliases();
//         collectionTreeCallConverter.ValueSerializer = serializerBuilder.BuildValueSerializer();
//         var serializer = serializerBuilder.Build();
//
//         var yaml = serializer.Serialize(call);
//         Console.WriteLine(yaml);
//     }
// }