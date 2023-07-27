public class Vegetable
{
    private string Name { get; }

    public Vegetable(string name) => Name = name;

    // override toString method
    public override string ToString() => Name;
}