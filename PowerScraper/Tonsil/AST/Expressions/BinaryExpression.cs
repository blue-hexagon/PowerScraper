namespace PowerScraper.Tonsil.AST.Expressions;

public class BinaryExpression : Expression
{
    public Token Operation;
    public  Expression Left;
    public  Expression Right;

    public BinaryExpression(Expression left,Token operation,  Expression right)
    {
        Operation = operation;
        Left = left;
        Right = right;
    }

    public override T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }
}