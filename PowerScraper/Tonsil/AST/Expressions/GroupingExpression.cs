namespace PowerScraper.Tonsil.AST.Expressions;

public class GroupingExpression : Expression
{
    public Expression Expression;

    public GroupingExpression(Expression expression)
    {
        Expression = expression;
    }

    public override T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }
}