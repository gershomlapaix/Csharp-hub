/* Pattern matching: testing expressions for certain characteristics*/

public record Order(int Items, decimal Cost);

class Program
{
    static void Main()
    {
        // null checks
        int? mynum = 3334;

        if (mynum is int number)
        {
            Console.WriteLine($"The nullable int 'mynum' has the value {number}");
        }
        else
        {
            Console.WriteLine($"'mynum' may be holding no value");
        }

        // strings
        string? message = "This is not a null string";
        if (message is not null)
        {
            Console.WriteLine(message);
        }


        // relational patterns
        string waterState(int tempInFahrenheit) =>
            tempInFahrenheit switch
            {
                (> 32) and (< 212) => "Liquid",
                < 32 => "solid",
                > 212 => "gas",
                32 => "solid/liquid transition",
                212 => "liquid/ gas transition",
            };

        Console.WriteLine(waterState(43));

        // relational patterns : multiple inputs
        decimal CalculateDiscount(Order order) =>
        order switch
        {
            { Items: > 10, Cost: 1000.00m } => 0.01m,
            {Items: > 5, Cost: > 500.00m } => 0.05m,  // by omitting the property names
            { Cost: > 250.00m } => 0.02m,
            null => throw new ArgumentNullException(nameof(order), "can't calculate discount on null order"),
            var someObject => 0m
        };

        Console.WriteLine(CalculateDiscount(new Order(6, 34000)));

    }
}