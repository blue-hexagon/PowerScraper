namespace PowerScraper.Core.Scraping.DataStructure.Collection;

public class CollectionTree
{
    private CollectionTree? ParentNode { get; set; }
    public string ModuleName { get; set; }
    
    public List<CollectionTree> Nodes { get; set; } = new();
    public List<(string,string)> Items { get; set; }= new();
    

    public CollectionTree()
    {
        ModuleName = "Generic Module Name";
    }
    public CollectionTree(string moduleName)
    {
        ModuleName = moduleName;
    }

    public void TraverseCollection()
    {
        InnerFunction(this);

        void InnerFunction(CollectionTree node)
        {
            Console.WriteLine(node.ModuleName);
            foreach (var child in node.Nodes)
            {
                if (child.Nodes.Count != 0)
                {
                    InnerFunction(child);
                }
                else
                {
                    Console.WriteLine(child.ModuleName);
                    foreach (var item in child.Items)
                    {
                        Console.WriteLine(item.Item1 + " : " + item.Item2);
                    }
                }
            }

            foreach (var item in node.Items)
            {
                Console.WriteLine(item.Item1 + " : " + item.Item2);
            }

        }
    }
    public static List<CollectionTree> DfsList(CollectionTree root)
    {
        var dfsList = new List<CollectionTree>();
        InnerFunction(root);

        void InnerFunction(CollectionTree node)
        {
            dfsList.Add(node);
            foreach (var child in node.Nodes)
            {
                if (child.Nodes.Count != 0)
                    InnerFunction(child);
                else
                    dfsList.Add(child);
            }
        }

        return dfsList;
    }

    public CollectionTree InsertModule(CollectionTree node)
    {
        Nodes.Add(node);
        node.ParentNode = this;
        return node;
    }

    public void AddItem(string key, string value)
    {
        Items.Add((key, value));
    }

    public override string ToString()
    {
        return ModuleName;
    }

}