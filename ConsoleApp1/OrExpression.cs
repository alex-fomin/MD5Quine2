class OrExpression : Expression
{
    private OrExpression(params Expression[] args)
    {
        Args = args;
    }

    private OrExpression(params Expression[][] args)
    {
        Args = args.SelectMany(x=>x).ToArray();
    }

    public Expression[] Args { get; }


    public static Expression Create(Expression a, Expression b)
    {
        return (a, b) switch
        {
            (TrueExp, _) => TrueExp.Instance,
            (_, TrueExp) => TrueExp.Instance,
            (FalseExp, _) => b,
            (_, FalseExp) => a,
            (OrExpression and1, OrExpression and2) => new OrExpression(and1.Args, and2.Args),
            (OrExpression and1, _) => new OrExpression(and1.Args, new[]{b}),
            (_, OrExpression and2) => new OrExpression(new[]{a}, and2.Args),
            _ => new OrExpression(a, b)
        };
    }

    public override string ToString() => $"({string.Join(" | ", Args.Select(x => x.ToString()))})";
}