namespace PowerScraper.Tonsil.AST.Expressions;

public class LiteralExpression : Expression
{
    public object Value { get; }

    public LiteralExpression(object value)
    {
        Value = value;
    }

    public override T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }
}