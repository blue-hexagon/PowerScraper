using PowerScraper.Core.Utility;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;

namespace PowerScraper.Core.Scraping.DataStructure.Collection;

using YamlDotNet.Serialization;

public class CollectionTree : IYamlConvertible
{
    private CollectionTree? ParentNode { get; set; }

    public string ModuleName { get; set; }

    public List<CollectionTree> Nodes { get; set; } = new();

    public List<Item> Items { get; set; } = new();
    public List<Item> ItemSequence { get; set; } = new();


    public CollectionTree()
    {
        // Set it in the first line of the Scraper Logic
        ModuleName = "";
    }

    public CollectionTree(string moduleName)
    {
        ModuleName = moduleName;
    }

    public CollectionTree InsertModule(CollectionTree node)
    {
        Nodes.Add(node);
        node.ParentNode = this;
        return node;
    }

    public void AddItem(string key, string value)
    {
        Items.Add(new Item(key, value));
    }

    public override string ToString()
    {
        return ModuleName;
    }

    public void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {
        throw new NotSupportedException();
    }

    public void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        if (ModuleName == VersionStatus.ApplicationTag) // Root node
        {
            // Have to put in guard rails for the MappingStart and MappingEnd of the root node
            // because of the calls to nestedObjectSerializer.
            emitter.Emit(new MappingStart(null, null, false, MappingStyle.Block));
        }

        emitter.Emit(new Scalar(null, ModuleName));
        emitter.Emit(new MappingStart(null, null, false, MappingStyle.Block));


        if (Items.Count > 0)
        {
            foreach (var item in Items)
            {
                emitter.Emit(new Scalar(null, item.Key));
                emitter.Emit(new Scalar(null, item.Value));
            }
        }

        if (ItemSequence.Count > 0)
        {
            emitter.Emit(new Scalar(null, "Drives"));
            emitter.Emit(new SequenceStart(null, null, false, SequenceStyle.Block));
            // var firstKey = ItemSequences.First().Key;
            emitter.Emit(new MappingStart(null, null, false, MappingStyle.Block));
            foreach (var items in ItemSequence)
            {
                emitter.Emit(new Scalar(null, items.Key));
                emitter.Emit(new Scalar(null, items.Value));
            }

            emitter.Emit(new MappingEnd());
            emitter.Emit(new SequenceEnd());
        }

        if (Nodes.Count > 0)
        {
            foreach (var node in Nodes)
            {
                nestedObjectSerializer(node);
            }
        }

        emitter.Emit(new MappingEnd());

        if (ModuleName == VersionStatus.ApplicationTag)
        {
            emitter.Emit(new MappingEnd());
        }
    }

    //TODO: Reconsider if this has any use cases or should be deleted
    // public void TraverseCollection()
    // {
    //     InnerFunction(this);
    //
    //     void InnerFunction(CollectionTree node)
    //     {
    //         Console.WriteLine(node.ModuleName);
    //         foreach (var child in node.Nodes)
    //         {
    //             if (child.Nodes.Count != 0)
    //             {
    //                 InnerFunction(child);
    //             }
    //             else
    //             {
    //                 Console.WriteLine(child.ModuleName);
    //                 foreach (var item in child.Items)
    //                 {
    //                     Console.WriteLine(item.Key + " : " + item.Value);
    //                 }
    //             }
    //         }
    //
    //         foreach (var item in node.Items)
    //         {
    //             Console.WriteLine(item.Key + " : " + item.Value);
    //         }
    //     }
    // }

    //TODO: Reconsider if this has any use cases or should be deleted
    // public static List<CollectionTree> DfsList(CollectionTree root)
    // {
    //     var dfsList = new List<CollectionTree>();
    //     InnerFunction(root);
    //
    //     void InnerFunction(CollectionTree node)
    //     {
    //         dfsList.Add(node);
    //         foreach (var child in node.Nodes)
    //         {
    //             if (child.Nodes.Count != 0)
    //                 InnerFunction(child);
    //             else
    //                 dfsList.Add(child);
    //         }
    //     }
    //
    //     return dfsList;
    // }
}