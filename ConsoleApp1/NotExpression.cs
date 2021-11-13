class NotExpression : Expression
{
    public Expression Arg { get; }

    public NotExpression(Expression arg)
    {
        Arg = arg;
    }
    public static Expression Create(Expression expression)
    {
        return expression switch
        {
            TrueExp => FalseExp.Instance,
            FalseExp => TrueExp.Instance,
            NotExpression ne => ne.Arg,
            _ => new NotExpression(expression)
        };
    }

    override public string ToString() => $"!{Arg}";
}