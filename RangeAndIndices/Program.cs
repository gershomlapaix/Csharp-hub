class Program
{
    public static void Main()
    {
        string[] words = new string[] { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
        Console.WriteLine($"The last word is {words[^1]}");

        // range: the start is inclusive and the end is exclusive

        // 1
        string[] quickBrownFox = words[1..4];
        foreach (var word in quickBrownFox)
            Console.WriteLine($"< {word} >");

        Console.WriteLine();

        string[] lazydog = words[^2..^0];
        foreach (var word in lazydog)
            Console.WriteLine($"< {word} >");

        Console.WriteLine();

        string[] allWords = words[..]; // contains "The" through "dog".
        string[] firstPhrase = words[..4]; // contains "The" through "fox"
        string[] lastPhrase = words[6..]; // contains "the", "lazy" and "dog"
        foreach (var word in allWords)
            Console.Write($"< {word} >");
        Console.WriteLine();

        // ranges and indices variables
        Index the = ^3;
        Console.WriteLine(words[the]);
        Range phrase = 1..4;
        string[] text = words[phrase];
        foreach (var word in text)
            Console.Write($"< {word} >");
        Console.WriteLine();
    }
}