using PowerScraper.Tonsil.AST.Expressions;

namespace PowerScraper.Tonsil.AST;

public abstract class Expression
{
    public abstract T Accept<T>(IVisitor<T> visitor);

    public interface IVisitor<TVisitor>
    {
        public TVisitor Visit(BinaryExpression expression);
        public TVisitor Visit(GroupingExpression expression);
        public TVisitor Visit(LiteralExpression expression);
        public TVisitor Visit(UnaryExpression expression);
    }
}