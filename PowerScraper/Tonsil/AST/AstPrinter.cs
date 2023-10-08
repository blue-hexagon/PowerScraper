using System.Linq.Expressions;
using System.Text;
using Markdig.Helpers;
using PowerScraper.Tonsil.AST.Expressions;
using BinaryExpression = PowerScraper.Tonsil.AST.Expressions.BinaryExpression;
using UnaryExpression = PowerScraper.Tonsil.AST.Expressions.UnaryExpression;

namespace PowerScraper.Tonsil.AST;

public class AstPrinter : Expression.IVisitor<String>
{
    public string Print(Expression expression)
    {
        return expression.Accept(this);
    }

    public string Visit(BinaryExpression expression)
    {
        return Parenthesize(expression.Operation.Value, expression.Left, expression.Right);
    }

    public string Visit(GroupingExpression expression)
    {
        return Parenthesize("group", expression.Expression);
    }

    public string Visit(LiteralExpression expression)
    {
        return expression.Value.ToString() ?? "Nil";
    }

    public string Visit(UnaryExpression expression)
    {
        return Parenthesize(expression.Operation.Value, expression.Right);
    }

    private string Parenthesize(string name, params Expression[] expressions)
    {
        var builder = new StringBuilder();
        builder.Append('(').Append(name);
        foreach (var expression in expressions)
        {
            builder.Append(' ');
            builder.Append(expression.Accept(this));
        }

        builder.Append(')');
        return builder.ToString();
    }
}