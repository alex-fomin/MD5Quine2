public abstract class Expression{
    public static implicit operator Expression(bool x)
    {
        return x ? TrueExp.Instance : FalseExp.Instance;
    }

    
    public static Expression operator &(Expression a, Expression b) => AndExpression.Create(a, b);
    public static Expression operator |(Expression a, Expression b) => OrExpression.Create(a, b);
    public static Expression operator !(Expression a) => NotExpression.Create(a);
    public static Expression operator ^(Expression a, Expression b) => XorExpression.Create(a, b);
}

internal class XorExpression : Expression
{
    public Expression[] Args { get; }

    private XorExpression(params Expression[] expression)
    {
        Args = expression;
    }

    public static Expression Create(Expression a, Expression b)
    {
        return (a, b) switch

        {
            (FalseExp, _) => b,
            (_, FalseExp) => a,
            (TrueExp, _) => !b,
            (_, TrueExp) => !a,
            var (c, d) when c == d => FalseExp.Instance,
            _ => new XorExpression(a, b)
        };
    }


    public override string ToString() => $"({string.Join(" ^ ", Args.Select(x => x.ToString()))})";

}