using System.Collections;

namespace PowerScraper.Core.Scraping.DataStructure.Collection;

public class CollectionTrees : IEnumerable
{
    private readonly List<CollectionTree> _collectionTrees;

    public CollectionTrees(CollectionTree collectionTrees)
    {
        _collectionTrees = CollectionTree.DfsList(collectionTrees);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public CollectionEnum GetEnumerator()
    {
        return new CollectionEnum(_collectionTrees);
    }
}