class FalseExp : Expression
{
    private FalseExp() { }
    public static readonly Expression Instance = new FalseExp();
    public override string ToString() => "0";
}