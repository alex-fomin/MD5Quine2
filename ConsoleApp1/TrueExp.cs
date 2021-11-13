class TrueExp : Expression
{
    private TrueExp() { }
    public static readonly Expression Instance = new TrueExp();
    public override string ToString() => "1";
}