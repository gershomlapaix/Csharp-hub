public class program
{
    public enum Unit { item, kilogram, gram, dozen }
    static void Main()
    {
        var item = new Vegetable("eggplant");
        var date = DateTime.Now;
        var price = 1.99m;
        var unit = Unit.item;

        Console.WriteLine($"On {date}, the price of {item} was {price:C2} per {unit}.");
        Console.WriteLine();

        // width and alignment of interpolation expressions
        var titles = new Dictionary<string, string>()
        {
            ["Doyle, Arthur Conana"] = "Hound of the Baskerviless, The",
            ["London, Jack"] = "Call of the Wild, The",
        };

        Console.WriteLine("Author and Title List");
        Console.WriteLine();
        Console.WriteLine($"|{"Author",-25}|{"Title",30}");
        foreach (var title in titles)
            Console.WriteLine($"|{title.Key,-25}|{title.Value,30}");


        // using ?: operator in the interpolation
        var rand = new Random();
        for (int i = 0; i < 7; i++)
            Console.WriteLine($"Coin flip: {(rand.NextDouble() < 0.5 ? "heads" :
    "tails")}");
    }
}