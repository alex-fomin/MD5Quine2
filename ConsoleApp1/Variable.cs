class Variable : Expression
{
    public string Name { get; }

    public Variable(string name)
    {
        Name = name;
    }

    public override string ToString() => Name;
}