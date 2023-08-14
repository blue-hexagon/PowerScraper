namespace PowerScraper.Core.Scraping.Module;

public abstract class AutoKey
{
    protected AutoKey(string value)
    {
        Value = value;
    }

    public abstract string Next();
    public string Value { get; set; }
}

public class NumberKey : AutoKey
{
    public NumberKey(string value = "0") : base(value)
    {
    }

    public override string Next()
    {
        Value = Convert.ToString(Convert.ToInt16(Value) + 1);
        return Value;
    }

}

public class AlphabeticKey : AutoKey
{
    public AlphabeticKey(string value = "A") : base(value)
    {
        Value = value;
    }

    public override string Next()
    {
        // 65-90 UPPER
        // 97-122 LOWER
        var nextChar = Convert.ToInt16(Value) + 1;
        if (nextChar > 65 && nextChar < 90 || nextChar > 97 && nextChar < 122)
            Value = Convert.ToString(Convert.ToByte(Value) + 1);
        else
            throw new IndexOutOfRangeException("Character overflow - only single character a-z and A-Z supported.");
        return Value;
    }
}