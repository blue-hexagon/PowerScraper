namespace PowerScraper.Tonsil.AST.Expressions;

public class UnaryExpression : Expression
{
    public Token Operation { get; }
    public Expression Right { get; }

    public UnaryExpression(Token operation, Expression right)
    {
        Operation = operation;
        Right = right;
    }

    public override T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }
}