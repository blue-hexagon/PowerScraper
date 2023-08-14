namespace PowerScraper.Core.Scraping.DataStructure;

public class DescriptorNode
{
    private DescriptorNode? ParentNode { get; init; }
    private List<DescriptorNode> ChildNodes { get; set; } = new();
    public readonly AbstractDescriptor Descriptor;
    public static readonly Dictionary<string, DescriptorNode> DescriptorNodeIndex = new();

    public DescriptorNode(AbstractDescriptor descriptor)
    {
        Descriptor = descriptor;
    }

    public DescriptorNode Insert(AbstractDescriptor descriptor)
    {
        var childNode = new DescriptorNode(descriptor) { ParentNode = this };
        ChildNodes.Add(childNode);
        return childNode;
    }

    /** Uses DFS to return a subtree of the Node calling this method. */
    // FIX: The calling Node is returned as well
    public List<DescriptorNode> ReturnSubTreeNodes()
    {
        var nodeList = new List<DescriptorNode>();
        InnerFunction(this, nodeList);
        nodeList.Add(this);

        void InnerFunction(DescriptorNode node, List<DescriptorNode> leafNodes)
        {
            foreach (var treeNode in node.ChildNodes)
            {
                if (treeNode.ChildNodes.Count != 0)
                    InnerFunction(treeNode, leafNodes);
                leafNodes.Add(treeNode);
            }
        }

        return nodeList;
    }

    public void FindDescriptor(string descriptorName)
    {
        foreach (var item in DescriptorNodeIndex)
            if (item.Key[2..] == descriptorName)
                return;

        throw new KeyNotFoundException();
    }

    public List<DescriptorNode> GetLeafNodes()
    {
        var nodeList = new List<DescriptorNode>();
        InnerFunction(this, nodeList);

        void InnerFunction(DescriptorNode node, List<DescriptorNode> leafNodes)
        {
            foreach (var treeNode in node.ChildNodes)
            {
                if (treeNode.ChildNodes.Count != 0)
                    InnerFunction(treeNode, leafNodes);
                if (treeNode.ChildNodes.Count == 0)
                    leafNodes.Add(treeNode);
            }
        }

        return nodeList;
    }

    public override string ToString()
    {
        return Descriptor.ToString();
    }
}