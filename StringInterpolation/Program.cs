public class program
{
    public enum Unit { item, kilogram, gram, dozen }
    static void Main()
    {
        var item = new Vegetable("eggplant");
        var date = DateTime.Now;
        var price = 1.99m;
        var unit = Unit.item;

        Console.WriteLine($"On {date}, the price of {item} was {price} per {unit}.");
    }
}