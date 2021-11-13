class AndExpression : Expression
{
    private AndExpression(params Expression[] args)
    {
        Args = args.Distinct().ToArray();
    }

    private AndExpression(params Expression[][] args)
    {
        Args = args.SelectMany(x=>x).Distinct().ToArray();
    }

    public Expression[] Args { get; }


    public static Expression Create(Expression a, Expression b)
    {
        return (a, b) switch
        {
            (TrueExp, _) => b,
            (_, TrueExp) => a,
            (FalseExp, _) => FalseExp.Instance,
            (_, FalseExp) => FalseExp.Instance,
            (AndExpression and1, AndExpression and2) => new AndExpression(and1.Args, and2.Args),
            (AndExpression and1, _) => new AndExpression(and1.Args, new[]{b}),
            (_, AndExpression and2) => new AndExpression(new[]{a}, and2.Args),
            _ => new AndExpression(a, b)
        };
    }

    public override string ToString() => $"({string.Join(" & ", Args.Select(x => x.ToString()))})";
}