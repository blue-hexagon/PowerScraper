using System.Collections;

namespace PowerScraper.Core.Scraping.DataStructure.Collection;

public class CollectionEnum : IEnumerator
{
    private readonly List<CollectionTree> _collectionTrees;

    public CollectionEnum(List<CollectionTree> collectionTrees)
    {
        _collectionTrees = collectionTrees;
    }
    private int _position = -1;
    public bool MoveNext()
    {
        _position++;
        return _position < _collectionTrees.Count;
    }

    public void Reset()
    {
        _position = -1;
    }

    object IEnumerator.Current => Current;

    public CollectionTree Current
    {
        get
        {
            try
            {
                return _collectionTrees[_position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}